using Plugin.Settings.Abstractions;
using WhatsSay.Core.Services.Abstract;

namespace WhatsSay.Core.Services.Implementation
{
    public class SettingService : ISettingService
    {
        private const string AuthKey = "auth_key";

        private readonly string _settingsDefault = string.Empty;
        private readonly ISettings _settings;

        public SettingService(ISettings settings)
        {
            _settings = settings;
        }

        public string AuthToken
        {
            get
            {
                return _settings.GetValueOrDefault(AuthKey, _settingsDefault);
            }
            set
            {
                _settings.AddOrUpdateValue(AuthKey, value);
            }
        }
    }
}