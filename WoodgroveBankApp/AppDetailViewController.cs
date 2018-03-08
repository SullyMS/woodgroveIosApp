using System;
using UIKit;
using CalServices.Models;
using System.Threading.Tasks;
using CalServices.DataSources;
using WoodgroveBankApp.Common;

namespace WoodgroveBankApp
{
    public partial class AppDetailViewController : UIViewController
    {
        #region Constructor
        public AppDetailViewController(IntPtr handle) : base(handle)
        {
        }
        #endregion

        #region Properties
        public D365Appointment Appointment
        {
            get; set;
        }
        private UIBarButtonItem CancelButton { get; set; } 
        private UIAlertController ProgressAlert { get; set; }
        #endregion

        #region Overrides
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            //set the cancel button
            CancelButton = new UIBarButtonItem("Cancel", UIBarButtonItemStyle.Plain, OnCancelButton);
            NavigationItem.SetRightBarButtonItem(CancelButton, true);
        }

        private void OnCancelButton(object sender, EventArgs e)
        {
            var alert = UIAlertController.Create("Confirm Cancellation", "Do you wish to cancel this appoinment?", UIAlertControllerStyle.Alert);

            alert.AddAction(UIAlertAction.Create("No", UIAlertActionStyle.Cancel, null));
            alert.AddAction(UIAlertAction.Create("Yes", UIAlertActionStyle.Destructive, (UIAlertAction obj) =>
            {
                StartCancellation();
            }));

            PresentViewController(alert, true, null);
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            Title = $"Appointment: {Appointment.ConfirmationNumber}";
            ConfNumLabel.Text = $"Confirmation Number: {Appointment.ConfirmationNumber}";
            StatusLabel.Text = $"Status: {Appointment.Status}";
            DateLabel.Text = $"Date: {Appointment.StartDate:MMM dd, yyyy}";
            TimeLabel.Text = $"Time: {Appointment.StartDate:h:mm} - {Appointment.EndDate:h:mm tt}";
            PurposeLabel.Text = $"Purpose: {Appointment.AppointmentReason}";
            BranchLabel.Text = $"Branch: {Appointment.Branch.Name}";
            PhoneLabel.Text = Appointment.Branch.PhoneNumber;
            Address1Label.Text = Appointment.Branch.Street1;
            Address2Label.Text = $"{Appointment.Branch.City}, {Appointment.Branch.Province} {Appointment.Branch.PostalCode}";
            FullNameLabel.Text = Appointment.Advisor.FullName;
            TitleLabel.Text = Appointment.Advisor.Title;
            EmailLabel.Text = Appointment.Advisor.Email;
            MobileLabel.Text = Appointment.Advisor.MobilePhone;
            AdvisorImage.Image = ImageConverter.GetImageFromBase64String(Appointment.Advisor.Image);
            AdvisorImage.Layer.BorderWidth = 3;
            AdvisorImage.Layer.BorderColor = new UIColor(red: 0.0784f, green: 0.4392f, blue: 0f, alpha: 1.0f).CGColor;
            AdvisorImage.Layer.MasksToBounds = true;
            AdvisorImage.Layer.CornerRadius = 50f;
        }

        #endregion

        #region Methods

        private void StartCancellation()
        {
            CancelButton.Enabled = false;
            CheckInButton.Enabled = false;
            //open a progress alert
            ProgressAlert = UIAlertController.Create("Cancel Appointment", "Cancelling appointment please wait...", UIAlertControllerStyle.Alert);
            PresentViewController(ProgressAlert, true, null);

            Task.Run(async () =>
            {
                DataServiceResponse<CancelAppointmentResponse> response = await CancelAppointmentAsync();
                if (response == null)
                {
                    ShowError(response);
                }
                else
                {
                    if (response.Success)
                    {
                        //success
                        ShowSuccess();
                    }
                    else
                    {
                        //error
                        ShowError(response);
                    }
                }
            });
        }

        partial void CheckInButton_TouchUpInside(UIButton sender)
        {
            CheckInButton.Enabled = false;
            CancelButton.Enabled = false;
            var alert = UIAlertController.Create("Confirm Check-In", "Do you wish to check-in for this appoinment?", UIAlertControllerStyle.Alert);

            alert.AddAction(UIAlertAction.Create("No", UIAlertActionStyle.Cancel, null));
            alert.AddAction(UIAlertAction.Create("Yes", UIAlertActionStyle.Destructive, (UIAlertAction obj) =>
            {
                StartCheckIn();
            }));

            PresentViewController(alert, true, null);
        }

