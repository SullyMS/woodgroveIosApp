using System;
using System.Collections.Generic;
using CalServices.Models;
using Foundation;

namespace WoodgroveBankApp.Common
{
    public class ApplicationSettings
    {
        private static ApplicationSettings _current = null;
        private DynamicsSettings _dynamicsSettings = null;
        private Dictionary<string, string> _defaults = new Dictionary<string, string>();

        public ApplicationSettings()
        {
            //defaults
            _defaults.Add(KEY_APP_ID, "5b5de57b-6005-48d8-b751-456686d37e20");
            _defaults.Add(KEY_SECRET, "Ho3+w/sqZSUdoLWBvj4LkhpYn/I8zsWioIdH6TK32Og=");
            _defaults.Add(KEY_OAUTH, "https://login.microsoftonline.com/172e0c50-ade4-44ab-9a50-b86af9d7fc37/oauth2/token");
            _defaults.Add(KEY_BASE_API_URL, "https://appointmentbooking.api.crm.dynamics.com/api/data/v8.2/");
            _defaults.Add(KEY_INSTANCE_URL, "https://appointmentbooking.crm.dynamics.com");
            _defaults.Add(KEY_CLIENT_NUMBER, "123456");
        }

        public static ApplicationSettings Current => _current ?? (_current = new ApplicationSettings());

        public DynamicsSettings DynamicsSettings
        {
            get
            {
                if (_dynamicsSettings == null)
                {
                    _dynamicsSettings = new DynamicsSettings(
                        GetValue(KEY_APP_ID),
                        GetValue(KEY_SECRET),
                        GetValue(KEY_OAUTH),
                        GetValue(KEY_BASE_API_URL),
                        GetValue(KEY_INSTANCE_URL)
                    );
                }
                return _dynamicsSettings;
            }
        }

        public string ClientNumber
        {
            get => GetValue(KEY_CLIENT_NUMBER);
        }

        private string GetValue(string Key){
            string value = NSUserDefaults.StandardUserDefaults.StringForKey(Key);
            if(string.IsNullOrEmpty(value)){
                value = _defaults[Key];
            }
            return value;
        }

        #region Constants
        private const string KEY_APP_ID = @"d365_app_id";
        private const string KEY_SECRET = @"d365_secret";
        private const string KEY_OAUTH = @"d365_oauth_endpoint";
        private const string KEY_BASE_API_URL = @"d365_base_api_url";
        private const string KEY_INSTANCE_URL = @"d365_org_url";
        private const string KEY_CLIENT_NUMBER = @"client_id_preference";
        #endregion

    }
}
