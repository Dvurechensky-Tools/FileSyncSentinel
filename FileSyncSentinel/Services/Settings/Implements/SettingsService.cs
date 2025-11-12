/*
 * Author: Nikolay Dvurechensky
 * Site: https://sites.google.com/view/dvurechensky
 * Gmail: dvurechenskysoft@gmail.com
 * Last Updated: 12 ноября 2025 06:53:11
 * Version: 1.0.12
 */

using System.Diagnostics;

using Newtonsoft.Json;

using FileSyncSentinel.Components;

namespace FileSyncSentinel.Services.Settings
{
    public class SettingsService : ISettingsService
    {
        public string ConfigPath { get; set; }

        public SettingsService(string configPath)
        {
            ConfigPath = configPath;
        }

        public SettingsData LoadSettings()
        {
            if (!File.Exists(ConfigPath))
            {
                var settingsCreate = new SettingsData();
                settingsCreate.MergeConfigData = new MergeConfigData();
                settingsCreate.MergeConfigData.PathIn = "path/to/folder/in";
                settingsCreate.MergeConfigData.PathOut = "path/to/folder/out";
                settingsCreate.MergeConfigData.TypeFiles = "*.ini";
                var jsonData = JsonConvert.SerializeObject(settingsCreate);
                File.WriteAllText(ConfigPath, jsonData);
                Process.Start(new ProcessStartInfo
                {
                    FileName = ConfigPath,
                    UseShellExecute = true // обязательно для открытия через ассоциации Windows
                });
                return settingsCreate;
            }

            var fileContent = File.ReadAllText(ConfigPath);
            var settings = JsonConvert.DeserializeObject<SettingsData>(fileContent);
            return settings;
        }
    }
}
