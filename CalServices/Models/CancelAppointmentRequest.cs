using Newtonsoft.Json;

namespace CalServices.Models
{
    public class CancelAppointmentRequest
    {
        [JsonProperty("ConfirmationNumber")]
        public string ConfirmationNumber { get; set; }

        [JsonProperty("IsRequestFromCRM")]
        public bool IsRequestFromCrm { get; set; }

        [JsonProperty("UILanguageCode")]
        public long UiLanguageCode { get; set; }
    }
}
