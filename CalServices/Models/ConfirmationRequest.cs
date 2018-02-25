using Newtonsoft.Json;

namespace CalServices.Models
{

    public class ConfirmationRequest
    {
        [JsonProperty("StartTimeUTC")]
        public string StartTimeUtc { get; set; }

        [JsonProperty("EndTimeUTC")]
        public string EndTimeUtc { get; set; }

        [JsonProperty("AdvisorEmailAddress")]
        public string AdvisorEmailAddress { get; set; }

        [JsonProperty("BranchNumber")]
        public string BranchNumber { get; set; }

        [JsonProperty("AppointmentType")]
        public long AppointmentType { get; set; }

        [JsonProperty("AppointmentReason")]
        public long AppointmentReason { get; set; }

        [JsonProperty("SendEmailConfirmation")]
        public bool SendEmailConfirmation { get; set; }

        [JsonProperty("IncludeICSFile")]
        public bool IncludeIcsFile { get; set; }

        [JsonProperty("AppointmentLanguage")]
        public long AppointmentLanguage { get; set; }

        [JsonProperty("ClientNumber")]
        public string ClientNumber { get; set; }

        [JsonProperty("ClientComments")]
        public string ClientComments { get; set; }

        [JsonProperty("AdvisorComments")]
        public string AdvisorComments { get; set; }

        [JsonProperty("PreferredDateUTC")]
        public System.DateTimeOffset PreferredDateUtc { get; set; }

        [JsonProperty("AppointmentSource")]
        public long AppointmentSource { get; set; }

        [JsonProperty("CRMAppointmentRecordId")]
        public string CrmAppointmentRecordId { get; set; }

        [JsonProperty("IsRequestFromCRM")]
        public bool IsRequestFromCrm { get; set; }

        [JsonProperty("UILanguageCode")]
        public long UiLanguageCode { get; set; }
    }
}
