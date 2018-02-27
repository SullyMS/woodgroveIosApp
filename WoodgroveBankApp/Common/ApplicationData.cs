using System;
using CalServices.Models;

namespace WoodgroveBankApp.Common
{
    public class ApplicationData
    {
        private Client _client = null;

        public ApplicationData(){}

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
        #endregion
    }
}
