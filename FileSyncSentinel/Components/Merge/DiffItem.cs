/*
 * Author: Nikolay Dvurechensky
 * Site: https://dvurechensky.pro/
 * Gmail: dvurechenskysoft@gmail.com
 * Last Updated: 23 марта 2026 13:11:48
 * Version: 1.0.143
 */

using DiffPlex.DiffBuilder.Model;

namespace FileSyncSentinel.Components
{
    public class DiffItem
    {
        public DiffItem (int line, ChangeType changeType)
        {
            LineIndex = line;
            ChangeType = changeType;
        }
        public int LineIndex { get; set; }
        public ChangeType ChangeType { get; set; }
    }
}
