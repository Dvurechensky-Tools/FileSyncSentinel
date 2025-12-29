/*
 * Author: Nikolay Dvurechensky
 * Site: https://sites.google.com/view/dvurechensky
 * Gmail: dvurechenskysoft@gmail.com
 * Last Updated: 29 декабря 2025 09:59:41
 * Version: 1.0.59
 */

using FileSyncSentinel.Components;

namespace FileSyncSentinel.Services
{
    public interface IMergeService
    {
        int CurrentDiffIndex { get; set; }
        List<int> ChangedLines { get; set; }

        public event EventHandler<string> UpdateLogEvent;
        List<MergeItem> LookChangesFiles();
        Task<DiffResult> ViewChangesAsync(string fileA, string fileB);
        void Merge();
        bool MergeSingleFile(string outFilePath, string inFilePath);
    }
}
