using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CalServices.Dynamics.Messages;
using CalServices.Dynamics.Services;
using CalServices.Models;
using CalServices.Utils;

namespace CalServices.DataSources
{
    public class AppointmentsDataSource : BaseDataSource
    {
        #region Members

        #endregion

        public AppointmentsDataSource() { }

        #region Properties
        public List<Appointment> Appointments
        {
            get;
            private set;
        }
        #endregion

        #region Methods
        public async Task<List<D365Appointment>> GetClientUpcomingAppointments(string RecordId)
        {
            D365CrudService service = new D365CrudService();
            QueryFilter filter = new QueryFilter();
            filter.AddCriteria(D365Appointment.STATUS_FIELD, ComparisonOperators.Equal, D365Appointment.CONFIRMED_STATUS);
            filter.AddCriteria(D365Appointment.CLIENT_ID_FIELD, ComparisonOperators.Equal, RecordId);
            filter.AddCriteria(D365Appointment.START_DATE_FIELD, ComparisonOperators.GreaterThan, DateTime.Now.Date);
            RelatedEntity branch = new RelatedEntity()
            {
                IdField = D365Appointment.BRANCH_ID_FIELD,
                Fields = new SelectFieldsList(Branch.FIELDS)
            };
            RelatedEntity advisor = new RelatedEntity()
            {
                IdField = D365Appointment.ADVISOR_ID_NAV_FIELD,
                Fields = new SelectFieldsList(SystemUser.FIELDS)
            };

            RetreiveMultipleRequest request = new RetreiveMultipleRequest()
            {
                EntityName = D365Appointment.ENTITY_NAME,
                Fields = new SelectFieldsList(D365Appointment.FIELDS),
                Filter = filter,
                RelatedEntities = new RelatedEntity[2] { branch, advisor }
            };
            D365ServiceResponse response = await service.RetreiveMultiple(request);
            if (response.Result == ServiceResult.Success)
            {
                return response.GetData <List<D365Appointment>>();
            }
            return new List<D365Appointment>();
        }
        #endregion

        #region Constants
        private const string SERVICE_URL = "{0}FSClient/GetNextAppointment?ClientId={1}";
        #endregion
    }
}
