// Helpers/Settings.cs
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace WhatsSay.Core.Helpers
{
    /// <summary>
    /// This is the Settings static class that can be used in your Core solution or in any
    /// of your client applications. All settings are laid out the same exact way with getters
    /// and setters. 
    /// </summary>
    public static class Settings
    {
        private static ISettings AppSettings => CrossSettings.Current;

        private const string AuthKey = "auth_token";
        private static readonly string SettingsDefault = string.Empty;


        public static string AuthToken
        {
            get
            {
                return AppSettings.GetValueOrDefault<string>(AuthKey, SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue<string>(AuthKey, value);
            }
        }

    }
}