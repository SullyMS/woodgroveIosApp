using System;
using System.Threading.Tasks;
using CalServices.Dynamics.Models;
using CalServices.Dynamics.Services;
using CalServices.Models;
using Newtonsoft.Json;

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
            D365CrudService service = new D365CrudService();
            RelatedEntity relatedBranch = new RelatedEntity()
            {
                IdField = Client.BRANCH_ID_FIELD, 
                Fields = Branch.FIELDS
            };
            D365ServiceResponse response = await service.GetRecordById(Client.ENTITY_NAME, ClientId, 
                                                                       Client.ALT_KEY, true, Client.FIELDS, relatedBranch);
            if(response.Result == ServiceResult.Success){
                Client = JsonConvert.DeserializeObject<Client>(response.Json);
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
        //private const string SERVICE_URL = "https://xrmdataservices.azurewebsites.net/api/FSClient/GetFSIClient?ClientId={0}";
        private const string SERVICE_URL = "http://scheduleservices.azurewebsites.net/api/Clients/{0}";
        #endregion
    }
}
