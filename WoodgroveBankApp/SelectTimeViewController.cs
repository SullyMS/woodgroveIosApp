using Foundation;
using System;
using UIKit;
using CalServices.DataSources;
using System.Threading.Tasks;
using CalServices.Models;
using WoodgroveBankApp.Common;

namespace WoodgroveBankApp
{
    public partial class SelectTimeViewController : UIViewController
    {
        public SelectTimeViewController(IntPtr handle) : base(handle)
        {
        }

        #region Properties
        private ScheduleDataSource DataSource { get; set; }
        private DateTime StartDate { get; set; }
        private DateTime EndDate { get; set; }
        private DateTime SelectedDay { get; set; }
        private ScheduleResults Schedule {get;set;}
        #endregion

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            //setup pull to refresh
            UIRefreshControl refreshControl = new UIRefreshControl();
            refreshControl.ValueChanged += async (sender, e) => {
                await LoadScheduleAsync();
                BeginInvokeOnMainThread(() => {
                    TableView.ReloadData();
                    refreshControl.EndRefreshing();
                });
            };
            TableView.RefreshControl = refreshControl;
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            StartDate = DateTime.Now.Date;
            EndDate = StartDate.AddDays(5);
            SelectedDay = StartDate;
            DayText.Text = $"{SelectedDay: MMM dd}";
            StartLoad();
        }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            base.PrepareForSegue(segue, sender);
            //set the seleted times on the appointment
            TimeSlotSource source = TableView.Source as TimeSlotSource;
            if (source != null)
            {
                TimeSlot ts = source.TimeSlots[TableView.IndexPathForSelectedRow.Row];
                ApplicationData.Current.NewAppointment.StartDate = ts.StartTimeUtc.ToLocalTime();
                ApplicationData.Current.NewAppointment.EndDate = ts.EndTimeUtc.ToLocalTime();
                ApplicationData.Current.NewAppointment.AdvisorEmail = ts.AvailableStaff[0];
            }
        }

        partial void PreviousButton_TouchUpInside(UIButton sender)
        {
            if (SelectedDay > StartDate)
            {
                SelectedDay = SelectedDay.Subtract(new TimeSpan(1, 0, 0, 0));
                DayText.Text = $"{SelectedDay: MMM dd}";
                StartLoad();
            }
        }

        partial void NextButton_TouchUpInside(UIButton sender)
        {
            if (SelectedDay < EndDate)
            {
                SelectedDay = SelectedDay.AddDays(1);
                DayText.Text = $"{SelectedDay: MMM dd}";
                StartLoad();
            }
        }

        private void StartLoad()
        {
            ProgressRing.Hidden = false;
            ProgressRing.StartAnimating();
            Task.Run(async () =>
            {
                Schedule = null;
                await LoadScheduleAsync();

            });
        }

        private async Task LoadScheduleAsync()
        {
            if (Schedule == null)
            {
                DataSource = new ScheduleDataSource();
                Appointment a = ApplicationData.Current.NewAppointment;
                DataServiceResponse<ScheduleResults> response = await DataSource.GetAvailableTimes(StartDate,
                                                                                                    EndDate, a.BranchNumber,
                                                                                                    a.AppointmentType.Value,
                                                                                                    a.AppointmentSubType.Value,
                                                                                                    a.AppointmentLanguage);
                if (response.Success)
                {
                    if (string.IsNullOrEmpty(response.Data.ErrorMessage))
                    {
                        Schedule = response.Data;
                        foreach (ScheduleResult r in Schedule.ScheduleDays)
                        {
                            if (r.ScheduleDate.Date.Equals(SelectedDay.Date))
                            {
                                ReloadTable(new TimeSlotSource(r.TimeSlots));
                                break;
                            }
                        }
                        InvokeOnMainThread(() =>
                        {
                            ProgressRing.StopAnimating();
                        });
                    }
                    else
                    {
                        //scheduling system error
                        InvokeOnMainThread(() =>
                        {
                            ProgressRing.StopAnimating();
                            var alert = UIAlertController.Create("Schedule Engine Error", $"{response.Data.ErrorMessage}", UIAlertControllerStyle.Alert);
                            alert.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Default, null));
                            PresentViewController(alert, true, null);
                        });
                    }
                }else{
                    //error
                    InvokeOnMainThread(() =>
                    {
                        ProgressRing.StopAnimating();
                        var alert = UIAlertController.Create("Error", $"Load Error: {response.ErrorMessage}", UIAlertControllerStyle.Alert);
                        alert.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Default, null));
                        PresentViewController(alert, true, null);
                    });
                }
            }
            else
            {
                foreach (ScheduleResult r in Schedule.ScheduleDays)
                {
                    if (r.ScheduleDate.Date.Equals(SelectedDay.Date))
                    {
                        ReloadTable(new TimeSlotSource(r.TimeSlots));
                        break;
                    }
                }
            }

        }
        private void ReloadTable(TimeSlotSource Source)
        {
            InvokeOnMainThread(()=>{
                TableView.Source = Source;
                TableView.ReloadData();
                ProgressRing.StopAnimating();
                ProgressRing.Hidden = true;
            
            });
        }
    }




    public class TimeSlotSource :UITableViewSource
    {
        
        public TimeSlotSource(TimeSlot[] TimeSlots){
            this.TimeSlots = TimeSlots;
        }

        public TimeSlot[] TimeSlots { get; private set; }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            if (TimeSlots != null)
            {
                return TimeSlots.Length;
            }
            return 0;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            UITableViewCell cell = tableView.DequeueReusableCell(CELL_ID);
            if (cell != null)
            {
                if (TimeSlots != null)
                {
                    TimeSlot ts = TimeSlots[indexPath.Row];
                    cell.TextLabel.Text = $"{ts.StartTime: h:mm} - {ts.EndTime: h:mm tt}";
                }
            }

            return cell;
        }

        private const string CELL_ID = "TimeSlotCell";
    }
}