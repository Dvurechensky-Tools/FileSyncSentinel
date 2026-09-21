/*
 * Author: Nikolay Dvurechensky
 * Site: https://dvurechensky.pro/
 * Gmail: dvurechenskysoft@gmail.com
 * Last Updated: 21 сентября 2026 09:41:10
 * Version: 1.0.325
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
