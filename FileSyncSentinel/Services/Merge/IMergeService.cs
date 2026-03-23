/*
 * Author: Nikolay Dvurechensky
 * Site: https://dvurechensky.pro/
 * Gmail: dvurechenskysoft@gmail.com
 * Last Updated: 23 марта 2026 13:11:48
 * Version: 1.0.143
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
