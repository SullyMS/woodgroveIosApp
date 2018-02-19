using System;
namespace CalendarServices.Models
{
    public class Appointment
    {
        public Appointment()
        {
        }

        #region Properties
        public string AppointmentId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public TimeSpan Duration { get; set; }
        public string BranchId { get; set; }
        public Branch Location { get; set; }
        public string ClientId { get; set; }
        public string AdvisorId { get; set; }
        public Client Client { get; set; }
        public Advisor Advisor { get; set; }
        public AppointmentStatus Status { get; set; }
        public AppointmentReasons Reason { get; set; }
        #endregion
    }

    public enum AppointmentStatus
    {
        Confirmed,
        Complete
    }

    public enum AppointmentReasons
    {
        Realestate,
        Credit,
        Accounts,
        Investing
    }

}
