using Foundation;
using System;
using UIKit;
using CalServices.DataSources;
using System.Threading.Tasks;
using CalServices.Models;

namespace WoodgroveBankApp
{
    public partial class AppointmentsTableViewController : UITableViewController
    {
        #region Members
        private AppointmentsDataSource _datasource = null;
        #endregion

        public AppointmentsTableViewController(IntPtr handle) : base(handle)
        {
            _datasource = new AppointmentsDataSource("123456");

        }

        #region Methods


        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            Task.Factory.StartNew( () => LoadDataAsync());
        }

        public async Task LoadDataAsync()
        {
            await _datasource.Load();
            InvokeOnMainThread(() =>
            {
                TableView.ReloadData();
            });
        }


        public override nint RowsInSection(UITableView tableView, nint section)
        {
            if (_datasource.Status == DataSourceStatus.Loaded)
            {
                return _datasource.Appointments.Count;
            }
            return 0;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            AppointmentCell cell = (AppointmentCell)tableView.DequeueReusableCell(CELL_ID, indexPath);
            if (_datasource.Status == DataSourceStatus.Loaded)
            {
                Appointment appointment = _datasource.Appointments[indexPath.Row];
                cell.Update(appointment);
            }
            return cell;
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            // Create the View Controller in the Main storyboard.
            var storyboard = UIStoryboard.FromName("Main", null);
            var detailViewController = (AppDetailViewController)storyboard.InstantiateViewController("AppDetailViewController");

            // Set the email details
            Appointment appointment = _datasource.Appointments[indexPath.Row];
            detailViewController.Appointment = appointment;

            // Show the new page as a "modal"
            this.ShowDetailViewController(detailViewController, this);
        }

        public override nfloat GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
        {
            return AppointmentCell.HEIGHT;
        }
        #endregion

        #region Contsants
        private const string CELL_ID = "AppointmentCell";
        #endregion
    }
}