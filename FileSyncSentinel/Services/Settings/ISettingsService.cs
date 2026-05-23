/*
 * Author: Nikolay Dvurechensky
 * Site: https://dvurechensky.pro/
 * Gmail: dvurechenskysoft@gmail.com
 * Last Updated: 23 мая 2026 11:34:15
 * Version: 1.0.205
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
