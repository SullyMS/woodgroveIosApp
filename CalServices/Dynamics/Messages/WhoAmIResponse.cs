using CalServices.Dynamics.Base;
using Newtonsoft.Json;

namespace CalServices.Dynamics.Messages
{
    public class WhoAmIResponse : BaseD365ResponseData
    {
        [JsonProperty("BusinessUnitId")]
        public string BusinessUnitId { get; set; }
        [JsonProperty("UserId")]
        public string UserId { get; set; }
        [JsonProperty("OrganizationId")]
        public string OgranizationId { get; set; }
    }
}
