using Newtonsoft.Json;

namespace CalServices.Models
{
    public class Branch     {         [JsonProperty("ms_branchid")]         public string Id { get; set; }          [JsonProperty("ms_branchname")]         public string Name { get; set; }          [JsonProperty("ms_name")]         public string Number { get; set; }          [JsonProperty("ms_street1")]         public string Street1 { get; set; }          [JsonProperty("ms_street2")]         public object Street2 { get; set; }          [JsonProperty("ms_city")]         public string City { get; set; }          [JsonProperty("ms_postalcode")]         public string PostalCode { get; set; }          [JsonProperty("ms_province")]         public int ms_province { get; set; }          [JsonProperty("ms_lat")]         public double Latitude { get; set; }          [JsonProperty("ms_long")]         public double Longitude { get; set; }          [JsonProperty("ms_phonenumber")]         public string PhoneNumber { get; set; }          [JsonProperty("ms_faxnumber")]         public string FaxNumber { get; set; }          [JsonProperty("ms_timezone")]         public int TimeZoneStandardCode { get; set; } 
        public string Province
        {
            get
            {
                switch (ms_province)
                {
                    case 717660008:
                        return "Ontario";
                    case 717660000:
                        return "Alberta";
                    default:
                        return string.Empty;
                }
            }
        }          [JsonIgnore]         public static string[] FIELDS => new string[13] { "ms_branchid", "ms_branchname", "ms_name", "ms_street1", "ms_street2", "ms_city",
            "ms_postalcode", "ms_lat", "ms_long", "ms_phonenumber", "ms_faxnumber", "ms_timezone", "ms_province"};      } }