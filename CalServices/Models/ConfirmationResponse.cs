using Newtonsoft.Json;

namespace CalServices.Models
{
    public class ConfirmationResponse
    {
        [JsonProperty("ConfirmationNumber")]
        public string ConfirmationNumber { get; set; }

        [JsonProperty("AppointmentId")]
        public string AppointmentId { get; set; }

        [JsonProperty("ExchangeAppointmentId")]
        public string ExchangeAppointmentId { get; set; }

        [JsonProperty("UILanguageCode")]
        public long UiLanguageCode { get; set; }

        [JsonProperty("ErrorMessage")]
        public string ErrorMessage { get; set; }

        [JsonProperty("ErrorCode")]
        public long ErrorCode { get; set; }

        [JsonProperty("Result")]
        public long Result { get; set; }

        [JsonProperty("InnerErrorMessage")]
        public string InnerErrorMessage { get; set; }
    }
}
