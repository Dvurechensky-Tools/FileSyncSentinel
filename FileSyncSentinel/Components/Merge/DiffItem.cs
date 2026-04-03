/*
 * Author: Nikolay Dvurechensky
 * Site: https://dvurechensky.pro/
 * Gmail: dvurechenskysoft@gmail.com
 * Last Updated: 03 апреля 2026 11:47:56
 * Version: 1.0.154
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
