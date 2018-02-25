using System;
using System.Collections.Generic;
using CalServices.Models;

namespace CalServices.DataSources
{
    public class BranchDataSource : BaseDataSource
    {
        public BranchDataSource(string BranchId)
        {
            this.BranchId = BranchId;
        }

        public List<Branch> Branches { get; private set; }

        public async override System.Threading.Tasks.Task<bool> Load()
        {
            DataServiceResponse<Branch> response = await GetData<Branch>(ServiceUrl);
            if(response.Success){
                Branch = response.Data;
                return true;
            }
            return false;
        }

        #region Properties
        private string ServiceUrl
        {
            get => $"{SERVICE_URL}{BranchId}";
        }
        public string BranchId { get; private set;}
        public Branch Branch { get; private set; }
        #endregion

        #region Constants
        private const string SERVICE_URL = "https://xrmdataservices.azurewebsites.net/api/Branch/GetBranchById/";
        #endregion
    }
}
