using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ezreal.SDK.ShouQianBa.Converters
{


    /// <summary>
    /// Converts a <see cref="DateTime"/> to and from Unix epoch time
    /// </summary>
    public class MillisecondTimestampStringConverter : DateTimeConverterBase
    {
        private static List<Type> allowTypes = new List<Type>() { typeof(DateTime), typeof(DateTime?),typeof(TimeSpan), typeof(TimeSpan?) };
        static public DateTime UnixTimestampLocalZero { get; set; } = System.TimeZoneInfo.ConvertTime(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc), TimeZoneInfo.Local);

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            Type fromType = value.GetType();
            if (!allowTypes.Contains(fromType))
            {
                throw new TypeAccessException(fromType.ToString());
            }
            DateTime? realValue = value as DateTime?;
            long ticks = realValue.HasValue ? (realValue.Value - UnixTimestampLocalZero).Ticks : UnixTimestampLocalZero.Ticks;
            writer.WriteValue((ticks / 10000).ToString());


        }


        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (!allowTypes.Contains(objectType))
            {
                throw new TypeAccessException(objectType.ToString());
            }
            bool nullable = objectType == typeof(DateTime?);
            if (reader.TokenType == JsonToken.Null)
            {
                if (!nullable)
                {
                    throw new JsonSerializationException("Cannot convert null value to {objectType}.");
                }

                return null;
            }


            long milliseconds = 0;
            if (reader.TokenType == JsonToken.Integer)
            {
                milliseconds = (long)reader.Value;
            }
            else if (reader.TokenType == JsonToken.String)
            {
                if (!long.TryParse((string)reader.Value, out milliseconds))
                {
                    if (nullable) return null;
                    throw new JsonSerializationException($"Cannot convert invalid value to {objectType}.");
                }
            }
            else
            {
                throw new JsonSerializationException($"Unexpected token parsing date. Expected Integer or String, got {reader.TokenType}.");
            }

            if (milliseconds >= 0)
            {
                DateTime dateTime = UnixTimestampLocalZero.AddMilliseconds(milliseconds);
                if(objectType==typeof(TimeSpan)|| objectType == typeof(TimeSpan?))
                {
                    return dateTime - default(DateTime);
                }

                return dateTime;
            }
            else
            {
                throw new JsonSerializationException($"Cannot convert invalid value to {objectType}.");
            }
        }
    }
}
