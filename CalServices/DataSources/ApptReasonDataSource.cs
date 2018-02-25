using System;
using System.Collections.Generic;
using CalServices.Models;

namespace CalServices.DataSources
{
    public class ApptReasonDataSource : BaseDataSource
    {
        public ApptReasonDataSource()
        {
        }

        public async override System.Threading.Tasks.Task<bool> Load()
        {
            DataServiceResponse<List<EntityStatus>> response = await GetData<List<EntityStatus>>(SERVICE_URL);
            if (response.Success)
            {
                AppointmentTypes = response.Data;
                return true;
            }
            return false;
        }

        #region Properties
        public List<EntityStatus> AppointmentTypes { get; private set; }
        #endregion

        #region Constants
        private const string SERVICE_URL = "https://xrmdataservices.azurewebsites.net/api/ScheduleEngine/GetAppointmentTypes";
        #endregion
    }
}
