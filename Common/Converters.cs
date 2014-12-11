using Newtonsoft.Json;
using System;

namespace Pocketo.Common
{
    public class UnixDateTimeConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(DateTime);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            long seconds = long.Parse((string)reader.Value);

            var date = new DateTime(1970, 1, 1);
            date = date.AddSeconds(seconds);
            return date;

        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value == null)
            {
                writer.WriteNull();
                return;
            }
            long seconds;

            var epoch = new DateTime(1970, 1, 1);
            var diff = ((DateTime)value) - epoch;
            seconds = (long)diff.TotalSeconds;
            writer.WriteValue(seconds.ToString());

        }
    }

    public class StringIntConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(int);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            int value = int.Parse((String)reader.Value);
            return value;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value == null)
            {
                writer.WriteNull();
                return;
            }
            String val = ((int)value).ToString();
            writer.WriteValue(val);
        }
    }

    public class StringLongConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(long);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            long value = long.Parse((String)reader.Value);
            return value;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value == null)
            {
                writer.WriteNull();
                return;
            }
            String val = ((long)value).ToString();
            writer.WriteValue(val);
        }
    }



}
