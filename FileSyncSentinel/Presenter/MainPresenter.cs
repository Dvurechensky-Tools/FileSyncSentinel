/*
 * Author: Nikolay Dvurechensky
 * Site: https://sites.google.com/view/dvurechensky
 * Gmail: dvurechenskysoft@gmail.com
 * Last Updated: 17 декабря 2025 15:26:30
 * Version: 1.0.47
 */



using System.Diagnostics;
using System.Text;

using DiffPlex.DiffBuilder.Model;
using DiffPlex.DiffBuilder;
using DiffPlex;

using FileSyncSentinel.Components;
using FileSyncSentinel.Services;
using FileSyncSentinel.Services.Settings;
using FileSyncSentinel.Views;
using System.Threading.Tasks;

namespace FileSyncSentinel.Presenter
{
    public class MainPresenter
    {
        private readonly IMainView view;
        private IMergeService MergeService { get; set; }
        public ISettingsService SettingsService { get; set; }

        public MainPresenter(IMainView main, IMergeService mergeService,
            ISettingsService settingsService) 
        {
            view = main;
            MergeService = mergeService;
            SettingsService = settingsService;

            MergeService.UpdateLogEvent += MergeService_UpdateLogEvent;
        }

        private void MergeService_UpdateLogEvent(object? sender, string e)
        {
            view.AppendLog(e);
        }

        /// <summary>
        /// Объединяет изменения из Out папки в In
        /// </summary>
        public void Merge()
        {
            MergeService.Merge();
        }

        /// <summary>
        /// Применить изменения для еденичного файла 
        /// из Out item.FullPath (Папка с файлами Out) в In item.BeforeItemPath (Папка с файлами In)
        /// </summary>
        /// <param name="item"></param>
        public async Task ApplyChanges(MergeItem item)
        {
            bool state = MergeService.MergeSingleFile(item.Full, item.BeforeItemPath);
            if (state) await Look();
        }

        /// <summary>
        /// Принудительно проверяет различия между папками
        /// </summary>
        public async Task Look()
        {
            List<MergeItem> changes = new List<MergeItem>();
            await Task.Run(() =>
            {
                changes = MergeService.LookChangesFiles();
            });
            view.UpdateChangesBox(changes);
        }

        public void OpenFile(string path)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = path,
                UseShellExecute = true // обязательно для открытия через ассоциации Windows
            });
        }

        public void OpenConfig()
        {
            OpenFile(SettingsService.ConfigPath);
        }

        public async Task ViewChangesAsync(string fileA, string fileB)
        {
            var diffs = await MergeService.ViewChangesAsync(fileA, fileB);

            view.SetupLeftTextFile(diffs.SbLeft.ToString());
            view.SetupRightTextFile(diffs.SbRight.ToString());

            foreach (var item in diffs.DiffResults)
            {
                if (item.ChangeType == ChangeType.Deleted)
                {
                    view.HighlightLine(true, item.LineIndex, Color.LightCyan);   // цвет для удалённых (левая панель)
                                                                             // на правой панели удалённой строки нет, поэтому подсвечивать не нужно
                }
                else if (item.ChangeType == ChangeType.Inserted)
                {
                    // цвет для вставленных (правая панель)
                    view.HighlightLine(false, item.LineIndex, Color.LightGreen);
                    // на левой панели вставленных строк нет, поэтому подсвечивать не нужно
                }
                else if (item.ChangeType == ChangeType.Modified)
                {
                    // Если есть, цвет для изменённых строк
                    view.HighlightLine(true, item.LineIndex, Color.LightYellow);
                    view.HighlightLine(false, item.LineIndex, Color.LightYellow);
                }
            }
        }

        public void GoPrevChange()
        {
            if (MergeService.ChangedLines.Count == 0) return;

            MergeService.CurrentDiffIndex--;
            if (MergeService.CurrentDiffIndex < 0)
                MergeService.CurrentDiffIndex = MergeService.ChangedLines.Count - 1; // зациклить

            view.GoToChange(MergeService.ChangedLines[MergeService.CurrentDiffIndex]);
        }

        public void GoNextChange()
        {
            if (MergeService.ChangedLines.Count == 0) return;

            MergeService.CurrentDiffIndex++;
            if (MergeService.CurrentDiffIndex >= MergeService.ChangedLines.Count)
                MergeService.CurrentDiffIndex = 0; // зациклить

            view.GoToChange(MergeService.ChangedLines[MergeService.CurrentDiffIndex]);
        }
    }
}
