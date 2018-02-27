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

        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            //load the client data
            if (ApplicationData.Current.Client == null)
            {
                ShowErrorState();
            }
            else
            {
                UpdateClientData();
                StopLoadState();
            }
        }

        private void UpdateClientData()
        {
            Client client = ApplicationData.Current.Client;
            if (client != null)
            {
                WelcomeLabel.Text = $"Welcome {ApplicationData.Current.Client.FirstName}";
                //set the client image
                if (!string.IsNullOrEmpty(client.Image))
                {
                    ClientImage.Image = ImageConverter.GetImageFromBase64String(client.Image);
                }
            }
        }

        private void ShowErrorState()
        {
            WelcomeLabel.Text = "Error";
        }

        private void StopLoadState()
        {
            ProgressRing.StopAnimating();
            ProgressRing.Hidden = true;
        }

    }
}