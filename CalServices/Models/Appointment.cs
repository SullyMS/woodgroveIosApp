using System;
using Newtonsoft.Json;

namespace CalServices.Models
{
    public class Appointment
    {
        public Appointment()
        {
        }

        #region Properties
        [JsonProperty("Id")]
        public string AppointmentId { get; set; }
        [JsonProperty("ExchangeApptId")]
        public string ExchnageApptId { get; set; }
        [JsonProperty("Status")]
        public EntityStatus Status { get; set; }
        [JsonProperty("AdvisorComments")]
        public string AdvisorComments { get; set; }
        [JsonProperty("ClientComments")]
        public string ClientComments { get; set; }
        [JsonProperty("StartDate")]
        public DateTime StartDate { get; set; }
        [JsonProperty("EndDate")]
        public DateTime EndDate { get; set; }
        [JsonProperty("PreferredDate")]
        public DateTime PreferredDate { get; set; }
        [JsonProperty("SendEmailNotification")]
        public bool SendEmailNotification { get; set; }
        [JsonProperty("AttachICSFile")]
        public bool AttachICSFile { get; set; }
        [JsonProperty("AppointmentSource")]
        public EntityStatus AppointmentSource { get; set; }
        [JsonProperty("BranchId")]
        public string BranchId { get; set; }
        [JsonProperty("ClientId")]
        public string ClientId { get; set; }
        [JsonProperty("ConfirmationNumber")]
        public string ConfirmationNumber { get; set; }
        [JsonProperty("AppointmentSubType")]
        public EntityStatus AppointmentSubType { get; set; }
        [JsonProperty("AppointmentType")]
        public EntityStatus AppointmentType { get; set; }
        [JsonProperty("AdvisorId")]
        public string AdvisorId { get; set; }
        [JsonProperty("AppointmentLanguage")]
        public int AppointmentLanguage { get; set; }
        [JsonProperty("AdvisorFullName")]
        public string AdvisorFullName { get; set; }
        [JsonProperty("AdvisorEmail")]
        public string AdvisorEmail { get; set; }
        [JsonProperty("AdvisorNumber")]
        public string AdvisorNumber { get; set; }
        [JsonProperty("BranchNumnber")]
        public string BranchNumber { get; set; }
        #endregion

        #region Constants
        public const int MOBILE_APP_SOURCE = 717660005;
        #endregion
    }

    public class EntityStatus
    {
        [JsonProperty("EntityName")]
        public string EntityName { get; set; }
        [JsonProperty("AttributeName")]
        public string AttributeName { get; set; }
        [JsonProperty("Value")]
        public int Value { get; set; }
        [JsonProperty("DisplayLabel")]
        public string DisplayLabel { get; set; }
        [JsonProperty("LanguageCode")]
        public int LanguageCode { get; set; }
    }



}
