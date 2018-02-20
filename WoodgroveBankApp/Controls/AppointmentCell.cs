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
        public void Update(Appointment Appointment)
        {
            TitleLabel.Text = Appointment.BranchNumber;
            AddressLabel.Text = "Address";
            DateLabel.Text = $"{Appointment.StartDate: MMMM d}";
            TimeLabel.Text = $"{Appointment.StartDate: h:mm} - {Appointment.EndDate: h:mm tt}";
            ReasonLabel.Text = Appointment.AppointmentType.DisplayLabel;
            StatusLabel.Text = Appointment.Status.DisplayLabel;
            //image
            IconImage.Image = UIImage.FromBundle("WoodIcon");
        }
        #endregion

        #region Constants
        public const float HEIGHT = 100;
        #endregion
    }
}