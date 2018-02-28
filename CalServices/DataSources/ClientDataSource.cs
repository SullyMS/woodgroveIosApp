using System;
using System.Threading.Tasks;
using CalServices.Dynamics.Messages;
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
                Fields = new SelectFieldsList(Branch.FIELDS)
            };
            RetreiveRequest request = new RetreiveRequest()
            {
                EntityName = Client.ENTITY_NAME,
                Fields = new SelectFieldsList(Client.FIELDS),
                IsAlternateKey = true,
                IdValue = ClientId,
                KeyFieldName = Client.ALT_KEY,
                RelatedEntity = relatedBranch
            };

            D365ServiceResponse response = await service.GetRecordById(request);
            if(response.Result == ServiceResult.Success){
                Client = response.GetData<Client>();
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
