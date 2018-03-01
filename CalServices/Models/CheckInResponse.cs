using Newtonsoft.Json;

namespace CalServices.Models
{
    public class CheckInResponse
    {
        public CheckInResponse()
        {
        }
        #region Properties
        [JsonProperty("CheckedIn")]
        public bool CheckedIn { get; set; }
        [JsonProperty("UILanguageCode")]
        public int? UILanguageCode { get; set; }
        [JsonProperty("ErrorMessage")]
        public string ErrorMessage { get; set; }
        [JsonProperty("ErrorCode")]
        public int? ErrorCode { get; set; }
        [JsonProperty("Result")]
        public int Result { get; set; }
        [JsonProperty("InnerErrorMessage")]
        public string InnerErrorMessage { get; set; }
        #endregion
    }
}
