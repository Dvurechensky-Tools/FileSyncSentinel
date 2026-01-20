/*
 * Author: Nikolay Dvurechensky
 * Site: https://sites.google.com/view/dvurechensky
 * Gmail: dvurechenskysoft@gmail.com
 * Last Updated: 20 января 2026 06:53:23
 * Version: 1.0.81
 */

using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

using FastColoredTextBoxNS;

using FileSyncSentinel.Components;
using FileSyncSentinel.Presenter;
using FileSyncSentinel.Services;
using FileSyncSentinel.Services.Settings;
using FileSyncSentinel.Views;

namespace FileSyncSentinel
{
    public partial class MainForm : Form, IMainView
    {
        [DllImport("user32.dll")]
        static extern int GetScrollPos(IntPtr hWnd, int nBar);

        [DllImport("user32.dll")]
        static extern int SetScrollPos(IntPtr hWnd, int nBar, int nPos, bool bRedraw);

        [DllImport("user32.dll")]
        static extern int PostMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);

        const int WM_VSCROLL = 0x0115;
        const int SB_THUMBPOSITION = 4;
        const int SB_VERT = 1;

        private MainPresenter Presenter { get; set; }
        private IMergeService MergeService { get; set; }
        private ISettingsService SettingsService { get; set; }

        public MainForm()
        {
            InitializeComponent();

            SettingsService = new SettingsService(Path.Combine(AppContext.BaseDirectory, "app_config.json"));
            MergeService = new MergeFolderService(SettingsService.LoadSettings().MergeConfigData);
            Presenter = new MainPresenter(this, MergeService, SettingsService);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            timerLookChanges.Interval = 5000; // 5 секунд = 5000 мс
            timerLookChanges.Tick += async (s, e) => await LookTimer_TickAsync(s, e);
            timerLookChanges.Start();
            InitDataGridView();
        }

        private void InitDataGridView()
        {
            dataGridViewFileChanges.AutoGenerateColumns = false;
            dataGridViewFileChanges.Columns.Clear();
            dataGridViewFileChanges.AllowUserToAddRows = false;
            dataGridViewFileChanges.RowHeadersVisible = false;
            dataGridViewFileChanges.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewFileChanges.MultiSelect = false;

            // Колонка с текстом
            var textColumn = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Relative",
                HeaderText = "Файл",
                ReadOnly = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };
            dataGridViewFileChanges.Columns.Add(textColumn);

            // Кнопка "Открыть"
            var changesnBtn = new DataGridViewButtonColumn
            {
                HeaderText = "",
                Text = "Изменения",
                UseColumnTextForButtonValue = true,
                Name = "ChangesButton",
                Width = 90,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            };
            dataGridViewFileChanges.Columns.Add(changesnBtn);

            // Кнопка "Открыть"
            var openOutBtn = new DataGridViewButtonColumn
            {
                HeaderText = "",
                Text = "Открыть изменённую",
                UseColumnTextForButtonValue = true,
                Name = "OpenOutButton",
                Width = 150,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            };
            dataGridViewFileChanges.Columns.Add(openOutBtn);

            // Кнопка "Открыть"
            var openInBtn = new DataGridViewButtonColumn
            {
                HeaderText = "",
                Text = "Открыть эталон",
                UseColumnTextForButtonValue = true,
                Name = "OpenInButton",
                Width = 130,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            };
            dataGridViewFileChanges.Columns.Add(openInBtn);

            // Кнопка "Применить"
            var applyBtn = new DataGridViewButtonColumn
            {
                HeaderText = "",
                Text = "Применить",
                UseColumnTextForButtonValue = true,
                Name = "ApplyButton",
                Width = 90,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            };
            dataGridViewFileChanges.Columns.Add(applyBtn);

