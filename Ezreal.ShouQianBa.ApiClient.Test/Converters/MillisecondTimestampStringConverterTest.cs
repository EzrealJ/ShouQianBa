using Ezreal.ShouQianBa.ApiClient.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Ezreal.ShouQianBa.ApiClient.Test.Converters
{
    public class MillisecondTimestampStringConverterTest
    {
        public MillisecondTimestampStringConverterTest()
        {
            MillisecondTimestampStringConverter.InternalOnly = false;
        }

        public class TestClass
        {                    
            [JsonConverter(typeof(MillisecondTimestampStringConverter))]
            public DateTime MyProperty { get; set; }
            [JsonConverter(typeof(MillisecondTimestampStringConverter))]
            public DateTime? MyProperty1 { get; set; }

        }
        [Fact]
        public void Serialize_Object_ReturnMillisecondTimestampString()
        {
            DateTime now = DateTime.Now;
            TestClass testClass = new TestClass()
            {
                MyProperty = now,
                MyProperty1 = null,

            };

            string str = JsonConvert.SerializeObject(testClass);
            Assert.Contains(((now - MillisecondTimestampStringConverter.UnixTimestampLocalZero).Ticks/ 10000).ToString(), str);

        }
        [Fact]
        public void Deserialize_ObjectJsonStringWithMillisecondTimestampString_ReturnTrueDateTime()
        {
            string str = "{\"MyProperty\":\"1547196591508\",\"MyProperty1\":\"\"}";
            TestClass testClass = JsonConvert.DeserializeObject<TestClass>(str);
            Assert.True(testClass.MyProperty == MillisecondTimestampStringConverter.UnixTimestampLocalZero.AddMilliseconds(1547196591508));
            Assert.True(testClass.MyProperty1 == null);
        }
    }
}
