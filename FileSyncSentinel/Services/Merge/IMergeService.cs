/*
 * Author: Nikolay Dvurechensky
 * Site: https://sites.google.com/view/dvurechensky
 * Gmail: dvurechenskysoft@gmail.com
 * Last Updated: 28 января 2026 06:53:28
 * Version: 1.0.89
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
