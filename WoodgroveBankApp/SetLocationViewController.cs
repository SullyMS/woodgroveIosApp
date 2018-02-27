using Foundation;
using System;
using UIKit;
using WoodgroveBankApp.Common;
using CalServices.Models;
using MapKit;

namespace WoodgroveBankApp
{
    public partial class SetLocationViewController : UIViewController
    {
        public SetLocationViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            UIBarButtonItem nextButton = new UIBarButtonItem("Next", UIBarButtonItemStyle.Plain, OnNextButton);
            UIBarButtonItem cancelButton = new UIBarButtonItem("Cancel", UIBarButtonItemStyle.Plain, OnCancel);
            NavigationItem.RightBarButtonItem = nextButton;
            NavigationItem.LeftBarButtonItem = cancelButton;
        }

        private void OnNextButton(object sender, EventArgs e)
        {
            PerformSegue("ShowReasonView", this);
        }

        private void OnCancel(object sender, EventArgs e)
        {
            UINavigationController controller = Storyboard.InstantiateViewController("AppsViewController") as UINavigationController;
            this.ShowViewController(controller, this);
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            Branch b = ApplicationData.Current.HomeBranch;
            if (b != null)
            {
                BranchNumberLabel.Text = b.Number;
                BranchNameLabel.Text = b.Name;
                StreetLabel.Text = b.Street1;
                CityLabel.Text = $"{b.City}, {b.Province} {b.PostalCode}";
                PhoneLabel.Text = b.PhoneNumber;
                FaxLabel.Text = b.FaxNumber;
                MKPointAnnotation point = new MKPointAnnotation()
                {
                    Title = b.Name,
                    Subtitle = $"{b.Street1} {b.City}",
                    Coordinate = new CoreLocation.CLLocationCoordinate2D(b.Latitude, b.Longitude)
                };
                Map.AddAnnotation(point);
                Map.ShowAnnotations(Map.Annotations, true);
            }
        }
    }
}