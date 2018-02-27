using Newtonsoft.Json;
using System;

namespace CalServices.Dynamics.Converters
{
    public class JsonLookUpFieldConverter : JsonConverter
    {
        private string _lookupTypeName = string.Empty;
        public JsonLookUpFieldConverter(object Parameter)
        {
            if (Parameter.GetType().Equals(typeof(string)))
            {
                _lookupTypeName = Parameter.ToString();
            }
        }

        public JsonLookUpFieldConverter() { }

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
            writer.WriteValue(string.Format("{0}({1})", _lookupTypeName, value.ToString()));

        }
    }
}
