/*
 * Author: Nikolay Dvurechensky
 * Site: https://sites.google.com/view/dvurechensky
 * Gmail: dvurechenskysoft@gmail.com
 * Last Updated: 16 января 2026 06:53:19
 * Version: 1.0.77
 */


namespace FileSyncSentinel
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            richTextBoxLog = new RichTextBox();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            buttonClearLog = new Button();
            tabPage2 = new TabPage();
            dataGridViewFileChanges = new DataGridView();
            statusStrip1 = new StatusStrip();
            toolStripStatusMonitorChangesLabel = new ToolStripStatusLabel();
            menuStrip2 = new MenuStrip();
            мониторингToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem2 = new ToolStripMenuItem();
            остановкаToolStripMenuItem = new ToolStripMenuItem();
            ручноеСканированиеToolStripMenuItem = new ToolStripMenuItem();
            измененияToolStripMenuItem = new ToolStripMenuItem();
            применитьВсеToolStripMenuItem = new ToolStripMenuItem();
            listBoxChanges = new ListBox();
            tabPage3 = new TabPage();
            fastColoredTextBoxRight = new FastColoredTextBoxNS.FastColoredTextBox();
            fastColoredTextBoxLeft = new FastColoredTextBoxNS.FastColoredTextBox();
            menuStrip3 = new MenuStrip();
            prevChangeToolStripMenuItem = new ToolStripMenuItem();
            nextChangeToolStripMenuItem = new ToolStripMenuItem();
            timerLookChanges = new System.Windows.Forms.Timer(components);
            menuStrip1 = new MenuStrip();
            настройкиToolStripMenuItem = new ToolStripMenuItem();
            configChangeToolStripMenuItem = new ToolStripMenuItem();
            changeFileHandsToolStripMenuItem = new ToolStripMenuItem();
            restartToolStripMenuItem = new ToolStripMenuItem();
            contextMenuStrip1 = new ContextMenuStrip(components);
            contextMenuStrip2 = new ContextMenuStrip(components);
            toolStripMenuItem1 = new ToolStripMenuItem();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewFileChanges).BeginInit();
            statusStrip1.SuspendLayout();
            menuStrip2.SuspendLayout();
            tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)fastColoredTextBoxRight).BeginInit();
            ((System.ComponentModel.ISupportInitialize)fastColoredTextBoxLeft).BeginInit();
            menuStrip3.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // richTextBoxLog
            // 
            richTextBoxLog.BackColor = SystemColors.ButtonFace;
            richTextBoxLog.BorderStyle = BorderStyle.None;
            richTextBoxLog.Dock = DockStyle.Fill;
            richTextBoxLog.Font = new Font("Britannic Bold", 15.75F);
            richTextBoxLog.Location = new Point(3, 3);
            richTextBoxLog.Name = "richTextBoxLog";
            richTextBoxLog.Size = new Size(970, 603);
            richTextBoxLog.TabIndex = 0;
            richTextBoxLog.Text = "";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 24);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(984, 637);
            tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(buttonClearLog);
            tabPage1.Controls.Add(richTextBoxLog);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(976, 609);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Журнал";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // buttonClearLog
            // 
            buttonClearLog.BackColor = SystemColors.ButtonHighlight;
            buttonClearLog.Font = new Font("Arial", 15.75F, FontStyle.Bold);
            buttonClearLog.ImeMode = ImeMode.NoControl;
            buttonClearLog.Location = new Point(8, 566);
            buttonClearLog.Name = "buttonClearLog";
            buttonClearLog.Size = new Size(118, 37);
            buttonClearLog.TabIndex = 2;
            buttonClearLog.Text = "Очистить";
            buttonClearLog.UseVisualStyleBackColor = false;
            buttonClearLog.Click += buttonClearLog_Click;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(dataGridViewFileChanges);
            tabPage2.Controls.Add(statusStrip1);
            tabPage2.Controls.Add(menuStrip2);
            tabPage2.Controls.Add(listBoxChanges);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(976, 609);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Изменения";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridViewFileChanges
            // 
            dataGridViewFileChanges.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewFileChanges.Dock = DockStyle.Fill;
            dataGridViewFileChanges.Location = new Point(3, 3);
            dataGridViewFileChanges.Name = "dataGridViewFileChanges";
            dataGridViewFileChanges.Size = new Size(970, 550);
            dataGridViewFileChanges.TabIndex = 7;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusMonitorChangesLabel });
            statusStrip1.Location = new Point(3, 553);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(970, 24);
            statusStrip1.TabIndex = 5;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusMonitorChangesLabel
            // 
            toolStripStatusMonitorChangesLabel.Font = new Font("Unispace", 11.9999981F, FontStyle.Bold);
            toolStripStatusMonitorChangesLabel.Name = "toolStripStatusMonitorChangesLabel";
            toolStripStatusMonitorChangesLabel.Size = new Size(146, 19);
            toolStripStatusMonitorChangesLabel.Text = "Монитор: Включён";
            // 
            // menuStrip2
            // 
            menuStrip2.Dock = DockStyle.Bottom;
            menuStrip2.Font = new Font("Roboto Medium", 12F, FontStyle.Bold);
            menuStrip2.Items.AddRange(new ToolStripItem[] { мониторингToolStripMenuItem, измененияToolStripMenuItem });
            menuStrip2.Location = new Point(3, 577);
            menuStrip2.Name = "menuStrip2";
            menuStrip2.Size = new Size(970, 29);
            menuStrip2.TabIndex = 6;
            menuStrip2.Text = "menuStrip2";
            // 
            // мониторингToolStripMenuItem
            // 
            мониторингToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItem2, остановкаToolStripMenuItem, ручноеСканированиеToolStripMenuItem });
            мониторингToolStripMenuItem.Name = "мониторингToolStripMenuItem";
            мониторингToolStripMenuItem.Size = new Size(124, 25);
            мониторингToolStripMenuItem.Text = "Мониторинг";
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(269, 26);
            toolStripMenuItem2.Text = "Запуск";
            toolStripMenuItem2.Click += ChangesStartMonitorMenuItem_Click;
            // 
            // остановкаToolStripMenuItem
            // 
            остановкаToolStripMenuItem.Name = "остановкаToolStripMenuItem";
            остановкаToolStripMenuItem.Size = new Size(269, 26);
            остановкаToolStripMenuItem.Text = "Остановка";
            остановкаToolStripMenuItem.Click += ChangesStopMonitorMenuItem_Click;
            // 
            // ручноеСканированиеToolStripMenuItem
            // 
            ручноеСканированиеToolStripMenuItem.Name = "ручноеСканированиеToolStripMenuItem";
            ручноеСканированиеToolStripMenuItem.Size = new Size(269, 26);
            ручноеСканированиеToolStripMenuItem.Text = "Ручное сканирование";
            ручноеСканированиеToolStripMenuItem.Click += LookMenuItem_ClickAsync;
            // 
            // измененияToolStripMenuItem
            // 
            измененияToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { применитьВсеToolStripMenuItem });
            измененияToolStripMenuItem.Name = "измененияToolStripMenuItem";
            измененияToolStripMenuItem.Size = new Size(116, 25);
            измененияToolStripMenuItem.Text = "Изменения";
            // 
            // применитьВсеToolStripMenuItem
            // 
            применитьВсеToolStripMenuItem.Name = "применитьВсеToolStripMenuItem";
            применитьВсеToolStripMenuItem.Size = new Size(213, 26);
            применитьВсеToolStripMenuItem.Text = "Применить все";
            применитьВсеToolStripMenuItem.Click += MergeMenuItem_Click;
            // 
            // listBoxChanges
            // 
            listBoxChanges.Dock = DockStyle.Fill;
            listBoxChanges.Font = new Font("Arial", 15.75F, FontStyle.Bold);
            listBoxChanges.FormattingEnabled = true;
            listBoxChanges.ItemHeight = 24;
            listBoxChanges.Location = new Point(3, 3);
            listBoxChanges.Name = "listBoxChanges";
            listBoxChanges.Size = new Size(970, 603);
            listBoxChanges.TabIndex = 0;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(fastColoredTextBoxRight);
            tabPage3.Controls.Add(fastColoredTextBoxLeft);
            tabPage3.Controls.Add(menuStrip3);
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(976, 609);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Панель сравнения";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // fastColoredTextBoxRight
            // 
            fastColoredTextBoxRight.AutoCompleteBracketsList = new char[]
    {
    '(',
    ')',
    '{',
    '}',
    '[',
    ']',
    '"',
    '"',
    '\'',
    '\''
    };
            fastColoredTextBoxRight.AutoIndentCharsPatterns = "^\\s*[\\w\\.]+(\\s\\w+)?\\s*(?<range>=)\\s*(?<range>[^;=]+);\r\n^\\s*(case|default)\\s*[^:]*(?<range>:)\\s*(?<range>[^;]+);";
            fastColoredTextBoxRight.AutoScrollMinSize = new Size(27, 14);
            fastColoredTextBoxRight.BackBrush = null;
            fastColoredTextBoxRight.CharHeight = 14;
            fastColoredTextBoxRight.CharWidth = 8;
            fastColoredTextBoxRight.DefaultMarkerSize = 8;
            fastColoredTextBoxRight.DisabledColor = Color.FromArgb(100, 180, 180, 180);
            fastColoredTextBoxRight.Dock = DockStyle.Right;
            fastColoredTextBoxRight.IsReplaceMode = false;
            fastColoredTextBoxRight.Location = new Point(473, 27);
            fastColoredTextBoxRight.Name = "fastColoredTextBoxRight";
            fastColoredTextBoxRight.Paddings = new Padding(0);
            fastColoredTextBoxRight.SelectionColor = Color.FromArgb(60, 0, 0, 255);
            fastColoredTextBoxRight.ServiceColors = (FastColoredTextBoxNS.ServiceColors)resources.GetObject("fastColoredTextBoxRight.ServiceColors");
            fastColoredTextBoxRight.Size = new Size(500, 579);
            fastColoredTextBoxRight.TabIndex = 0;
            fastColoredTextBoxRight.Zoom = 100;
            fastColoredTextBoxRight.Scroll += fastColoredTextBoxRight_Scroll;
            // 
            // fastColoredTextBoxLeft
            // 
            fastColoredTextBoxLeft.AutoCompleteBracketsList = new char[]
    {
    '(',
    ')',
    '{',
    '}',
    '[',
    ']',
    '"',
    '"',
    '\'',
    '\''
    };
            fastColoredTextBoxLeft.AutoIndentCharsPatterns = "^\\s*[\\w\\.]+(\\s\\w+)?\\s*(?<range>=)\\s*(?<range>[^;=]+);\r\n^\\s*(case|default)\\s*[^:]*(?<range>:)\\s*(?<range>[^;]+);";
            fastColoredTextBoxLeft.AutoScrollMinSize = new Size(27, 14);
            fastColoredTextBoxLeft.BackBrush = null;
            fastColoredTextBoxLeft.CharHeight = 14;
            fastColoredTextBoxLeft.CharWidth = 8;
            fastColoredTextBoxLeft.DefaultMarkerSize = 8;
            fastColoredTextBoxLeft.DisabledColor = Color.FromArgb(100, 180, 180, 180);
            fastColoredTextBoxLeft.Dock = DockStyle.Left;
            fastColoredTextBoxLeft.IsReplaceMode = false;
            fastColoredTextBoxLeft.Location = new Point(3, 27);
            fastColoredTextBoxLeft.Name = "fastColoredTextBoxLeft";
            fastColoredTextBoxLeft.Paddings = new Padding(0);
            fastColoredTextBoxLeft.SelectionColor = Color.FromArgb(60, 0, 0, 255);
            fastColoredTextBoxLeft.ServiceColors = (FastColoredTextBoxNS.ServiceColors)resources.GetObject("fastColoredTextBoxLeft.ServiceColors");
            fastColoredTextBoxLeft.Size = new Size(500, 579);
            fastColoredTextBoxLeft.TabIndex = 1;
            fastColoredTextBoxLeft.Zoom = 100;
            fastColoredTextBoxLeft.Scroll += fastColoredTextBoxLeft_Scroll;
            // 
            // menuStrip3
            // 
            menuStrip3.Items.AddRange(new ToolStripItem[] { prevChangeToolStripMenuItem, nextChangeToolStripMenuItem });
            menuStrip3.Location = new Point(3, 3);
            menuStrip3.Name = "menuStrip3";
            menuStrip3.Size = new Size(970, 24);
            menuStrip3.TabIndex = 2;
            menuStrip3.Text = "menuStrip3";
            // 
            // prevChangeToolStripMenuItem
            // 
            prevChangeToolStripMenuItem.Font = new Font("Segoe UI", 12F);
            prevChangeToolStripMenuItem.Image = Properties.Resources.left;
            prevChangeToolStripMenuItem.Name = "prevChangeToolStripMenuItem";
            prevChangeToolStripMenuItem.Size = new Size(28, 20);
            prevChangeToolStripMenuItem.Click += prevChangeToolStripMenuItem_Click;
            // 
            // nextChangeToolStripMenuItem
            // 
            nextChangeToolStripMenuItem.Font = new Font("Segoe UI", 12F);
            nextChangeToolStripMenuItem.Image = Properties.Resources.right;
            nextChangeToolStripMenuItem.ImageAlign = ContentAlignment.TopLeft;
            nextChangeToolStripMenuItem.Name = "nextChangeToolStripMenuItem";
            nextChangeToolStripMenuItem.Size = new Size(28, 20);
            nextChangeToolStripMenuItem.Click += nextChangeToolStripMenuItem_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { настройкиToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(984, 24);
            menuStrip1.TabIndex = 4;
            menuStrip1.Text = "menuStrip1";
            // 
            // настройкиToolStripMenuItem
            // 
            настройкиToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { configChangeToolStripMenuItem, restartToolStripMenuItem });
            настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
            настройкиToolStripMenuItem.Size = new Size(79, 20);
            настройкиToolStripMenuItem.Text = "Настройки";
            // 
            // configChangeToolStripMenuItem
            // 
            configChangeToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { changeFileHandsToolStripMenuItem, toolStripMenuItem1 });
            configChangeToolStripMenuItem.Name = "configChangeToolStripMenuItem";
            configChangeToolStripMenuItem.Size = new Size(180, 22);
            configChangeToolStripMenuItem.Text = "Конфигурация";
            // 
            // changeFileHandsToolStripMenuItem
            // 
            changeFileHandsToolStripMenuItem.Name = "changeFileHandsToolStripMenuItem";
            changeFileHandsToolStripMenuItem.Size = new Size(180, 22);
            changeFileHandsToolStripMenuItem.Text = "Изменить файл";
            changeFileHandsToolStripMenuItem.Click += changeFileHandsToolStripMenuItem_Click;
            // 
            // restartToolStripMenuItem
            // 
            restartToolStripMenuItem.Name = "restartToolStripMenuItem";
            restartToolStripMenuItem.Size = new Size(180, 22);
            restartToolStripMenuItem.Text = "Перезапуск";
            restartToolStripMenuItem.Click += restartToolStripMenuItem_Click;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // contextMenuStrip2
            // 
            contextMenuStrip2.Name = "contextMenuStrip2";
            contextMenuStrip2.Size = new Size(61, 4);
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(180, 22);
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 661);
            Controls.Add(tabControl1);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            MaximizeBox = false;
            MaximumSize = new Size(1000, 700);
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            MinimumSize = new Size(1000, 700);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Монитор изменений в папках";
            Load += MainForm_Load;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewFileChanges).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            menuStrip2.ResumeLayout(false);
            menuStrip2.PerformLayout();
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)fastColoredTextBoxRight).EndInit();
            ((System.ComponentModel.ISupportInitialize)fastColoredTextBoxLeft).EndInit();
            menuStrip3.ResumeLayout(false);
            menuStrip3.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox richTextBoxLog;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private ListBox listBoxChanges;
        private Button buttonClearLog;
        private System.Windows.Forms.Timer timerLookChanges;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem настройкиToolStripMenuItem;
        private ToolStripMenuItem configChangeToolStripMenuItem;
        private ToolStripMenuItem changeFileHandsToolStripMenuItem;
        private ToolStripMenuItem restartToolStripMenuItem;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusMonitorChangesLabel;
        private MenuStrip menuStrip2;
        private ContextMenuStrip contextMenuStrip1;
        private ContextMenuStrip contextMenuStrip2;
        private ToolStripMenuItem мониторингToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem2;
        private ToolStripMenuItem остановкаToolStripMenuItem;
        private ToolStripMenuItem ручноеСканированиеToolStripMenuItem;
        private ToolStripMenuItem измененияToolStripMenuItem;
        private ToolStripMenuItem применитьВсеToolStripMenuItem;
        private TabPage tabPage3;
        private FastColoredTextBoxNS.FastColoredTextBox fastColoredTextBoxLeft;
        private FastColoredTextBoxNS.FastColoredTextBox fastColoredTextBoxRight;
        private MenuStrip menuStrip3;
        private ToolStripMenuItem nextChangeToolStripMenuItem;
        private ToolStripMenuItem prevChangeToolStripMenuItem;
        private DataGridView dataGridViewFileChanges;
        private ToolStripMenuItem toolStripMenuItem1;
    }
}
