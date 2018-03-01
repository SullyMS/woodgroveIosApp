using System.Threading.Tasks;
using CalServices.Dynamics.Messages;
using CalServices.Dynamics.Services;
using CalServices.Models;

namespace CalServices.DataSources
{
    public class ClientDataSource : BaseDataSource
    {
        public ClientDataSource(string ClientId)
        {
            this.ClientId = ClientId;
        }

        public async Task<bool> Load()
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
                RelatedEntities = new RelatedEntity[1] { relatedBranch }
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
        #endregion

        #region Constants
        #endregion
    }
}
