/*
 * Author: Nikolay Dvurechensky
 * Site: https://sites.google.com/view/dvurechensky
 * Gmail: dvurechenskysoft@gmail.com
 * Last Updated: 01 февраля 2026 06:53:24
 * Version: 1.0.93
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
