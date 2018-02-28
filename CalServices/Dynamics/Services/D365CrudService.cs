using System.Threading.Tasks;
using CalServices.Dynamics.Base;
using CalServices.Dynamics.Messages;

namespace CalServices.Dynamics.Services
{
    public class D365CrudService : BaseD365Service
    {
        public D365CrudService() { }

        #region Methods
        public async Task<D365ServiceResponse> GetRecordById(RetreiveRequest Request)
        {
            if (Request != null)
            {
                string operation = $"{BaseServiceUrl}{Request.Operation}";
                D365ServiceResponse response = await SendGetRequestAsync(operation);
                return response;
            }
            return null;
        }

        public async Task<D365ServiceResponse> RetreiveMultiple(RetreiveMultipleRequest Request)
        {
            if(Request != null){
                string operation = $"{BaseServiceUrl}{Request.Operation}";
                System.Diagnostics.Debug.WriteLine(operation);
                D365ServiceResponse response = await SendGetRequestAsync(operation);
                return response;
            }
            return null;
        }
        #endregion

        #region Properties

        #endregion
    }
}
