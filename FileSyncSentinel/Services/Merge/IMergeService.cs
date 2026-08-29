/*
 * Author: Nikolay Dvurechensky
 * Site: https://dvurechensky.pro/
 * Gmail: dvurechenskysoft@gmail.com
 * Last Updated: 29 августа 2026 07:14:12
 * Version: 1.0.303
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
        bool ApplyChange(MergeItem item);
        int ApplyChanges(IEnumerable<MergeItem> items);
    }
}
