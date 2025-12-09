/*
 * Author: Nikolay Dvurechensky
 * Site: https://sites.google.com/view/dvurechensky
 * Gmail: dvurechenskysoft@gmail.com
 * Last Updated: 09 декабря 2025 13:34:53
 * Version: 1.0.39
 */


using System.Security.Cryptography;
using System.Text;

using DiffPlex;
using DiffPlex.DiffBuilder;
using DiffPlex.DiffBuilder.Model;

using FileSyncSentinel.Components;

namespace FileSyncSentinel.Services
{
    public class MergeFolderService : IMergeService
    {
        public event EventHandler<string> UpdateLogEvent;
        public MergeConfigData MergeConfigData { get; set; }
        private readonly Dictionary<string, DateTime> _changeCache = new();
        /// <summary>
        /// Индексы изменённых строк (например, по левой панели)
        /// </summary>
        public List<int> ChangedLines { get; set; } = new List<int>();
        /// <summary>
        /// Текущий индекс выбранного изменения
        /// </summary>
        public int CurrentDiffIndex { get; set; } = -1;

        public MergeFolderService(MergeConfigData configData) 
        {
            MergeConfigData = configData;
            InitWatcher();
        }

        public List<MergeItem> LookChangesFiles()
        {
            InitFiles();

            var differentFiles = new List<MergeItem>();
            try
            {
                foreach (var outFile in MergeConfigData.OutFiles)
                {
                    if (!MergeConfigData.InFiles.TryGetValue(outFile.Key, out string inFilePath))
                        continue; // нет такого файла в оригинале

                    if (!File.Exists(inFilePath))
                        continue;
                    if (!File.Exists(outFile.Value))
                        continue;

                    // Первый уровень: длина
                    var inInfo = new FileInfo(inFilePath);
                    var outInfo = new FileInfo(outFile.Value);
                    if (inInfo.Length != outInfo.Length)
                    {
                        differentFiles.Add(new MergeItem(outFile.Key, outFile.Value) { BeforeItemPath = inFilePath });
                        continue;
                    }

                    // Второй уровень (опционально): быстрый хеш
                    if (ComputeFastHash(inFilePath) != ComputeFastHash(outFile.Value))
                    {
                        differentFiles.Add(new MergeItem(outFile.Key, outFile.Value) { BeforeItemPath = inFilePath });
                    }
                }
            }
            catch (Exception ex) { }
            finally { }
            return differentFiles;
        }

        /// <summary>
        /// Инициализация наблюдателя в реальном времени за папкой
        /// </summary>
        private void InitWatcher()
        {
            if (!MergeConfigData.IsValid) return;


            MergeConfigData.FilesWatcher = new FileSystemWatcher(MergeConfigData.PathOut, 
                MergeConfigData.TypeFiles);
            MergeConfigData.FilesWatcher.IncludeSubdirectories = true;
            MergeConfigData.FilesWatcher.NotifyFilter = NotifyFilters.LastWrite;
            MergeConfigData.FilesWatcher.Changed += OnIniFileChanged;
            MergeConfigData.FilesWatcher.EnableRaisingEvents = true;
        }

        private void InitFiles()
        {
            if (!MergeConfigData.IsValid) return;

            MergeConfigData.InFiles = Directory.GetFiles(MergeConfigData.PathIn, MergeConfigData.TypeFiles, SearchOption.AllDirectories)
               .Select(p => (Relative: Path.GetRelativePath(MergeConfigData.PathIn, p), Full: p))
               .ToDictionary(x => x.Relative, x => x.Full);

            MergeConfigData.OutFiles = Directory.GetFiles(MergeConfigData.PathOut, MergeConfigData.TypeFiles, SearchOption.AllDirectories)
                .Select(p => (Relative: Path.GetRelativePath(MergeConfigData.PathOut, p), Full: p))
                .ToDictionary(x => x.Relative, x => x.Full); ;
        }

        /// <summary>
        /// Событие изменения файла
        /// </summary>
        private void OnIniFileChanged(object sender, FileSystemEventArgs e)
        {
            if (!MergeConfigData.IsValid) return;

            string path = e.FullPath;
            lock (_changeCache)
            {
                if (_changeCache.TryGetValue(path, out var lastTime))
                {
                    if ((DateTime.Now - lastTime).TotalMilliseconds < 500)
                        return; // Игнорируем повтор
                }
                _changeCache[path] = DateTime.Now;
            }

            Task.Run(() =>
            {
                try
                {
                    string relativePath = Path.GetRelativePath(MergeConfigData.PathOut, e.FullPath);
                    string iniFilePath = Path.Combine(MergeConfigData.PathIn, relativePath);

                    if (!File.Exists(iniFilePath))
                    {
                        UpdateLogEvent?.Invoke(this, $"[+] Новый файл: {relativePath}");
                        return;
                    }

                    string gameContent = SafeReadAllTextWithRetry(e.FullPath);
                    string iniContent = SafeReadAllTextWithRetry(iniFilePath);

                    if (gameContent != iniContent)
                    {
                        UpdateLogEvent?.Invoke(this, $"[!] Изменения в: {relativePath}");
                        UpdateLogEvent?.Invoke(this, $"   --> Отличия найдены");
                    }
                }
                catch (Exception ex)
                {
                    UpdateLogEvent?.Invoke(this, $"[X] Ошибка при сравнении: {ex.Message}");
                }
            });
        }

