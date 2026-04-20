/*
 * Author: Nikolay Dvurechensky
 * Site: https://dvurechensky.pro/
 * Gmail: dvurechenskysoft@gmail.com
 * Last Updated: 20 апреля 2026 03:23:27
 * Version: 1.0.172
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
