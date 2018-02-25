using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CalServices.Models;

namespace CalServices.DataSources
{
    public class AppointmentsDataSource : BaseDataSource
    {
        #region Members

        #endregion

        public AppointmentsDataSource(string ClientId)
        {
            this.ClientId = ClientId;
        }

        #region Properties
        public List<Appointment> Appointments
        {
            get;
            private set;
        }
        public string ClientId
        {
            get; private set;
        }
        private string ServiceUrl
        {
            get => string.Format(SERVICE_URL, ClientId);
        }
        #endregion

        #region Methods
        public async override Task<bool> Load()
        {
            Appointments = new List<Appointment>();
            DataServiceResponse<Appointment> response = await this.GetData<Appointment>(ServiceUrl);
            if (response.Success)
            {
                Appointments.Add(response.Data);
                return true;
            }
            return false;
        }
        #endregion

        #region Constants
        private const string SERVICE_URL = "https://xrmdataservices.azurewebsites.net/api/FSClient/GetNextAppointment?ClientId={0}";
        #endregion
    }
}
