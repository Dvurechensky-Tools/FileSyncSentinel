/*
 * Author: Nikolay Dvurechensky
 * Site: https://dvurechensky.pro/
 * Gmail: dvurechenskysoft@gmail.com
 * Last Updated: 07 октября 2026 06:58:23
 * Version: 1.0.341
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
