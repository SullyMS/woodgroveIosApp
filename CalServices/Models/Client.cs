using Newtonsoft.Json;

namespace CalServices.Models
{
    public class Client
    {
        [JsonProperty("contactid")]
        public string Id { get; set; }
        [JsonProperty("ms_customernumber")]
        public string CustomerNumber { get; set; }
        [JsonProperty("fullname")]
        public string FullName { get; set; }
        [JsonProperty("firstname")]
        public string FirstName { get; set; }
        [JsonProperty("lastname")]
        public string LastName { get; set; }
        [JsonProperty("ms_primarylanguage")]
        public int PrimaryLanguage { get; set; }
        [JsonProperty("emailaddress1")]
        public string Email { get; set; }
        [JsonProperty("telephone1")]
        public string BusinessPhone { get; set; }
        [JsonProperty("mobilephone")]
        public string MobilePhone { get; set; }
        [JsonProperty("preferredcontactmethodcode")]
        public int PreferredModeOfContact { get; set; }
        [JsonProperty("address1_line1")]
        public string Street1 { get; set; }
        [JsonProperty("address1_city")]
        public string City { get; set; }
        [JsonProperty("address1_stateorprovince")]
        public string Province { get; set; }
        [JsonProperty("address1_postalcode")]
        public string PostalCode { get; set; }
        [JsonProperty("ms_segment")]
        public int Segment { get; set; }
        [JsonProperty("ms_contacttype")]
        public int ContactType { get; set; }
        [JsonProperty("_ms_homebranchid_value")]
        public string HomeBranchId { get; set; }
        [JsonProperty("entityimage")]
        public string Image { get; set; }
        [JsonProperty("ms_homebranchid")]
        public Branch Branch { get; set; }

        [JsonIgnore]
        public static string[] FIELDS = new string[17] { "ms_customernumber", "fullname", "firstname", "lastname",
            "ms_primarylanguage", "emailaddress1", "telephone1", "mobilephone", "preferredcontactmethodcode", "address1_line1",
            "address1_city", "address1_stateorprovince", "address1_postalcode", "ms_segment", "ms_contacttype", "_ms_homebranchid_value", "entityimage"};

        public const string ENTITY_NAME = "contact";
        public const string ALT_KEY = "ms_customernumber";
        public const string BRANCH_ID_FIELD = "ms_homebranchid";
    }
}
