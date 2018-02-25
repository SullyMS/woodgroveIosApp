using Foundation;
using System;
using UIKit;
using System.Threading.Tasks;
using System.Collections.Generic;
using CalServices.Models;
using CalServices.DataSources;

namespace WoodgroveBankApp
{
    public partial class AppReasonViewController : UIViewController
    {
        public AppReasonViewController (IntPtr handle) : base (handle)
        {
        }

        #region Properties
        private List<EntityStatus> AppointmentReasons { get; set; }
        #endregion

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            if (AppointmentReasons == null)
            {
                Task getApptReaTask = Task.Run(async () =>
                {
                    ApptReasonDataSource ds = new ApptReasonDataSource();
                    if (await ds.Load())
                    {
                        AppointmentReasons = ds.AppointmentTypes;
                    }
                });
                getApptReaTask.Wait();
            }
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            //NavigationItem.BackBarButtonItem.Title = "Back";

            //set the table source
            TableView.Source = new ApptTypeSource(AppointmentReasons);
            TableView.ReloadData();
        }
    }

    public class ApptTypeSource : UITableViewSource
    {
        public ApptTypeSource(List<EntityStatus> ApptTypes){
            AppointmentTypes = ApptTypes;
        }

        public List<EntityStatus> AppointmentTypes { get; private set; }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return AppointmentTypes.Count;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            UITableViewCell cell = tableView.DequeueReusableCell("CellId", indexPath);
            if (AppointmentTypes != null)
            {
                EntityStatus apptType = AppointmentTypes[indexPath.Row];
                cell.TextLabel.Text = apptType.DisplayLabel;
            }
            return cell;
        }
    }
}