namespace CalServices.Models
{
    using Newtonsoft.Json;

    public class Branch
    {
        [JsonProperty("Id")]
        public string Id { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Number")]
        public string Number { get; set; }

        [JsonProperty("Street1")]
        public string Street1 { get; set; }

        [JsonProperty("Street2")]
        public object Street2 { get; set; }

        [JsonProperty("City")]
        public string City { get; set; }

        [JsonProperty("PostalCode")]
        public string PostalCode { get; set; }

        [JsonProperty("Province")]
        public EntityStatus Province { get; set; }

        [JsonProperty("Latitude")]
        public double Latitude { get; set; }

        [JsonProperty("Longitude")]
        public double Longitude { get; set; }

        [JsonProperty("PhoneNumber")]
        public string PhoneNumber { get; set; }

        [JsonProperty("FaxNumber")]
        public string FaxNumber { get; set; }

        [JsonProperty("TimeZoneStandardName")]
        public string TimeZoneStandardName { get; set; }

        [JsonProperty("SundayOpen")]
        public System.DateTimeOffset SundayOpen { get; set; }

        [JsonProperty("SundayClose")]
        public System.DateTimeOffset SundayClose { get; set; }

        [JsonProperty("MondayOpen")]
        public System.DateTimeOffset MondayOpen { get; set; }

        [JsonProperty("MondayClose")]
        public System.DateTimeOffset MondayClose { get; set; }

        [JsonProperty("TuesdayOpen")]
        public System.DateTimeOffset TuesdayOpen { get; set; }

        [JsonProperty("TuesdayClose")]
        public System.DateTimeOffset TuesdayClose { get; set; }

        [JsonProperty("WednesdayOpen")]
        public System.DateTimeOffset WednesdayOpen { get; set; }

        [JsonProperty("WednesdayClose")]
        public System.DateTimeOffset WednesdayClose { get; set; }

        [JsonProperty("ThursdayOpen")]
        public System.DateTimeOffset ThursdayOpen { get; set; }

        [JsonProperty("ThursdayClose")]
        public System.DateTimeOffset ThursdayClose { get; set; }

        [JsonProperty("FridayOpen")]
        public System.DateTimeOffset FridayOpen { get; set; }

        [JsonProperty("FridayClose")]
        public System.DateTimeOffset FridayClose { get; set; }

        [JsonProperty("SaturdayOpen")]
        public System.DateTimeOffset SaturdayOpen { get; set; }

        [JsonProperty("SaturdayClose")]
        public System.DateTimeOffset SaturdayClose { get; set; }

        [JsonProperty("TodaysOpenTime")]
        public System.DateTimeOffset TodaysOpenTime { get; set; }

        [JsonProperty("TodaysCloseTime")]
        public System.DateTimeOffset TodaysCloseTime { get; set; }

        [JsonProperty("HolidayCalendarId")]
        public string HolidayCalendarId { get; set; }
    }
}
