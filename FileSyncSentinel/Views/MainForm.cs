/*
 * Author: Nikolay Dvurechensky
 * Site: https://dvurechensky.pro/
 * Gmail: dvurechenskysoft@gmail.com
 * Last Updated: 29 августа 2026 07:14:12
 * Version: 1.0.303
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
        private readonly List<MergeItem> _allChangeItems = new();
        private readonly List<MergeItem> _visibleChangeItems = new();
        private TextBox textBoxChangeSearch = null!;
        private TextBox textBoxChangeExclusions = null!;
        private Panel changesGridPanel = null!;

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
            InitChangeFiltersPanel();
            Resize += (s, e) => ResizeComparisonPanels();
            ResizeComparisonPanels();
        }

        private void InitDataGridView()
        {
            dataGridViewFileChanges.AutoGenerateColumns = false;
            dataGridViewFileChanges.Columns.Clear();
            dataGridViewFileChanges.AllowUserToAddRows = false;
            dataGridViewFileChanges.RowHeadersVisible = false;
            dataGridViewFileChanges.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewFileChanges.MultiSelect = false;
            dataGridViewFileChanges.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dataGridViewFileChanges.RowTemplate.Height = 30;
            dataGridViewFileChanges.ColumnHeadersHeight = 34;
            dataGridViewFileChanges.Font = new Font("Segoe UI", 10F);
            dataGridViewFileChanges.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewFileChanges.ScrollBars = ScrollBars.Both;

            // Колонка с текстом
            var textColumn = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Relative",
                HeaderText = "Файл",
                ReadOnly = true,
                MinimumWidth = 420,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 100
            };
            dataGridViewFileChanges.Columns.Add(textColumn);

            var changeTypeColumn = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ChangeType",
                HeaderText = "Тип",
                ReadOnly = true,
                Name = "ChangeTypeColumn",
                Width = 105,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            };
            dataGridViewFileChanges.Columns.Add(changeTypeColumn);

            // Кнопка "Открыть"
            var changesnBtn = new DataGridViewButtonColumn
            {
                HeaderText = "",
                Text = "Сравнить",
                UseColumnTextForButtonValue = false,
                Name = "ChangesButton",
                Width = 98,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            };
            dataGridViewFileChanges.Columns.Add(changesnBtn);

            // Кнопка "Открыть"
            var openOutBtn = new DataGridViewButtonColumn
            {
                HeaderText = "",
                Text = "Открыть изм.",
                UseColumnTextForButtonValue = false,
                Name = "OpenOutButton",
                Width = 125,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            };
            dataGridViewFileChanges.Columns.Add(openOutBtn);

            // Кнопка "Открыть"
            var openInBtn = new DataGridViewButtonColumn
            {
                HeaderText = "",
                Text = "Открыть эталон",
                UseColumnTextForButtonValue = false,
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
                UseColumnTextForButtonValue = false,
                Name = "ApplyButton",
                Width = 120,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            };
            dataGridViewFileChanges.Columns.Add(applyBtn);

            dataGridViewFileChanges.CellClick += async (s, e) => await DataGridView1_CellClick(s, e);
            dataGridViewFileChanges.CellFormatting += DataGridViewFileChanges_CellFormatting;
            dataGridViewFileChanges.RowPrePaint += DataGridViewFileChanges_RowPrePaint;
        }

        private void InitChangeFiltersPanel()
        {
            changesGridPanel = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(0)
            };

            tabPage2.Controls.Remove(dataGridViewFileChanges);
            changesGridPanel.Controls.Add(dataGridViewFileChanges);
            tabPage2.Controls.Add(changesGridPanel);
            changesGridPanel.BringToFront();

            var filterPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Top,
                Height = 48,
                ColumnCount = 4,
                RowCount = 1,
                Padding = new Padding(8, 7, 8, 6),
                BackColor = SystemColors.Control
            };
            filterPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 70));
            filterPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 45));
            filterPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 95));
            filterPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 55));

            var searchLabel = new Label
            {
                Text = "Поиск",
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft
            };
            var exclusionsLabel = new Label
            {
                Text = "Исключить",
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft
            };

            textBoxChangeSearch = new TextBox
            {
                Dock = DockStyle.Fill,
                PlaceholderText = "Файл или часть пути"
            };
            textBoxChangeExclusions = new TextBox
            {
                Dock = DockStyle.Fill,
                PlaceholderText = "Подпапка или путь; можно несколько через ;"
            };

            textBoxChangeSearch.TextChanged += (s, e) => ApplyChangeFilters();
            textBoxChangeExclusions.TextChanged += (s, e) => ApplyChangeFilters();

            filterPanel.Controls.Add(searchLabel, 0, 0);
            filterPanel.Controls.Add(textBoxChangeSearch, 1, 0);
            filterPanel.Controls.Add(exclusionsLabel, 2, 0);
            filterPanel.Controls.Add(textBoxChangeExclusions, 3, 0);

            changesGridPanel.Controls.Add(filterPanel);
            filterPanel.BringToFront();
        }

        private void DataGridViewFileChanges_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (dataGridViewFileChanges.Rows[e.RowIndex].DataBoundItem is MergeItem item)
            {
                var columnName = dataGridViewFileChanges.Columns[e.ColumnIndex].Name;

                if (columnName == "ChangeTypeColumn")
                {
                    e.Value = GetChangeTypeText(item);
                    e.FormattingApplied = true;
                }
                else if (columnName == "ApplyButton")
                {
                    e.Value = item.ChangeType == MergeChangeType.Deleted ? "Удалить" :
                        item.IsNew ? "Добавить" : "Применить";
                    e.FormattingApplied = true;
                }
                else if (columnName == "ChangesButton")
                {
                    e.Value = "Сравнить";
                    e.FormattingApplied = true;
                }
                else if (columnName == "OpenOutButton")
                {
                    e.Value = item.IsDeleted ? "Нет файла" : "Открыть изм.";
                    e.FormattingApplied = true;
                }
                else if (columnName == "OpenInButton")
                {
                    e.Value = "Открыть эталон";
                    e.FormattingApplied = true;
                }
            }
        }

        private void DataGridViewFileChanges_RowPrePaint(object? sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex < 0 || dataGridViewFileChanges.Rows[e.RowIndex].DataBoundItem is not MergeItem item)
                return;

            var color = item.ChangeType switch
            {
                MergeChangeType.Added => Color.FromArgb(224, 255, 224),
                MergeChangeType.Deleted => Color.FromArgb(255, 224, 224),
                _ => Color.FromArgb(255, 250, 205)
            };

            dataGridViewFileChanges.Rows[e.RowIndex].DefaultCellStyle.BackColor = color;
            dataGridViewFileChanges.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = ControlPaint.Dark(color);
            dataGridViewFileChanges.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.Black;
        }

        private async Task DataGridView1_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0 || sender is not DataGridView grid) return; // заголовки

            var item = (MergeItem)grid.Rows[e.RowIndex].DataBoundItem;
            var column = grid.Columns[e.ColumnIndex];

            if (column.Name == "OpenOutButton")
            {
                if (item.IsDeleted)
                {
                    AppendLog($"[!] Изменённый файл отсутствует: {item.Full}");
                    return;
                }

                Presenter.OpenFile(item.Full);
            }
            if (column.Name == "OpenInButton")
                Presenter.OpenFile(item.BeforeItemPath);
            else if (column.Name == "ApplyButton")
                await Presenter.ApplyChanges(item);
            else if (column.Name == "ChangesButton")
            {
                ClearAllChangesPanel();
                if (item.IsDeleted)
                    await Presenter.ViewChangesAsync(item.BeforeItemPath, item.Full);
                else
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

        private async void MergeMenuItem_Click(object sender, EventArgs e) => await Presenter.ApplyChanges(_visibleChangeItems.ToList());

        public void SetupLeftTextFile(string text) => fastColoredTextBoxLeft.AppendText(text + Environment.NewLine);

        public void SetupRightTextFile(string text) => fastColoredTextBoxRight.AppendText(text + Environment.NewLine);

        private void prevChangeToolStripMenuItem_Click(object sender, EventArgs e) => Presenter.GoPrevChange();

        private void nextChangeToolStripMenuItem_Click(object sender, EventArgs e) => Presenter.GoNextChange();

        public void ClearAllChangesPanel()
        {
            fastColoredTextBoxLeft.Clear();
            fastColoredTextBoxRight.Clear();
        }

        private void ResizeComparisonPanels()
        {
            var availableWidth = tabPage3.ClientSize.Width - tabPage3.Padding.Horizontal;
            if (availableWidth <= 0)
                return;

            var panelWidth = availableWidth / 2;
            fastColoredTextBoxLeft.Width = panelWidth;
            fastColoredTextBoxRight.Width = availableWidth - panelWidth;
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
            _allChangeItems.Clear();
            _allChangeItems.AddRange(mergeItems);
            ApplyChangeFilters();
        }

        private void ApplyChangeFilters()
        {
            if (textBoxChangeSearch == null || textBoxChangeExclusions == null)
                return;

            _visibleChangeItems.Clear();
            _visibleChangeItems.AddRange(ChangeListFilter.Filter(_allChangeItems, textBoxChangeSearch.Text, textBoxChangeExclusions.Text));

            dataGridViewFileChanges.DataSource = null;
            dataGridViewFileChanges.DataSource = _visibleChangeItems.ToList();
        }

        private static string GetChangeTypeText(MergeItem item)
        {
            return item.ChangeType switch
            {
                MergeChangeType.Added => "Добавление",
                MergeChangeType.Deleted => "Удаление",
                _ => "Изменение"
            };
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
