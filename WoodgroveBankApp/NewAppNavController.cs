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
            SetAppointmentCount(10);
            //create a new appointment for this client
            ApplicationData.Current.NewAppointment = new CalServices.Models.Appointment()
            {
                ClientId = ApplicationData.Current.Client.CustomerNumber,
                BranchId = ApplicationData.Current.Client.HomeBranchId,
                BranchNumber = ApplicationData.Current.HomeBranch.Number,
                AppointmentLanguage = ApplicationData.Current.Client.PrimaryLanguage
            };

        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            UpdateAppointmentsCount();
        }

        public void UpdateAppointmentsCount()
        {
            if (ApplicationData.Current.Appointments != null)
            {
                if (ApplicationData.Current.Appointments.Count > 0)
                {
                    TabBarItem.BadgeColor = UIColor.Red;
                    TabBarItem.BadgeValue = ApplicationData.Current.Appointments.Count.ToString();
                }
                else
                {
                    TabBarItem.BadgeValue = null;
                }
            }
            else
            {
                TabBarItem.BadgeValue = null;
            }
        }

        public void SetAppointmentCount(int count)
        {
            TabBarItem.BadgeColor = UIColor.Red;
            TabBarItem.BadgeValue = count.ToString();
        }
    }
}