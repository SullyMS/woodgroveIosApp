using System;
using CalServices.Dynamics.Base;
using CalServices.Utils;
using Newtonsoft.Json;

namespace CalServices.Models
{
    public class D365Appointment : BaseEntity
    {
        public D365Appointment() : base(ENTITY_NAME)
        {
        }

        #region Properties
        [JsonProperty("subject")]
        public string ConfirmationNumber { get; set; }
        [JsonProperty("scheduledstart")]
        public DateTime StartDate { get; set; }
        [JsonProperty("scheduleddurationminutes")]
        public int? Duration { get; set; }
        [JsonProperty("activityid")]
        public string Id { get; set; }
        [JsonProperty("ms_preferreddate")]
        public DateTime? PreferredDate { get; set; }
        [JsonProperty("ms_appointmentlocation")]
        public int? LocationTypeCode { get; set; }
        [JsonProperty("ms_appointmentlanguage")]
        public int AppointmentLanguage { get; set; }
        [JsonProperty("_ms_branchid_value")]
        public string BranchId { get; set; }
        [JsonProperty("ms_sendemailnotification")]
        public bool SendEmailNotification { get; set; }
        [JsonProperty("ms_appointmenttype")]
        public int AppointmentTypeCode { get; set; }
        [JsonProperty("ms_sendclientcalendarinvite")]
        public bool AttachCalFile { get; set; }
        [JsonProperty("ms_appointmentsource")]
        public int AppointmentSourceCode { get; set; }
        [JsonProperty("ms_appointmentsubtype")]
        public int AppointmentSubTypeCode { get; set; }
        [JsonProperty("_ms_clientid_value")]
        public string ClientId { get; set; }
        [JsonProperty("scheduledend")]
        public DateTime EndDate { get; set; }
        [JsonProperty("ms_scheduleengineerrorcode")]
        public int? ScheduleEngineErrorCode { get; set; }
        [JsonProperty("ms_customercomments")]
        public string CustomerComments { get; set; }
        [JsonProperty("ms_branchid_ms_branchappointment")]
        public Branch Branch { get; set; }
        [JsonProperty("statuscode")]
        public int StatusCode { get; set; }
        [JsonProperty("_ms_advisorid_value")]
        public string AdvisorId { get; set; }
        [JsonProperty("ms_advisorid_ms_branchappointment")]
        public SystemUser Advisor { get; set; }
        #endregion

        #region NonDynamicsProperties
        [JsonIgnore]
        public string Status
        {
            get
            {
                switch (StatusCode)
                {
                    case 1:
                        return "Draft";
                    case 717660000:
                        return "Confirmed";
                    case 717660001:
                        return "Checked In";
                    case 717660002:
                        return "Request Confirmation";
                    case 717660003:
                        return "Scheduling Error";
                }
                return string.Empty;
            }
        }

        public string AppointmentReason
        {
            get
            {
                if (ReferenceData.Data.AppointmentTypesDictionary != null)
                {
                    if (ReferenceData.Data.AppointmentTypesDictionary.ContainsKey(AppointmentTypeCode))
                    {
                        return ReferenceData.Data.AppointmentTypesDictionary[AppointmentTypeCode].Name;
                    }
                }
                return string.Empty;
            }
        }
        #endregion



        #region Constants
        public const string ENTITY_NAME = "ms_branchappointment";
        public static string[] FIELDS = new string[19] { "subject", "scheduledstart", "scheduleddurationminutes", "activityid", "ms_preferreddate", "ms_appointmentlocation",
            "ms_appointmentlanguage", "_ms_branchid_value", "ms_sendemailnotification", "ms_appointmenttype", "ms_sendclientcalendarinvite", "ms_appointmentsource",
            "ms_appointmentsubtype", "_ms_clientid_value", "ms_scheduleengineerrorcode", "ms_customercomments", "scheduledend", "statuscode", "_ms_advisorid_value"};
        public const int CONFIRMED_STATUS = 717660000;
        public const string STATUS_FIELD = "statuscode";
        public const string CLIENT_ID_FIELD = "_ms_clientid_value";
        public const string START_DATE_FIELD = "scheduledstart";
        public const string BRANCH_ID_FIELD = "ms_branchid_ms_branchappointment";
        public const string ADVISOR_ID_NAV_FIELD = "ms_advisorid_ms_branchappointment";
        #endregion
    }
}
