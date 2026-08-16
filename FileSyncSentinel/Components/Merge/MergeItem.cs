/*
 * Author: Nikolay Dvurechensky
 * Site: https://dvurechensky.pro/
 * Gmail: dvurechenskysoft@gmail.com
 * Last Updated: 16 августа 2026 14:47:50
 * Version: 1.0.289
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
