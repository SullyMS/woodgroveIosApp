using System;
using System.Collections.Generic;
using CalServices.Dynamics.Messages;
using CalServices.Dynamics.Services;
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
            //DataServiceResponse<List<EntityStatus>> response = await GetData<List<EntityStatus>>(SERVICE_URL);
            //if (response.Success)
            //{
            //    AppointmentTypes = response.Data;
            //    return true;
            //}
            D365CrudService service = new D365CrudService();
            QueryFilter filter = new QueryFilter();
            filter.AddCriteria(AppointmentReason.STATE_FIELD, ComparisonOperators.Equal, 1);
            RetreiveMultipleRequest request = new RetreiveMultipleRequest()
            {
                EntityName = AppointmentReason.ENTITY_NAME,
                Filter = filter,
                Fields = new SelectFieldsList(AppointmentReason.FIELDS)
            };
            D365ServiceResponse response = await service.RetreiveMultiple(request);
            if (response.Result == ServiceResult.Success)
            {
                AppointmentTypes = response.GetData<List<AppointmentReason>>();
                return true;
            }
            return false;
        }

        #region Properties
        public List<AppointmentReason> AppointmentTypes { get; private set; }
        #endregion

        #region Constants
        private const string SERVICE_URL = "https://xrmdataservices.azurewebsites.net/api/ScheduleEngine/GetAppointmentTypes";
        #endregion
    }
}
