using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CalServices.DataSources;
using CalServices.Models;
using CalServices.Utils;

namespace WoodgroveBankApp.Common
{
    public class ApplicationData
    {
        private Client _client = null;

        public ApplicationData() { }

        private static ApplicationData _current;
        public static ApplicationData Current => _current ?? (_current = new ApplicationData());

        #region Properties
        public Client Client
        {
            get => _client;
            set
            {
                _client = value;
                HomeBranch = _client.Branch;
            }
        }
        public Appointment NewAppointment { get; set; }
        public Branch HomeBranch { get; private set; }
        public List<D365Appointment> Appointments { get; private set; }
        public List<AppointmentReason> AppointmentTypes { get; private set; }
        #endregion

        #region Methods
        public void GetClientAppointments()
        {
            Appointments?.Clear();
            if (Client != null)
            {
                AppointmentsDataSource ds = new AppointmentsDataSource(Client.CustomerNumber);
                Task dataTask = Task.Run(async () =>
                {
                    Appointments = await ds.GetClientUpcomingAppointments(Client.Id);
                    //TODO: UPDATE the bade on the tab bar
                });
            }
        }

        public void GetAppointmentTypes()
        {
            ApptReasonDataSource ds = new ApptReasonDataSource();
            Task dataTask = Task.Run(async () =>
            {
                await ds.Load();    
                ReferenceData.Data.SetReferenceAppointmentTypes(ds.AppointmentTypes);
                AppointmentTypes = ds.AppointmentTypes;
            });

        }
        #endregion
    }
}
