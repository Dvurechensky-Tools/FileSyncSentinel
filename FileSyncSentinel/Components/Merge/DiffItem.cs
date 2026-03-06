/*
 * Author: Nikolay Dvurechensky
 * Site: https://sites.google.com/view/dvurechensky
 * Gmail: dvurechenskysoft@gmail.com
 * Last Updated: 06 марта 2026 06:53:38
 * Version: 1.0.126
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
