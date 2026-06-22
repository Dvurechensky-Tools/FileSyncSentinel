/*
 * Author: Nikolay Dvurechensky
 * Site: https://dvurechensky.pro/
 * Gmail: dvurechenskysoft@gmail.com
 * Last Updated: 22 июня 2026 07:14:57
 * Version: 1.0.235
 */

namespace FileSyncSentinel.Components
{
    public class MergeItem
    {
        public MergeItem(string relative, string full)
        {
            this.Relative = relative;
            this.Full = full;
        }

        public string Relative {  get; set; }
        public string Full {  get; set; }
        public string BeforeItemPath { get; set; }
    }
}
