using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ezreal.SDK.ShouQianBa.DataConvert
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
            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            //Type fromType = value.GetType();
            //if (!allowTypes.Contains(fromType))
            //{
            //    throw new TypeAccessException(fromType.ToString());
            //}
            //if(value is float)
            //{
                
            //}
        }
    }
}
