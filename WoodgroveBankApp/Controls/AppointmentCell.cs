using Foundation;
using System;
using UIKit;
using CalendarServices.Models;

namespace WoodgroveBankApp
{
    public partial class AppointmentCell : UITableViewCell
    {
        public AppointmentCell(IntPtr handle) : base(handle)
        {
        }

        #region Methods
        public void Update(Appointment Appointment)
        {
            TitleLabel.Text = Appointment.Location.Name;
            AddressLabel.Text = Appointment.Location.Address;
            DateLabel.Text = $"{Appointment.StartDate: MMMM d}";
            TimeLabel.Text = $"{Appointment.StartDate: h:mm} - {Appointment.EndDate: h:mm tt}";
            ReasonLabel.Text = Appointment.Reason.ToString();
            StatusLabel.Text = Appointment.Status.ToString();
            //image
            IconImage.Image = UIImage.FromBundle("WoodIcon");
        }
        #endregion

        #region Constants
        public const float HEIGHT = 100;
        #endregion
    }
}