        private void ShowSuccess()
        {

            InvokeOnMainThread(() =>
            {
                ProgressAlert.DismissViewController(true, null);
                var alert = UIAlertController.Create("Appointment Cancelled", $"Your appointment is cancelled. You will receive an email confirming your cancellation.", UIAlertControllerStyle.Alert);

                alert.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Default, OnCancelComplete));

                PresentViewController(alert, true, null);
            });
        }

        private void OnCancelComplete(UIAlertAction obj)
        {
            UpdateAppointmentCount();
            NavigationController.PopViewController(true);
        }

        private async Task<DataServiceResponse<CancelAppointmentResponse>> CancelAppointmentAsync()
        {
            CancelAppointmentRequest request = new CancelAppointmentRequest()
            {
                ConfirmationNumber = Appointment.ConfirmationNumber,
                UiLanguageCode = 1033,
                IsRequestFromCrm = false
            };
            ScheduleDataSource ds = new ScheduleDataSource();
            DataServiceResponse<CancelAppointmentResponse> response = await ds.CancelAppointmentAsync(request);
            if (response.Success)
            {
                //refresh the appointments
                await ApplicationData.Current.RefreshAppointmentsAsync();
            }
            return response;
        }

        private void ShowError(DataServiceResponse<CancelAppointmentResponse> Response)
        {

            InvokeOnMainThread(() =>
            {
                ProgressAlert.DismissViewController(true, null);
                var alert = UIAlertController.Create("Schedule Error", $"Unable to cancel appointment: {Response.ErrorMessage}", UIAlertControllerStyle.Alert);
                alert.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Default, null));
                PresentViewController(alert, true, null);
                CancelButton.Enabled = true;
                CheckInButton.Enabled = true;
            });
        }

        private void ShowCheckInError(DataServiceResponse<CheckInResponse> Response)
        {

            InvokeOnMainThread(() =>
            {
                ProgressAlert.DismissViewController(true, null);
                var alert = UIAlertController.Create("Check-In Error", $"Unable to check you in. Please see a staff member. DEBUG:{Response?.ErrorMessage}", UIAlertControllerStyle.Alert);
                alert.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Default, null));
                PresentViewController(alert, true, null);
                CancelButton.Enabled = true;
                CheckInButton.Enabled = true;
            });
        }

        private void ShowCheckInSuccess()
        {

            InvokeOnMainThread(() =>
            {
                ProgressAlert.DismissViewController(true, null);
                var alert = UIAlertController.Create("Check-In Complete", $"Check-In complete. {Appointment.Advisor.FullName} will be with you soon.", UIAlertControllerStyle.Alert);

                alert.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Default, OnCheckInComplete));

                PresentViewController(alert, true, null);
            });
        }

        private void OnCheckInComplete(UIAlertAction obj)
        {
            UpdateAppointmentCount();
            NavigationController.PopViewController(true);
        }

        private void UpdateAppointmentCount()
        {
            NewAppNavController t = (NewAppNavController)TabBarController.ViewControllers[1];
            t.UpdateAppointmentsCount();
        }

        private void StartCheckIn()
        {
            CancelButton.Enabled = false;
            CheckInButton.Enabled = false;
            //open a progress alert
            ProgressAlert = UIAlertController.Create("Checking-In", "Checking you in for your appointment. Please wait...", UIAlertControllerStyle.Alert);
            PresentViewController(ProgressAlert, true, null);

            Task.Run(async () =>
            {
                DataServiceResponse<CheckInResponse> response = await CheckInAsync();
                if (response == null)
                {
                    ShowCheckInError(response);
                }
                else
                {
                    if (response.Success)
                    {
                        //success
                        ShowCheckInSuccess();
                    }
                    else
                    {
                        //error
                        ShowCheckInError(response);
                    }
                }
            });
        }

        private async Task<DataServiceResponse<CheckInResponse>> CheckInAsync()
        {
            ScheduleDataSource ds = new ScheduleDataSource();
            DataServiceResponse<CheckInResponse> response = await ds.CheckInAsync(Appointment.ConfirmationNumber);
            if (response.Success)
            {
                //refresh the appointments
                await ApplicationData.Current.RefreshAppointmentsAsync();
            }
            return response;
        }
        #endregion
    }
}