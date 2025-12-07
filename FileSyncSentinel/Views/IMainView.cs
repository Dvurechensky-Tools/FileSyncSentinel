/*
 * Author: Nikolay Dvurechensky
 * Site: https://sites.google.com/view/dvurechensky
 * Gmail: dvurechenskysoft@gmail.com
 * Last Updated: 07 декабря 2025 12:58:10
 * Version: 1.0.37
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
