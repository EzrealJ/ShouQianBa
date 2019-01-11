using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ezreal.SDK.ShouQianBa.Converters
{
    public class EnumValueStringConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType.IsEnum;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (!objectType.IsEnum)
            {
                throw new TypeAccessException(objectType.ToString());
            }
            return serializer.Deserialize(reader, objectType);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            Type targetType = Enum.GetUnderlyingType(value.GetType());
            serializer.Serialize(writer, Convert.ChangeType((value as ValueType), targetType).ToString());
        }
    }
}
