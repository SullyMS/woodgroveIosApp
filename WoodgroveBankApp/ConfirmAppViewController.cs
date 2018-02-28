using Foundation;
using System;
using UIKit;
using WoodgroveBankApp.Common;
using CalServices.Models;
using System.Threading.Tasks;
using CalServices.DataSources;

namespace WoodgroveBankApp
{
    public partial class ConfirmAppViewController : UIViewController
    {

        #region Constructor
        public ConfirmAppViewController(IntPtr handle) : base(handle)
        {
        }
        #endregion

        #region Overrides

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            if (ApplicationData.Current.NewAppointment != null)
            {
                Appointment a = ApplicationData.Current.NewAppointment;
                DateLabel.Text = $"{a.StartDate:MMM dd, yyyy}";
                TimeLabel.Text = $"{a.StartDate:h:mm} - {a.EndDate:h:mm tt}";
                PurposeLabel.Text = a.AppointmentType.DisplayLabel;
                //TO DO: Change this when added the ability to change branch
                Branch b = ApplicationData.Current.HomeBranch;
                BranchLabel.Text = b.Name;
                Address1Label.Text = b.Street1;
                Address2Label.Text = $"{b.City}, {b.Province} {b.PostalCode}";
                PhoneLabel.Text = b.PhoneNumber;
            }
        }
        #endregion

        #region Methods
        partial void ConfirmButton_TouchUpInside(UIButton sender)
        {
            StartConfirmation();
        }

        private void StartConfirmation()
        {
            CancelButton.Enabled = false;
            ConfirmButton.Enabled = false;
            //ProgressRing.Hidden = false;
            //ProgressRing.StartAnimating();
            //open a progress alert
            ProgressAlert = UIAlertController.Create("Confirm Appointment", "Confirming appointment please wait...", UIAlertControllerStyle.Alert);
            PresentViewController(ProgressAlert, true, null);

            Task.Run(async () =>
            {
                ConfirmationResponse response = await ConfirmAppointmentAsync();
                if (response == null)
                {
                    ShowError(response);
                }
                else
                {
                    if (response.Result == 1)
                    {
                        //refresh appointment data
                        ApplicationData.Current.GetClientAppointments();
                        //success
                        ShowSuccess(response);
                    }
                    else
                    {
                        //error
                        ShowError(response);
                    }
                }
            });
        }

        private void ShowSuccess(ConfirmationResponse Response)
        {
            
            InvokeOnMainThread(() =>
            {
                ProgressAlert.DismissViewController(true, null);
                var alert = UIAlertController.Create("Appointment Confirmed", $"Your appointment is confirmed. Your confirmation number is: {Response.ConfirmationNumber}", UIAlertControllerStyle.Alert);

                alert.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Default, OnConfirmComplete));

                PresentViewController(alert, true, null);
            });
        }

        private void OnConfirmComplete(UIAlertAction obj)
        {
            //goto the home screen
            var controller = Storyboard.InstantiateInitialViewController();

            if (controller != null)
            {
                PresentViewController(controller, true, null);
            }
        }

        private void ShowError(ConfirmationResponse Response)
        {
            
            InvokeOnMainThread(() =>
            {
                ProgressAlert.DismissViewController(true, null);
                var alert = UIAlertController.Create("Schedule Error", $"Unable to confirm appointment: {Response?.ErrorMessage}", UIAlertControllerStyle.Alert);
                alert.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Default, null));
                PresentViewController(alert, true, null);
                CancelButton.Enabled = true;
                ConfirmButton.Enabled = true;
            });
        }

        private async Task<ConfirmationResponse> ConfirmAppointmentAsync()
        {
            ScheduleDataSource ds = new ScheduleDataSource();
            Appointment a = ApplicationData.Current.NewAppointment;
            ConfirmationRequest request = new ConfirmationRequest()
            {
                AppointmentType = a.AppointmentType.Value,
                AppointmentReason = a.AppointmentSubType.Value,
                AppointmentSource = Appointment.MOBILE_APP_SOURCE,
                AdvisorEmailAddress = a.AdvisorEmail,
                AppointmentLanguage = a.AppointmentLanguage,
                BranchNumber = a.BranchNumber,
                ClientNumber = ApplicationData.Current.Client.CustomerNumber,
                SendEmailConfirmation = true,
                StartTimeUtc = a.StartDate.ToUniversalTime().ToString("o"),
                EndTimeUtc = a.EndDate.ToUniversalTime().ToString("o"),
                IncludeIcsFile = true,
                UiLanguageCode = 1033,
                PreferredDateUtc = a.StartDate.Date,
                AdvisorComments = string.Empty,
                ClientComments = string.Empty
            };
            ConfirmationResponse response = await ds.ConfirmAppointmentAsync(request);
            return response;
        }
        #endregion

        #region Properties
        private UIAlertController ProgressAlert { get; set; }
        #endregion
    }
}