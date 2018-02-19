using Foundation;
using System;
using UIKit;
using CalendarServices.Datasources;
using System.Threading.Tasks;
using CalendarServices.Models;

namespace WoodgroveBankApp
{
    public partial class AppointmentsTableViewController : UITableViewController
    {
        #region Members
        private AppointmentsDataSource _datasource = null;
        #endregion

        public AppointmentsTableViewController(IntPtr handle) : base(handle)
        {
            _datasource = new AppointmentsDataSource();
            _datasource.Load();
        }

        #region Methods
        public override nint RowsInSection(UITableView tableView, nint section)
        {
            return _datasource.Appointments.Count;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            Appointment appointment = _datasource.Appointments[indexPath.Row];
            AppointmentCell cell = (AppointmentCell)tableView.DequeueReusableCell(CELL_ID, indexPath);

            cell.Update(appointment);
                
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