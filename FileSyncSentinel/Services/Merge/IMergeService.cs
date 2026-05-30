/*
 * Author: Nikolay Dvurechensky
 * Site: https://dvurechensky.pro/
 * Gmail: dvurechenskysoft@gmail.com
 * Last Updated: 30 мая 2026 16:02:02
 * Version: 1.0.212
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
