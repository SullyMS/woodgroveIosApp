using System;
using System.Threading.Tasks;
using CalServices.Models;

namespace CalServices.DataSources
{
    public class ClientDataSource : BaseDataSource
    {
        public ClientDataSource(string ClientId)
        {
            this.ClientId = ClientId;
        }

        public async override Task<bool> Load()
        {
            DataServiceResponse<Client> response = await GetData<Client>(ServiceUrl);
            if(response.Success){
                Client = response.Data;
                return true;
            }
            return false;
        }

        #region Properties
        public Client Client { get; private set; }
        public string ClientId { get; private set; }
        public string ServiceUrl { get => string.Format(SERVICE_URL, ClientId); }
        #endregion

        #region Constants
        private const string SERVICE_URL = "https://xrmdataservices.azurewebsites.net/api/FSClient/GetFSIClient?ClientId={0}";
        #endregion
    }
}
