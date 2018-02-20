using Foundation;
using System;
using UIKit;
using CalServices.Models;

namespace WoodgroveBankApp
{
    public partial class AppDetailViewController : UIViewController
    {
        public AppDetailViewController (IntPtr handle) : base (handle)
        {
        }

        public Appointment Appointment
        {
            get; set;
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            TitleLabel.Text = Appointment.BranchId;
        }
    }
}