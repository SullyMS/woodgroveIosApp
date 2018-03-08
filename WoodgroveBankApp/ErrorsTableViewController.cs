using Foundation;
using System;
using UIKit;
using WoodgroveBankApp.Common;

namespace WoodgroveBankApp
{
    public partial class ErrorsTableViewController : UITableViewController
    {
        public ErrorsTableViewController (IntPtr handle) : base (handle)
        {
        }

		public override void ViewDidLoad()
		{
            base.ViewDidLoad();
            //add the new appointment button
            NavigationItem.LeftBarButtonItem = new UIBarButtonItem("Close", UIBarButtonItemStyle.Plain, OnCloseButton);
        }

        private void OnCloseButton(object sender, EventArgs e)
        {
            this.DismissViewController(true, null);
        }

		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);
		}

		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
            UITableViewCell cell = tableView.DequeueReusableCell(CELL_ID);
            AppError error = ApplicationData.Current.Errors[indexPath.Row];
            cell.TextLabel.Text = $"{error.ClassName}.{error.Method}";
            cell.DetailTextLabel.Text = error.ErrorMessage;
            return cell;
		}

		public override nint RowsInSection(UITableView tableView, nint section)
		{
            if (ApplicationData.Current.Errors != null)
            {
                return ApplicationData.Current.Errors.Count;
            }
            return 0;
		}

		public override void AccessoryButtonTapped(UITableView tableView, NSIndexPath indexPath)
		{
            var error = ApplicationData.Current.Errors[indexPath.Row];

            var controller = UIAlertController.Create("Error Details",
                                                      error.ErrorMessage, UIAlertControllerStyle.Alert);
            controller.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));

            PresentViewController(controller, true, null);
		}

		private const string CELL_ID = "ErrorCell";
	}
}