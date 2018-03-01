using Foundation;
using System;
using UIKit;
using CalServices.Models;

namespace WoodgroveBankApp
{
    public partial class AppointmentCell : UITableViewCell
    {
        public AppointmentCell(IntPtr handle) : base(handle)
        {
        }

        #region Methods
        public void Update(D365Appointment Appointment)
        {
            TitleLabel.Text = Appointment.Branch.Name;
            AddressLabel.Text = $"{Appointment.Branch.Street1} {Appointment.Branch.City}";
            DateLabel.Text = $"{Appointment.StartDate:MMMM d}";
            TimeLabel.Text = $"{Appointment.StartDate:h:mm} - {Appointment.EndDate:h:mm tt}";
            ReasonLabel.Text = Appointment.AppointmentReason;
            StatusLabel.Text = Appointment.Status;
            //image
            IconImage.Image = UIImage.FromBundle("WoodIcon");
            AdvisorLabel.Text = Appointment.Advisor.FullName;
            NumberLabel.Text = Appointment.ConfirmationNumber;
        }
        #endregion

        #region Constants
        public const float HEIGHT = 100;
        #endregion
    }
}