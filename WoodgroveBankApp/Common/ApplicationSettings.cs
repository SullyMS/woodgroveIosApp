using System.Collections.Generic;
using CalServices.Models;
using CalServices.Utils;
using Foundation;

namespace WoodgroveBankApp.Common
{
    public class ApplicationSettings
    {
        private static ApplicationSettings _current = null;
        private Dictionary<string, DynamicsSettings> _environments = new Dictionary<string, DynamicsSettings>();

        public ApplicationSettings()
        {
            //defaults Appointment Booking
            DynamicsSettings envAppointmentBooking = new DynamicsSettings
            {
                AppId = "5b5de57b-6005-48d8-b751-456686d37e20",
                Secret = "Ho3+w/sqZSUdoLWBvj4LkhpYn/I8zsWioIdH6TK32Og=",
                OAuthEndPoint = "https://login.microsoftonline.com/172e0c50-ade4-44ab-9a50-b86af9d7fc37/oauth2/token",
                ApiBaseUrl = "https://appointmentbooking.api.crm.dynamics.com/api/data/v8.2/",
                InstanceUrl = "https://appointmentbooking.crm.dynamics.com",
                CalServicesUrl = "https://xrmdataservices.azurewebsites.net/api/",
                EnvironmentName = "Appointment Booking"
            };
            _environments.Add(ID_ENV_APP_BOOKING, envAppointmentBooking);
            DynamicsSettings envRetail = new DynamicsSettings
            {
                AppId = "9d7ba813-c1cf-4607-bb6b-f6901451f7e1",
                Secret = "kauwxErPY2KzPuwNFIJolvQpKZyVwTdqkFDPLslkHEw=",
                OAuthEndPoint = "https://login.microsoftonline.com/73063bca-37ae-4d37-b316-85fb315e3d8e/oauth2/token",
                ApiBaseUrl = "https://woodgroveretail1.api.crm3.dynamics.com/api/data/v9.0/",
                InstanceUrl = "https://woodgroveretail1.crm3.dynamics.com",
                CalServicesUrl = "https://wgrxrmdataservices.azurewebsites.net/api/",
                EnvironmentName = "Woodgrove Retail1"
            };
            _environments.Add(ID_ENV_RETAIL, envRetail);
        }

        #region Properties
        public static ApplicationSettings Current => _current ?? (_current = new ApplicationSettings());

        public DynamicsSettings DynamicsSettings
        {
            get
            {
                string env = NSUserDefaults.StandardUserDefaults.StringForKey(KEY_ENVIRONMENT);
                if (env != null)
                {
                    if (env.Equals(ID_ENV_APP_BOOKING))
                    {
                        return _environments[ID_ENV_APP_BOOKING];
                    }
                }
                return _environments[ID_ENV_RETAIL];    
            }
        }

        public void SyncSettings()
        {
            CalServices.Utils.KeyVault.Tokens.DynamicsSettings = ApplicationSettings.Current.DynamicsSettings;
            SchedulerSettings.Settings.ScheduleBaseUrl = ApplicationSettings.Current.DynamicsSettings.CalServicesUrl;
        }

        public string ClientNumber
        {
            get
            {
                string num = NSUserDefaults.StandardUserDefaults.StringForKey(KEY_CLIENT_NUMBER);
                if (string.IsNullOrEmpty(num))
                {
                    return DEFAULT_CLIENT_NUM;
                }
                return num;
            }
        }
        #endregion

        #region Constants
        private const string KEY_CLIENT_NUMBER = @"client_id_preference";
        private const string KEY_ENVIRONMENT = @"environment_setting";
        private const string ID_ENV_APP_BOOKING = @"Appointment Booking";
        private const string ID_ENV_RETAIL = @"Retail";
        private const string DEFAULT_CLIENT_NUM = @"123456";
        #endregion

    }
}
