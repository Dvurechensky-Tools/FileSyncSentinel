/*
 * Author: Nikolay Dvurechensky
 * Site: https://sites.google.com/view/dvurechensky
 * Gmail: dvurechenskysoft@gmail.com
 * Last Updated: 13 марта 2026 06:53:38
 * Version: 1.0.133
 */

using FileSyncSentinel.Components;

namespace FileSyncSentinel.Services.Settings
{
    public interface ISettingsService
    {
        string ConfigPath { get; set; }
        SettingsData LoadSettings();
    }
}
