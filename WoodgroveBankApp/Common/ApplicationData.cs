using System;
using CalServices.Models;

namespace WoodgroveBankApp.Common
{
    public class ApplicationData
    {
        public ApplicationData()
        {
            NewAppointment = new Appointment()
            {
                BranchNumber = "100",
                ClientId = "123456"

            };
        }

        private static ApplicationData _current;
        public static ApplicationData Current => _current ?? (_current = new ApplicationData());

        #region Properties
        public Client Client { get; set; }
        public Appointment NewAppointment { get; set; }
        public Branch HomeBranch { get; set; }
        #endregion
    }
}
