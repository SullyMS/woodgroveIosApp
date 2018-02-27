using System.Threading.Tasks;
using CalServices.Dynamics.Base;
using CalServices.Dynamics.Models;

namespace CalServices.Dynamics.Services
{
    public class D365CrudService : BaseD365Service
    {
        public D365CrudService() { }

        #region Methods
        public async Task<D365ServiceResponse> GetRecordById(string EntityName, string Id, string KeyFieldName = "", bool IsAlternateId = false, string[] Fields = null, RelatedEntity Related = null)
        {
            if (string.IsNullOrEmpty(KeyFieldName))
            {
                KeyFieldName = $"{EntityName}id";
            }
            string serviceUrl = GetServiceUrl(EntityName, Id, KeyFieldName, IsAlternateId, Fields, Related);
            D365ServiceResponse response = await SendGetRequestAsync(serviceUrl);
            return response;
        }

        private string GetServiceUrl(string EntityName, string Id, string KeyFieldName, bool IsAlternateId = false, string[] Fields = null, RelatedEntity Related = null)
        {
            string operation = string.Empty;
            if (IsAlternateId)
            {
                operation = $"{BaseServiceUrl}{EntityName.ToLower()}s({KeyFieldName}='{Id}')";
            }
            else
            {
                operation = $"{BaseServiceUrl}{EntityName.ToLower()}s({Id})";
            }
            if (Fields != null)
            {
                string query = @"?$select=";
                bool isfirst = true;
                foreach (string s in Fields)
                {
                    if (isfirst)
                    {
                        query += s;
                        isfirst = false;
                    }
                    else
                    {
                        query += $",{s}";
                    }
                }
                operation += query;
            }
            if (Related != null)
            {
                string query = $"&$expand={Related.IdField}($select=";
                bool isfirst = true;
                foreach (string s in Related.Fields)
                {
                    if (isfirst)
                    {
                        query += s;
                        isfirst = false;
                    }
                    else
                    {
                        query += $",{s}";
                    }
                }
                operation += $"{query})";
            }

            return operation;
        }
        #endregion

        #region Properties

        #endregion
    }
}
