using System.Threading.Tasks;
using CalServices.Dynamics.Messages;
using CalServices.Dynamics.Services;
using CalServices.Models;

namespace CalServices.DataSources
{
    public class ClientDataSource : BaseDataSource
    {
        public ClientDataSource() { }

        public async Task<D365ServiceResponse> GetClientByClientNumber(string ClientNumber)
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
                IdValue = ClientNumber,
                KeyFieldName = Client.ALT_KEY,
                RelatedEntities = new RelatedEntity[1] { relatedBranch }
            };

            D365ServiceResponse response = await service.GetRecordById(request);
            return response;
        }


        #region Properties
        #endregion

        #region Constants
        #endregion
    }
}
