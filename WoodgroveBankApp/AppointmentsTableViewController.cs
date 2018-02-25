using Foundation;
using System;
using UIKit;
using CalServices.DataSources;
using System.Threading.Tasks;
using CalServices.Models;
using System.Collections.Generic;

namespace WoodgroveBankApp
{
    public partial class AppointmentsTableViewController : UITableViewController
    {
        #region Members
        private AppointmentsTableSource _tableSource = null;
        #endregion

        public AppointmentsTableViewController(IntPtr handle) : base(handle)
        { }


        #region Methods
        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            base.PrepareForSegue(segue, sender);
            if(segue.DestinationViewController.GetType().Equals(typeof(AppDetailViewController)))
            {
                AppDetailViewController vc = segue.DestinationViewController as AppDetailViewController;
                vc.Appointment = _tableSource.Appointments[TableView.IndexPathForSelectedRow.Row];
            }
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            //add the new appointment button
            NavigationItem.RightBarButtonItem = new UIBarButtonItem("New", UIBarButtonItemStyle.Plain, OnNewAppointment);
            //load the appointments
            if (_tableSource == null)
            {
                AppointmentsDataSource ds = new AppointmentsDataSource("123456");
                Task loadTask = Task.Run(async () =>
                {
                    if(await ds.Load()){
                        _tableSource = new AppointmentsTableSource(ds.Appointments);
                    }
                });
                loadTask.Wait();
            }
        }

        private void OnNewAppointment(object sender, EventArgs e)
        {
            UINavigationController controller = Storyboard.InstantiateViewController("NewAppNavController") as UINavigationController;
            this.ShowViewController(controller, this);
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            //only load if data has not been loaded yet
            StopProgressBar();
            UpdateTable();
        }
    
        private void StopProgressBar()
        {
            ProgressRing.StopAnimating();
            ProgressRing.Hidden = true;
        }

        private void UpdateTable()
        {
            TableView.Source = _tableSource;
            TableView.ReloadData();
        }
        #endregion

    }

    public class AppointmentsTableSource : UITableViewSource
    {
        public AppointmentsTableSource(List<Appointment> Appointments)
        {
            this.Appointments = Appointments;
        }

        #region Properties
        public List<Appointment> Appointments { get; private set; }
        #endregion

        #region Methods
        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            AppointmentCell cell = (AppointmentCell)tableView.DequeueReusableCell(CELL_ID, indexPath);

            if (Appointments != null)
            {
                Appointment appointment = Appointments[indexPath.Row];
                cell.Update(appointment);
            }
            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            if (Appointments != null)
            {
                return Appointments.Count;
            }
            return 0;
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