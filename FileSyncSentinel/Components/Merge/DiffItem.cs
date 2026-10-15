/*
 * Author: Nikolay Dvurechensky
 * Site: https://dvurechensky.pro/
 * Gmail: dvurechenskysoft@gmail.com
 * Last Updated: 15 октября 2026 07:50:05
 * Version: 1.0.348
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
