using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ezreal.SDK.ShouQianBa.Converters
{


    ///// <summary>
    ///// Converts a <see cref="DateTime"/> to and from Unix epoch time
    ///// </summary>
    //public class UnixDateTimeStringConverter : DateTimeConverterBase
    //{
    //    private static List<Type> allowTypes = new List<Type>() { typeof(DateTime), typeof(DateTime?) };
    //    static DateTime unixTimestampLocalZero = System.TimeZoneInfo.ConvertTime(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc), TimeZoneInfo.Local);

    //    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    //    {
    //        Type fromType = value.GetType();
    //        if (!allowTypes.Contains(fromType))
    //        {
    //            throw new TypeAccessException(fromType.ToString());
    //        }
    //        DateTime? realValue = value as DateTime?;
    //        long ticks = realValue.HasValue ? (realValue.Value - unixTimestampLocalZero).Ticks : unixTimestampLocalZero.Ticks;
    //        serializer.Serialize(writer, (ticks / 10000).ToString());
    //    }


    //    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    //    {
    //        //Type targetType = Enum.GetUnderlyingType(value.GetType());
    //        //serializer.Serialize(writer, Convert.ChangeType((value as ValueType), targetType).ToString());
    //    }
    //}
}
