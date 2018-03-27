using CalServices.Utils;
using Foundation;
using System;
using System.Threading.Tasks;
using UIKit;
using WoodgroveBankApp.Common;

namespace WoodgroveBankApp
{
    public partial class AboutScreenViewController : UIViewController
    {
        public AboutScreenViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            //set the navigation bar color
            NavigationBar.BackgroundColor = ScreenColors.TitleBarBackground;
            VersonLabel.Text = $"Version: {NSBundle.MainBundle.InfoDictionary["CFBundleShortVersionString"].ToString()}";
            ContentView.BackgroundColor = UIColor.White;
            View.BackgroundColor = ScreenColors.TitleBarBackground;
            ConnectedToLabel.Text = $"Environment: {ApplicationSettings.Current.DynamicsSettings.EnvironmentName}";
            CrmLabel.Text = $"D365: {ApplicationSettings.Current.DynamicsSettings.InstanceUrl}";
            ApiLabel.Text = $"API: {ApplicationSettings.Current.DynamicsSettings.ApiBaseUrl}";
            CalServiceLabel.Text = $"CalSvc: {ApplicationSettings.Current.DynamicsSettings.CalServicesUrl}";
        }

        partial void ReloadButton_TouchUpInside(UIButton sender)
        {
            //open a progress alert
            KeyVault.Tokens.Reset();
            ProgressAlert = UIAlertController.Create("Reload Application Data", "Reloading please wait...", UIAlertControllerStyle.Alert);
            PresentViewController(ProgressAlert, true, null);
            Task reloadTask = Task.Run(async () =>
            {
                await ApplicationData.Current.LoadApplicationData();
                BeginInvokeOnMainThread(() => {
                    ProgressAlert.DismissViewController(true, null);
                    if (ApplicationData.Current.Errors.Count == 0)
                    {
                        var alert = UIAlertController.Create("Success", $"Application Data Reloaded Successfully", UIAlertControllerStyle.Alert);
                        alert.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Default, null));
                        PresentViewController(alert, true, null);
                    }
                    else
                    {
                        var alert = UIAlertController.Create("Error", $"Could not reload data. {ApplicationData.Current.Errors.Count} errors encountered.", UIAlertControllerStyle.Alert);
                        alert.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Default, null));
                        PresentViewController(alert, true, null);
                    }
                });
            });


        }

        #region Properties
        private UIAlertController ProgressAlert { get; set; }
        #endregion
    }
}