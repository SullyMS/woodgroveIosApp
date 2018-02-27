using System;
using Newtonsoft.Json;

namespace CalServices.Dynamics.Converters
{
    public class ActivityPartyConverter : JsonConverter
    {
        private string _partyType = string.Empty;
        public ActivityPartyConverter(object Parameter)
        {
            if (Parameter.GetType().Equals(typeof(string)))
            {
                _partyType = Parameter.ToString();
            }
        }

        public ActivityPartyConverter() { }

        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(string));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return false;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue($"/{_partyType}({value.ToString()})");
        }
    }
}
