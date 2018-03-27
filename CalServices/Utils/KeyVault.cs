using System;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System.Threading.Tasks;
using CalServices.Models;

namespace CalServices.Utils
{
    public class KeyVault
    {
        #region Members
        private static KeyVault _keys = null;
        private DynamicsSettings _settings = null;
        #endregion

        #region Constants
        #endregion


        #region Constructor
        private KeyVault()
        {
            // constructor

        }
        #endregion

        #region Properties
        public static KeyVault Tokens => _keys ?? (_keys = new KeyVault());

        private string ServiceToken { get; set; }
        public DynamicsSettings DynamicsSettings
        {
            get => _settings;
            set
            {
                _settings = value;
                ServiceToken = string.Empty;
            }
        }
        #endregion

        #region Methods
        public async Task<string> GetD365ServiceToken()
        {
            if (string.IsNullOrEmpty(ServiceToken))
            {
                AuthenticationContext authContext = new AuthenticationContext(DynamicsSettings.OAuthEndPoint);
                ClientCredential creds = new ClientCredential(DynamicsSettings.AppId, DynamicsSettings.Secret);
                AuthenticationResult tokenResult = await authContext.AcquireTokenAsync(DynamicsSettings.InstanceUrl, creds);

                if (tokenResult == null)
                {
                    throw new InvalidOperationException("Failed to get authenitcation token");
                }
                else
                {
                    ServiceToken = tokenResult.AccessToken;
                }
            }
            return ServiceToken;
        }
        public void Reset()
        {
            ServiceToken = string.Empty;
        }
        #endregion
    }
}
