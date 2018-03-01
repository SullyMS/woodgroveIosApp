using Newtonsoft.Json;

namespace CalServices.Models
{
    public class CancelAppointmentResponse
    {
        #region Properties
        [JsonProperty("CancelationConfirmed")]
        public bool CancellationConfirmed { get; set; }
        [JsonProperty("UILanguageCode")]
        public int? UILanguageCode { get; set; }
        [JsonProperty("ErrorMessage")]
        string ErrorMessage { get; set; }
        [JsonProperty("ErrorCode")]
        public int? ErrorCode { get; set; }
        [JsonProperty("Result")]
        public int? Result { get; set; }
        [JsonProperty("InnerErrorMessage")]
        public string InnerErrorMessage { get; set; }
        #endregion
    }
}
