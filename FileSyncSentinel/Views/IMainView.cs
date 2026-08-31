/*
 * Author: Nikolay Dvurechensky
 * Site: https://dvurechensky.pro/
 * Gmail: dvurechenskysoft@gmail.com
 * Last Updated: 31 августа 2026 07:10:02
 * Version: 1.0.304
 */


using FileSyncSentinel.Components;

namespace FileSyncSentinel.Views
{
    public interface IMainView
    {
        void AppendLog(string msg, bool isDate = false);
        void ClearLog();
        void UpdateChangesBox(List<MergeItem> mergeItems);
        void SetupLeftTextFile(string text);
        void SetupRightTextFile(string text);
        void HighlightLine(bool isLeft, int lineIndex, Color color);
        void GoToChange(int lineIndex);
    }
}
