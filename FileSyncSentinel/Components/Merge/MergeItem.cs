/*
 * Author: Nikolay Dvurechensky
 * Site: https://dvurechensky.pro/
 * Gmail: dvurechenskysoft@gmail.com
 * Last Updated: 29 августа 2026 07:14:12
 * Version: 1.0.303
 */

namespace FileSyncSentinel.Components
{
    public enum MergeChangeType
    {
        Modified,
        Added,
        Deleted
    }

    public class MergeItem
    {
        public MergeItem(string relative, string full)
        {
            this.Relative = relative;
            this.Full = full;
        }

        public string Relative {  get; set; }
        public string Full {  get; set; }
        public string BeforeItemPath { get; set; } = string.Empty;
        public MergeChangeType ChangeType { get; set; } = MergeChangeType.Modified;
        public bool IsNew
        {
            get => ChangeType == MergeChangeType.Added;
            set
            {
                if (value)
                    ChangeType = MergeChangeType.Added;
            }
        }
        public bool IsDeleted => ChangeType == MergeChangeType.Deleted;
    }
}
