using Foundation;
using System;
using UIKit;
using WoodgroveBankApp.Common;
using CalServices.DataSources;
using System.Threading.Tasks;

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

        public async override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            //load the client data
            if (ApplicationData.Current.Client == null)
            {
                ClientDataSource = new ClientDataSource("123456");
                if (await ClientDataSource.Load())
                {
                    ApplicationData.Current.Client = ClientDataSource.Client;
                    UpdateClientData();
                }
                else
                {
                    ShowErrorState();
                }
                StopLoadState();
            }
            else
            {
                //get the home branch
                if (ApplicationData.Current.Client != null)
                {
                    BranchDataSource branchds = new BranchDataSource(ApplicationData.Current.Client.HomeBranchId);
                    if (await branchds.Load())
                    {
                        ApplicationData.Current.HomeBranch = branchds.Branch;
                    }
                }
                UpdateClientData();
                StopLoadState();
            }
        }

        private void UpdateClientData()
        {
            if (ApplicationData.Current.Client != null)
            {
                WelcomeLabel.Text = $"Welcome {ApplicationData.Current.Client.FirstName}";
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