        private string SafeReadAllTextWithRetry(string path, int maxRetries = 5, int delayMs = 100)
        {
            for (int i = 0; i < maxRetries; i++)
            {
                try
                {
                    using var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                    using var sr = new StreamReader(fs);
                    return sr.ReadToEnd();
                }
                catch (IOException)
                {
                    Thread.Sleep(delayMs);
                }
            }

            throw new IOException($"Файл \"{path}\" занят другим процессом после {maxRetries} попыток.");
        }

        public void Merge()
        {
            if (!MergeConfigData.IsValid) return;

            foreach (string outFile in Directory.GetFiles(MergeConfigData.PathOut, "*.ini", SearchOption.AllDirectories))
            {
                string relativePath = Path.GetRelativePath(MergeConfigData.PathOut, outFile);
                string inFile = Path.Combine(MergeConfigData.PathIn, relativePath);

                if (!File.Exists(inFile))
                {
                    // Не копируем — файла нет в папке In
                    continue;
                }

                if (!CompareFiles(outFile, inFile))
                {
                    // Пропускаем одинаковые
                    continue;
                }

                File.Copy(outFile, inFile, true);
                UpdateLogEvent.Invoke(this, $"[✓] Обновлён: {relativePath}");
            }
        }

        public bool MergeSingleFile(string outFilePath, string inFilePath)
        {
            if (!File.Exists(outFilePath))
            {
                UpdateLogEvent?.Invoke(this, $"[!] Out-файл не найден: {outFilePath}");
                return false;
            }

            if (!File.Exists(inFilePath))
            {
                // Если in-файла нет, просто копируем
                File.Copy(outFilePath, inFilePath, true);
                UpdateLogEvent?.Invoke(this, $"[+] Скопирован новый файл: {inFilePath}");
                return true;
            }
           
            // Файлы разные — копируем
            File.Copy(outFilePath, inFilePath, true);
            UpdateLogEvent?.Invoke(this, $"[✓] Обновлён файл: {inFilePath}");
            return true;
        }

        public async Task<DiffResult> ViewChangesAsync(string fileA, string fileB)
        {
            var textA = await File.ReadAllTextAsync(fileA);
            var textB = await File.ReadAllTextAsync(fileB);

            var diffBuilder = new InlineDiffBuilder(new Differ());
            var diff = diffBuilder.BuildDiffModel(textA, textB);

            var sbLeft = new StringBuilder();
            var sbRight = new StringBuilder();
            var diffs = new List<DiffItem>();

            int visualLine = 0;

            foreach (var line in diff.Lines)
            {
                sbLeft.AppendLine(line.Type == ChangeType.Inserted ? "" : line.Text);
                sbRight.AppendLine(line.Type == ChangeType.Deleted ? "" : line.Text);

                if (line.Type != ChangeType.Unchanged)
                {
                    diffs.Add(new DiffItem(visualLine, line.Type));
                }

                visualLine++;
            }

            SetDiffs(diffs);

            return new DiffResult(sbLeft, sbRight, diffs);
        }

        private void SetDiffs(List<DiffItem> diffs)
        {
            ChangedLines = diffs.Select(d => d.LineIndex).Distinct().ToList();
            CurrentDiffIndex = -1;
        }

        private bool CompareFiles(string sourcePath, string targetPath)
        {
            using var hasher = SHA256.Create();
            byte[] sourceHash = hasher.ComputeHash(File.ReadAllBytes(sourcePath));
            byte[] targetHash = File.Exists(targetPath)
                ? hasher.ComputeHash(File.ReadAllBytes(targetPath))
                : Array.Empty<byte>();

            return !sourceHash.SequenceEqual(targetHash);
        }

        private string ComputeFastHash(string path)
        {
            using var stream = File.OpenRead(path);
            using var sha = SHA256.Create();
            byte[] hash = sha.ComputeHash(stream);
            return Convert.ToHexString(hash);
        }
    }
}
