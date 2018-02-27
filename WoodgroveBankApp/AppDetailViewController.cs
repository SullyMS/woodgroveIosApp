using Foundation;
using System;
using UIKit;
using CalServices.Models;

namespace WoodgroveBankApp
{
    public partial class AppDetailViewController : UIViewController
    {
        public AppDetailViewController(IntPtr handle) : base(handle)
        {
        }

        public Appointment Appointment
        {
            get; set;
        }

        #region Overrides
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            //set the cancel button
            UIBarButtonItem cancelButton = new UIBarButtonItem("Cancel", UIBarButtonItemStyle.Plain, OnCancelButton);
            NavigationItem.SetRightBarButtonItem(cancelButton, true);
        }

        private void OnCancelButton(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            Title = $"Appointment: {Appointment.ConfirmationNumber}";
            ConfNumLabel.Text = $"Confirmation Number: {Appointment.ConfirmationNumber}";
            StatusLabel.Text = $"Status: {Appointment.Status.DisplayLabel}";
            DateLabel.Text = $"Date: {Appointment.StartDate:MMM dd, yyyy}";
            TimeLabel.Text = $"Time: {Appointment.StartDate:h:mm} - {Appointment.EndDate:h:mm tt}";
            PurposeLabel.Text = $"Purpose: {Appointment.AppointmentType.DisplayLabel}";
            BranchLabel.Text = $"Branch: {Appointment.BranchNumber}";
        }

        #endregion
    }
}