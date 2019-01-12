﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ezreal.SDK.ShouQianBa.Converters
{
    public class CentStringConverter : JsonConverter
    {
        private static List<Type> allowTypes = new List<Type>() { typeof(float), typeof(double), typeof(decimal) };
        public override bool CanConvert(Type objectType)
        {

            return allowTypes.Contains(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (!allowTypes.Contains(objectType))
            {
                throw new TypeAccessException(objectType.ToString());
            }
            return Convert.ChangeType(decimal.Parse(serializer.Deserialize(reader, objectType).ToString())/100,objectType);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            Type fromType = value.GetType();
            if (!allowTypes.Contains(fromType))
            {
                throw new TypeAccessException(fromType.ToString());
            }
            writer.WriteValue(((int)(Math.Round(decimal.Parse(value.ToString()), 2) * 100)).ToString());

        }
    }
}
