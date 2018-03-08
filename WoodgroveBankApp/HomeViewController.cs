using System;
using UIKit;
using WoodgroveBankApp.Common;
using CalServices.DataSources;
using CalServices.Models;

namespace WoodgroveBankApp
{
    public partial class HomeViewController : UIViewController
    {
        


        public HomeViewController (IntPtr handle) : base (handle)
        {
        }

        private ClientDataSource ClientDataSource { get; set; }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            //setup the scroll viewer
            PictureScrollView.ContentSize = PictureView.Frame.Size;
            PictureScrollView.Scrolled += (sender, e) =>
            {
                PicPageControl.CurrentPage = (nint)(PictureScrollView.ContentOffset.X / PictureScrollView.Frame.Width);
            };
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            //load the client data
            if (ApplicationData.Current.HasErrors)
            {
                ShowErrorState();
            }
            else
            {
                UpdateClientData();
                StopLoadState();
                //set the appointment count
                NewAppNavController t = (NewAppNavController)TabBarController.ViewControllers[1];
                t?.UpdateAppointmentsCount();
            }
        }

        private void UpdateClientData()
        {
            Client client = ApplicationData.Current.Client;
            if (client != null)
            {
                WelcomeLabel.Text = $"Welcome back \r\n{ApplicationData.Current.Client.FirstName}";
                //set the client image
                if (!string.IsNullOrEmpty(client.Image))
                {
                    ClientImage.Image = ImageConverter.GetImageFromBase64String(client.Image);
                    ClientImage.Layer.BorderWidth = 3;
                    ClientImage.Layer.BorderColor = new UIColor(red: 0.0784f, green: 0.4392f, blue: 0f, alpha: 1.0f).CGColor;
                }
            }
        }

        private void ShowErrorState()
        {
            WelcomeLabel.Text = $"Errors {ApplicationData.Current.Errors.Count}";
        }

        private void StopLoadState()
        {
            ProgressRing.StopAnimating();
            ProgressRing.Hidden = true;
        }

    }
}