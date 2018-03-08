using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CalServices.DataSources;
using CalServices.Dynamics.Messages;
using CalServices.Models;
using CalServices.Utils;
using Foundation;
using UIKit;

namespace WoodgroveBankApp.Common
{
    public class ApplicationData
    {
        #region Members
        private Client _client = null;
        private List<AppError> _errors = null;
        #endregion

        public ApplicationData() { }

        private static ApplicationData _current;
        public static ApplicationData Current => _current ?? (_current = new ApplicationData());

        #region Properties
        public Client Client
        {
            get => _client;
            private set
            {
                _client = value;
                HomeBranch = _client.Branch;
            }
        }
        public Appointment NewAppointment { get; set; }
        public Branch HomeBranch { get; private set; }
        public List<D365Appointment> Appointments { get; private set; }
        public List<AppointmentReason> AppointmentTypes { get; private set; }
        public List<AppError> Errors => _errors ?? (_errors = new List<AppError>());
        public bool HasErrors => Errors.Count > 0;
        #endregion

        #region Methods
        public async Task LoadApplicationData()
        {
            Errors.Clear();
            await LoadClient();
            await LoadClientAppointments();
            await Current.GetAppointmentTypes();
        }

        public void GetClientAppointments()
        {
            Appointments?.Clear();
            if (Client != null)
            {
                AppointmentsDataSource ds = new AppointmentsDataSource();
                Task dataTask = Task.Run(async () =>
                {
                    D365ServiceResponse response = await ds.GetClientUpcomingAppointments(Client.Id);
                    if (response.Success)
                    {
                        Appointments = response.GetData<List<D365Appointment>>();
                    }
                    else
                    {
                        AppError error = new AppError()
                        {
                            ClassName = nameof(ApplicationData),
                            Method = nameof(GetClientAppointments),
                            ErrorMessage = response.ErrorMessage
                        };
                        Errors.Add(error);
                    }
                });
            }
        }

        public async Task LoadClientAppointments()
        {
            Appointments?.Clear();
            if (Client != null)
            {
                AppointmentsDataSource ds = new AppointmentsDataSource();
                D365ServiceResponse response = await ds.GetClientUpcomingAppointments(Client.Id);
                if (response.Success)
                {
                    Appointments = response.GetData<List<D365Appointment>>();
                }
                else
                {
                    AppError error = new AppError()
                    {
                        ClassName = nameof(ApplicationData),
                        Method = nameof(GetClientAppointments),
                        ErrorMessage = response.ErrorMessage
                    };
                    Errors.Add(error);
                }
            }
        }

        public async Task GetAppointmentTypes()
        {
            ApptReasonDataSource ds = new ApptReasonDataSource();
            D365ServiceResponse response = await ds.GetAppointmentTypes();

            if (response.Success)
            {
                ReferenceData.Data.SetReferenceAppointmentTypes(response.GetData<List<AppointmentReason>>());
                AppointmentTypes = response.GetData<List<AppointmentReason>>();
            }
            else
            {
                AppError error = new AppError()
                {
                    ClassName = nameof(ApplicationData),
                    Method = nameof(GetAppointmentTypes),
                    ErrorMessage = response.ErrorMessage
                };
                Errors.Add(error);
            }

        }

        public async Task RefreshAppointmentsAsync()
        {
            Appointments?.Clear();
            if (Client != null)
            {
                await LoadClientAppointments();
            }
        }

        public async Task LoadClient()
        {
            //load the client
            ClientDataSource clientds = new ClientDataSource();
            D365ServiceResponse response = await clientds.GetClientByClientNumber(ApplicationSettings.Current.ClientNumber);
            if (response.Success)
            {
                Client = response.GetData<Client>();
            }
            else
            {
                AppError error = new AppError()
                {
                    ClassName = nameof(ApplicationData),
                    Method = nameof(LoadClient),
                    ErrorMessage = response.ErrorMessage
                };
                Errors.Add(error);
            }
        }
        #endregion
    }

    public class AppError
    {
        public string ClassName { get; set; }
        public string Method { get; set; }
        public string ErrorMessage { get; set; }
    }
}
