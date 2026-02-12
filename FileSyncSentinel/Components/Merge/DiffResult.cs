/*
 * Author: Nikolay Dvurechensky
 * Site: https://sites.google.com/view/dvurechensky
 * Gmail: dvurechenskysoft@gmail.com
 * Last Updated: 12 февраля 2026 10:34:25
 * Version: 1.0.104
 */

using System.Text;

namespace FileSyncSentinel.Components
{
    public class DiffResult
    {
        public DiffResult(StringBuilder sbLeft, StringBuilder sbRight, List<DiffItem> diffs)
        {
            SbLeft = sbLeft;
            SbRight = sbRight;
            DiffResults = diffs;
        }

        public List<DiffItem> DiffResults { get; set; } = new List<DiffItem>();
        public StringBuilder SbLeft { get; set; }
        public StringBuilder SbRight { get; set; }
    }
}
