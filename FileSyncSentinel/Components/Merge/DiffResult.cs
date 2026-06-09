/*
 * Author: Nikolay Dvurechensky
 * Site: https://dvurechensky.pro/
 * Gmail: dvurechenskysoft@gmail.com
 * Last Updated: 09 июня 2026 17:14:12
 * Version: 1.0.222
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
