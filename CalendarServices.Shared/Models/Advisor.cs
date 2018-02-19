using System;
namespace CalendarServices.Models
{
    public class Advisor
    {
        public Advisor()
        {
        }

        #region Properties
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get => $"{FirstName} {LastName}"; }
        public string AdvisorId { get; set; }
        public string Email { get; set; }
        #endregion
    }
}
