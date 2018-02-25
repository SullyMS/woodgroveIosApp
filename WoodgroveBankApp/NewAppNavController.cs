using Foundation;
using System;
using UIKit;
using WoodgroveBankApp.Common;

namespace WoodgroveBankApp
{
    public partial class NewAppNavController : UINavigationController
    {
        public NewAppNavController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            //create a new appointment for this client
            ApplicationData.Current.NewAppointment = new CalServices.Models.Appointment()
            {
                ClientId = ApplicationData.Current.Client.Id,
                BranchId = ApplicationData.Current.Client.HomeBranchId,
                BranchNumber = ApplicationData.Current.HomeBranch.Number,
                AppointmentLanguage = ApplicationData.Current.Client.PrimaryLanguage
            }; 
        }
    }
}