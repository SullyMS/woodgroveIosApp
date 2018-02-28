using System;
using CalServices.Dynamics.Base;
using Newtonsoft.Json;

namespace CalServices.Models
{
    public class AppointmentReason : BaseEntity
    {
        public AppointmentReason(): base (ENTITY_NAME)
        {
        }

        #region Properties
        [JsonProperty(STATE_FIELD)]
        public int State { get; set; }
        [JsonProperty("ms_appointmenttype")]
        public int AppointmentTypeCode { get; set; }
        [JsonProperty("ms_name")]
        public string Name { get; set; }
        [JsonProperty("ms_appointmentsubtype")]
        public int AppointmentSubTypeCode { get; set; }
        [JsonProperty("ms_description")]
        public string Description { get; set; }
        #endregion

        #region Constants
        public const string ENTITY_NAME = "ms_appointmentreason";
        public const string STATE_FIELD = "statuscode";
        public static string[] FIELDS = new string[5] {STATE_FIELD, "ms_appointmenttype", "ms_name", "ms_appointmentsubtype", "ms_description"};
        #endregion
    }
}
