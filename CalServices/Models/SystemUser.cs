using Newtonsoft.Json;

namespace CalServices.Models
{
    public class SystemUser
    {
        public SystemUser()
        {
        }
        #region Properties
        [JsonProperty("firstname")]
        public string FirstName { get; set; }
        [JsonProperty("lastname")]
        public string LastName { get; set; }
        [JsonIgnore]
        public string FullName => $"{FirstName} {LastName}";
        [JsonProperty("systemuserid")]
        public string Id { get; set; }
        [JsonProperty("internalemailaddress")]
        public string Email { get; set; }
        [JsonProperty("entityimage")]
        public string Image { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("mobilephone")]
        public string MobilePhone { get; set; }
        #endregion

        #region constants
        public const string ENTITY_NAME = "systemuser";
        public static string[] FIELDS = new string[7] {"firstname","lastname","systemuserid","internalemailaddress","entityimage", "title", "mobilephone"};
        #endregion
    }
}
