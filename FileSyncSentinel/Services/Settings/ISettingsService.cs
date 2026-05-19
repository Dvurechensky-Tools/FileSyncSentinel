/*
 * Author: Nikolay Dvurechensky
 * Site: https://dvurechensky.pro/
 * Gmail: dvurechenskysoft@gmail.com
 * Last Updated: 19 мая 2026 10:37:23
 * Version: 1.0.201
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
