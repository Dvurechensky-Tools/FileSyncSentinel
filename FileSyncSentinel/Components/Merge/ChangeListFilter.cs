/*
 * Author: Nikolay Dvurechensky
 * Site: https://dvurechensky.pro/
 * Gmail: dvurechenskysoft@gmail.com
 * Last Updated: 28 августа 2026 07:13:46
 * Version: 1.0.302
 */

namespace FileSyncSentinel.Components
{
    public static class ChangeListFilter
    {
        public static IEnumerable<MergeItem> Filter(IEnumerable<MergeItem> items, string? searchText, string? exclusionsText)
        {
            var search = NormalizePath(searchText);
            var exclusions = SplitExclusions(exclusionsText).ToList();

            foreach (var item in items)
            {
                var relative = NormalizePath(item.Relative);

                if (!string.IsNullOrWhiteSpace(search) &&
                    !relative.Contains(search, StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                if (exclusions.Any(exclusion => IsExcluded(relative, exclusion)))
                    continue;

                yield return item;
            }
        }

        private static IEnumerable<string> SplitExclusions(string? exclusionsText)
        {
            if (string.IsNullOrWhiteSpace(exclusionsText))
                yield break;

            foreach (var exclusion in exclusionsText.Split(new[] { ';', ',', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries))
            {
                var normalized = NormalizePath(exclusion);
                if (!string.IsNullOrWhiteSpace(normalized))
                    yield return normalized;
            }
        }

        private static bool IsExcluded(string relativePath, string exclusion)
        {
            return relativePath.Equals(exclusion, StringComparison.OrdinalIgnoreCase) ||
                relativePath.StartsWith(exclusion + Path.DirectorySeparatorChar, StringComparison.OrdinalIgnoreCase);
        }

        private static string NormalizePath(string? path)
        {
            return (path ?? string.Empty)
                .Trim()
                .Trim(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar)
                .Replace(Path.AltDirectorySeparatorChar, Path.DirectorySeparatorChar);
        }
    }
}
