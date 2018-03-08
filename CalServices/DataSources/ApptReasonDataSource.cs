using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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

        public async Task<D365ServiceResponse> GetAppointmentTypes()
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
            return response;
        }

        #region Properties
        #endregion

        #region Constants
        private const string SERVICE_URL = "https://xrmdataservices.azurewebsites.net/api/ScheduleEngine/GetAppointmentTypes";
        #endregion
    }
}
