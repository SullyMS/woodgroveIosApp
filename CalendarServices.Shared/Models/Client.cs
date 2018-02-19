using System;
namespace CalendarServices.Models
{
    public class Client
    {
        public Client()
        {
        }

        #region Properties
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get => $"{FirstName} {LastName}"; }
        public string ClientId { get; set; }
        #endregion
    }
}
