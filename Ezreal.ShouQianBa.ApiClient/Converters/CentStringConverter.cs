using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ezreal.ShouQianBa.ApiClient.Converters
{
    /// <summary>
    /// 以分计的金额字符串转换器
    /// <para>
    /// 将浮点类型<see cref="float"/>,<see cref="double"/>十进制类型<see cref="decimal"/>的金额值转换为以分计的金额字符串
    /// </para>
    /// <para>
    /// 收钱吧约定所有的金额均采用以分计的整数字符串来传递
    /// </para>
    /// </summary>
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
