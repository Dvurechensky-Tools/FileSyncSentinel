/*
 * Author: Nikolay Dvurechensky
 * Site: https://sites.google.com/view/dvurechensky
 * Gmail: dvurechenskysoft@gmail.com
 * Last Updated: 29 декабря 2025 09:59:41
 * Version: 1.0.59
 */

using Newtonsoft.Json;

namespace FileSyncSentinel.Components
{
    public class MergeConfigData
    {
        /// <summary>
        /// Ппапка с эталонными значениями
        /// 
        /// Например LizeriumINI
        /// </summary>
        public string PathIn { get; set; }
        /// <summary>
        /// Наблюдаемая папка изменений
        /// 
        /// Например LizeriumFreelancerModeChange
        /// </summary>
        public string PathOut { get; set; }
        /// <summary>
        /// Тип наблюдаемых файлов 
        /// 
        /// Например: *.ini
        /// </summary>
        public string TypeFiles { get; set; }

        /// <summary>
        /// Наблюдатель за изменениями в папке 
        /// </summary>
        [JsonIgnore]
        public FileSystemWatcher FilesWatcher { get; set; }

        /// <summary>
        /// Список файлов папки PathIn
        /// 
        /// Relative path - Key
        /// Full path - Value
        /// </summary>
        [JsonIgnore]
        public Dictionary<string, string> InFiles { get; internal set; } = new Dictionary<string, string>();
        /// <summary>
        /// Список файлов папки PathOut
        /// 
        /// Relative path - Key
        /// Full path - Value
        /// </summary>
        [JsonIgnore]
        public Dictionary<string, string> OutFiles { get; internal set; } = new Dictionary<string, string>();

        [JsonIgnore]
        public bool IsValid => !string.IsNullOrEmpty(PathIn) && !string.IsNullOrEmpty(PathOut)
            && !string.IsNullOrEmpty(TypeFiles)
            && Directory.Exists(PathIn) && Directory.Exists(PathOut);

    }
}
