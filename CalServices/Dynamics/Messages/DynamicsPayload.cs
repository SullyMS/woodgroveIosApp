using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CalServices.Dynamics.Messages
{
    public class DynamicsPayload
    {
        public DynamicsPayload()
        {
        }

        [JsonProperty("@odata.context")]
        public string Context { get; set; }
        [JsonProperty("value")]
        public JArray Value { get; set; }
    }
}
