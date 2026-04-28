/*
 * Author: Nikolay Dvurechensky
 * Site: https://dvurechensky.pro/
 * Gmail: dvurechenskysoft@gmail.com
 * Last Updated: 28 апреля 2026 14:45:12
 * Version: 1.0.181
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
