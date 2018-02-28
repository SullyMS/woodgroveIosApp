using Foundation;
using System;
using UIKit;
using System.Collections.Generic;
using CalServices.Models;
using WoodgroveBankApp.Common;

namespace WoodgroveBankApp
{
    public partial class AppReasonViewController : UIViewController
    {
        public AppReasonViewController (IntPtr handle) : base (handle)
        {
        }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            base.PrepareForSegue(segue, sender);
            //set the appointment reason
            AppReasonViewController controller = segue.SourceViewController as AppReasonViewController;
            AppointmentReason reason = ApplicationData.Current.AppointmentTypes[controller.TableView.IndexPathForSelectedRow.Row];
            ApplicationData.Current.NewAppointment.AppointmentType = new EntityStatus { Value = reason.AppointmentTypeCode, DisplayLabel = reason.Name };
            ApplicationData.Current.NewAppointment.AppointmentSubType = new EntityStatus { Value = reason.AppointmentSubTypeCode };
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            //NavigationItem.BackBarButtonItem.Title = "Back";

            //set the table source
            TableView.Source = new ApptTypeSource(ApplicationData.Current.AppointmentTypes);
            TableView.ReloadData();
        }
    }

    public class ApptTypeSource : UITableViewSource
    {
        public ApptTypeSource(List<AppointmentReason> ApptTypes){
            AppointmentTypes = ApptTypes;
        }

        public List<AppointmentReason> AppointmentTypes { get; private set; }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return AppointmentTypes.Count;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            UITableViewCell cell = tableView.DequeueReusableCell("CellId", indexPath);
            if (AppointmentTypes != null)
            {
                AppointmentReason apptType = AppointmentTypes[indexPath.Row];
                cell.TextLabel.Text = apptType.Name;
                cell.DetailTextLabel.Text = apptType.Description;
            }
            return cell;
        }


    }
}