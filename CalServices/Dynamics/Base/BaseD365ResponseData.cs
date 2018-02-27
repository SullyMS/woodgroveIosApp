using Newtonsoft.Json;

namespace CalServices.Dynamics.Base
{
    public abstract class BaseD365ResponseData : IServiceErrorResponse
    {
        #region Members
        private bool _isSuccessfull = true;
        #endregion

        #region Properties
        [JsonProperty("@odata.context")]
        public string Context { get; set; }
        [JsonProperty("@odata.count")]
        public int Count { get; set; }
        [JsonProperty("value")]
        public object Value { get; set; }
        #endregion

        #region Interface
        [JsonIgnore]
        public bool IsSuccessFull
        {
            get => _isSuccessfull;
            set { _isSuccessfull = value; }
        }
        [JsonIgnore]
        public string ErrorMessage { get; set; }
        #endregion
    }
}
