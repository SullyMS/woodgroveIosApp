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
        public async override Task Load()
        {
            //Appointments = new List<Appointment>();
            ////create fake data
            //Appointment a = new Appointment()
            //{
            //    AppointmentId = "1000",
            //    AdvisorId = "900",
            //    Advisor = new Advisor() { AdvisorId = "900", FirstName = "Jeff", LastName = "Hay", Email = "jeffh@josullivdemo01.onmicrosoft.com" },
            //    BranchId = "100",
            //    ClientId = "123456",
            //    Client = new Client() { ClientId = "123456", FirstName = "Christy", LastName = "Coleman" },
            //    Location = new Branch() { Transit = "100", Address = "123 Main Street Oakville, ON", Name = "Oakville Place" },
            //    Duration = new TimeSpan(0, 30, 0),
            //    StartDate = new DateTime(2018, 4, 1, 13, 0, 0),
            //    EndDate = new DateTime(2018, 4, 1, 13, 30, 0),
            //    Status = AppointmentStatus.Confirmed,
            //    Reason = AppointmentReasons.Realestate
            //};
            //Appointments.Add(a);
            Appointments = new List<Appointment>();
            DataServiceResponse<Appointment> response = await this.GetData<Appointment>(ServiceUrl);
            if (response.Success)
            {
                Appointments.Add(response.Data);
            }
        }
        #endregion

        #region Constants
        private const string SERVICE_URL = "https://xrmdataservices.azurewebsites.net/api/FSClient/GetNextAppointment?ClientId={0}";
        #endregion
    }
}
