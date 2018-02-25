using System;
using Newtonsoft.Json;

namespace CalServices.Models
{
    public class Client
    {
        public Client()
        {
        }

        #region Properties
        [JsonProperty("Id")]
        public string Id { get; set; }
        [JsonProperty("ClientNumber")]
        public string ClientNumber { get; set; }
        [JsonProperty("FullName")]
        public string FullName { get; set; }
        [JsonProperty("FirstName")]
        public string FirstName { get; set; }
        [JsonProperty("LastName")]
        public string LastName { get; set; }
        [JsonProperty("PrimaryLanguage")]
        public int PrimaryLanguage { get; set; }
        [JsonProperty("Email")]
        public string Email { get; set; }
        [JsonProperty("BusinessPhone")]
        public string BusinessPhone { get; set; }
        [JsonProperty("MobilePhone")]
        public string MobilePhone { get; set; }
        [JsonProperty("PreferredModeOfContact")]
        public EntityStatus PreferredModeOfContact { get; set; }
        [JsonProperty("Street1")]
        public string Street1 { get; set; }
        [JsonProperty("City")]
        public string City { get; set; }
        [JsonProperty("Province")]
        public string Province { get; set; }
        [JsonProperty("PostalCode")]
        public string PostalCode { get; set; }
        [JsonProperty("Segment")]
        public EntityStatus Segment { get; set; }
        [JsonProperty("ContactType")]
        public EntityStatus ContactType { get; set; }
        [JsonProperty("HomeBranchId")]
        public string HomeBranchId { get; set; }
        #endregion
    }
}