            dataGridViewFileChanges.CellClick += async (s, e) => await DataGridView1_CellClick(s, e);
        }

        private async Task DataGridView1_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // заголовки

            var grid = (DataGridView)sender;
            var item = (MergeItem)grid.Rows[e.RowIndex].DataBoundItem;
            var column = grid.Columns[e.ColumnIndex];

            if (column.Name == "OpenOutButton")
                Presenter.OpenFile(item.Full);
            if (column.Name == "OpenInButton")
                Presenter.OpenFile(item.BeforeItemPath);
            else if (column.Name == "ApplyButton")
                await Presenter.ApplyChanges(item);
            else if (column.Name == "ChangesButton")
            {
                ClearAllChangesPanel();
                await Presenter.ViewChangesAsync(item.Full, item.BeforeItemPath);
                tabControl1.SelectedIndex = 2;
            }
        }

        private void fastColoredTextBoxLeft_Scroll(object sender, ScrollEventArgs e)
        {
           
        }

        private void fastColoredTextBoxRight_Scroll(object sender, ScrollEventArgs e)
        {
            int nPos = GetScrollPos(fastColoredTextBoxRight.Handle, SB_VERT);
            SetScrollPos(fastColoredTextBoxLeft.Handle, SB_VERT, nPos, true);
            PostMessage(fastColoredTextBoxLeft.Handle, WM_VSCROLL, (IntPtr)(SB_THUMBPOSITION + 0x10000 * nPos), IntPtr.Zero);
        }

        private async Task LookTimer_TickAsync(object? sender, EventArgs e) => await Presenter.Look();

        private void buttonClearLog_Click(object sender, EventArgs e) => ClearLog();

        private void changeFileHandsToolStripMenuItem_Click(object sender, EventArgs e) => Presenter.OpenConfig();

        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
            Environment.Exit(0); // важно: завершает текущий процесс
        }

        private void ChangesStartMonitorMenuItem_Click(object sender, EventArgs e)
        {
            toolStripStatusMonitorChangesLabel.Text = "Монитор: Включён";
            timerLookChanges.Start();
        }

        private void ChangesStopMonitorMenuItem_Click(object sender, EventArgs e)
        {
            toolStripStatusMonitorChangesLabel.Text = "Монитор: Выключен";
            timerLookChanges.Stop();
        }

        private async void LookMenuItem_ClickAsync(object sender, EventArgs e) => await Presenter.Look();

        private void MergeMenuItem_Click(object sender, EventArgs e) => Presenter.Merge();

        public void SetupLeftTextFile(string text) => fastColoredTextBoxLeft.AppendText(text + Environment.NewLine);

        public void SetupRightTextFile(string text) => fastColoredTextBoxRight.AppendText(text + Environment.NewLine);

        private void prevChangeToolStripMenuItem_Click(object sender, EventArgs e) => Presenter.GoPrevChange();

        private void nextChangeToolStripMenuItem_Click(object sender, EventArgs e) => Presenter.GoNextChange();

        public void ClearAllChangesPanel()
        {
            fastColoredTextBoxLeft.Clear();
            fastColoredTextBoxRight.Clear();
        }

        public void AppendLog(string msg, bool isDate = false)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() => AppendLog(msg, isDate)));
                return;
            }
            if (isDate)
                richTextBoxLog.AppendText($"{DateTime.Now:HH:mm:ss} {msg}\n");
            else
                richTextBoxLog.AppendText($"{msg}\n");
        }

        public void ClearLog()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() => ClearLog()));
                return;
            }
            richTextBoxLog.Clear();
        }

        public void UpdateChangesBox(List<MergeItem> mergeItems)
        {
            dataGridViewFileChanges.DataSource = null;
            dataGridViewFileChanges.DataSource = mergeItems;
        }

        public void HighlightLine(bool isLeft, int lineIndex, Color color)
        {
            var rtb = isLeft ? fastColoredTextBoxLeft : fastColoredTextBoxRight;

            if (lineIndex < 0 || lineIndex >= rtb.LinesCount)
                return;

            // Применить стиль к всей строке
            rtb[lineIndex].BackgroundBrush = new SolidBrush(color);
        }

        public void GoToChange(int lineIndex)
        {
            // Переход к строке (lineIndex) — прокрутка так, чтобы строка была видна
            fastColoredTextBoxLeft.Navigate(lineIndex);
            fastColoredTextBoxRight.Navigate(lineIndex);

            // Чтобы выделить всю строку
            fastColoredTextBoxLeft.Selection.Start = new Place(0, lineIndex); // начало строки
            fastColoredTextBoxLeft.Selection.End = new Place(fastColoredTextBoxLeft[lineIndex].Count, lineIndex); // конец строки
            fastColoredTextBoxRight.Selection.Start = new Place(0, lineIndex); // начало строки
            fastColoredTextBoxRight.Selection.End = new Place(fastColoredTextBoxLeft[lineIndex].Count, lineIndex); // конец строки

            // Установить фокус
            fastColoredTextBoxLeft.Focus();
            fastColoredTextBoxRight.Focus();
        }
    }
}
