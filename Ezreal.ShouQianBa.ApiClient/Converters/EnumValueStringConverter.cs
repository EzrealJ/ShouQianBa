using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ezreal.ShouQianBa.ApiClient.Converters
{
    /// <summary>
    /// 定义枚举值和字符串值转化
    /// </summary>
    public class EnumValueStringConverter : JsonConverter
    {
        /// <summary>
        /// 仅在Api内部有效
        /// </summary>
        public static bool InternalOnly { get; set; } = true;
#pragma warning disable CS1591 // 缺少对公共可见类型或成员的 XML 注释
        public override bool CanConvert(Type objectType)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员的 XML 注释
        {
            return objectType.IsEnum;
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员的 XML 注释
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员的 XML 注释
        {
            return serializer.Deserialize(reader, objectType);
            //if (serializer.ContractResolver.GetType().Namespace != "WebApiClient.Defaults"&& InternalOnly)
            //{
            //    return serializer.Deserialize(reader, objectType);
            //}
            //if (objectType.IsEnum || (objectType.GetGenericTypeDefinition() == typeof(Nullable<>) && objectType.GetGenericArguments()[0].IsEnum))
            //{
            //    return serializer.Deserialize(reader, objectType);
            //}
            //throw new TypeAccessException(objectType.ToString());           
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员的 XML 注释
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员的 XML 注释
        {
            if (serializer.ContractResolver.GetType().Namespace != "WebApiClient.Defaults" && InternalOnly)
            {
                writer.WriteValue(value);
                return;
            }
            Type targetType = Enum.GetUnderlyingType(value.GetType());
            writer.WriteValue(Convert.ChangeType(value as ValueType, targetType).ToString());
        }
    }
}
