/*
 * Author: Nikolay Dvurechensky
 * Site: https://dvurechensky.pro/
 * Gmail: dvurechenskysoft@gmail.com
 * Last Updated: 11 сентября 2026 06:58:32
 * Version: 1.0.315
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
