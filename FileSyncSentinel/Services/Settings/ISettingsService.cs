/*
 * Author: Nikolay Dvurechensky
 * Site: https://dvurechensky.pro/
 * Gmail: dvurechenskysoft@gmail.com
 * Last Updated: 11 июля 2026 14:24:37
 * Version: 1.0.253
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
