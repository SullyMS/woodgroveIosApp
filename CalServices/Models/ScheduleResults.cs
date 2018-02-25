namespace CalServices.Models
{
    using Newtonsoft.Json;

    public class ScheduleResults
    {
        [JsonProperty("ScheduleResults")]
        public ScheduleResult[] ScheduleDays { get; set; }

        [JsonProperty("UILanguageCode")]
        public long UiLanguageCode { get; set; }

        [JsonProperty("ErrorMessage")]
        public string ErrorMessage { get; set; }

        [JsonProperty("ErrorCode")]
        public long ErrorCode { get; set; }

        [JsonProperty("Result")]
        public long Result { get; set; }

        [JsonProperty("InnerErrorMessage")]
        public object InnerErrorMessage { get; set; }
    }

    public class ScheduleResult
    {
        [JsonProperty("TimeSlots")]
        public TimeSlot[] TimeSlots { get; set; }

        [JsonProperty("ScheduleDate")]
        public System.DateTimeOffset ScheduleDate { get; set; }

        [JsonProperty("Holiday")]
        public object Holiday { get; set; }

        [JsonProperty("IsHoliday")]
        public bool IsHoliday { get; set; }

        [JsonProperty("IsClosedForHoliday")]
        public bool IsClosedForHoliday { get; set; }
    }

    public class TimeSlot
    {
        [JsonProperty("AvailableStaff")]
        public string[] AvailableStaff { get; set; }

        [JsonProperty("AvailableStaffSystemUsers")]
        public AvailableStaffSystemUser[] AvailableStaffSystemUsers { get; set; }

        [JsonProperty("IsAvialable")]
        public bool IsAvialable { get; set; }

        [JsonProperty("StartTimeUTC")]
        public System.DateTime StartTimeUtc { get; set; }

        [JsonProperty("EndTimeUTC")]
        public System.DateTime EndTimeUtc { get; set; }

        [JsonProperty("ScheduledDate")]
        public System.DateTimeOffset ScheduledDate { get; set; }

        [JsonProperty("StartTime")]
        public System.DateTime StartTime { get; set; }

        [JsonProperty("EndTime")]
        public System.DateTime EndTime { get; set; }

        [JsonProperty("Duration")]
        public System.DateTimeOffset Duration { get; set; }

        [JsonProperty("TimeZoneStandardName")]
        public string TimeZoneStandardName { get; set; }
    }

    public class AvailableStaffSystemUser
    {
        [JsonProperty("FullName")]
        public string FullName { get; set; }

        [JsonProperty("Email")]
        public string Email { get; set; }

        [JsonProperty("Id")]
        public string Id { get; set; }

        [JsonProperty("AdvisorNumber")]
        public object AdvisorNumber { get; set; }

        [JsonProperty("MobilePhone")]
        public object MobilePhone { get; set; }

        [JsonProperty("Phone")]
        public object Phone { get; set; }

        [JsonProperty("JobTitle")]
        public string JobTitle { get; set; }

        [JsonProperty("OutOfOfficeStatus")]
        public object OutOfOfficeStatus { get; set; }

        [JsonProperty("AdvisorImage")]
        public string AdvisorImage { get; set; }

        [JsonProperty("IsFromCache")]
        public bool IsFromCache { get; set; }
    }
}
