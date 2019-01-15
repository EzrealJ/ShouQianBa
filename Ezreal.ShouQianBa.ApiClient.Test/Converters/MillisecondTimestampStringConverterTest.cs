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

        public class TestClass
        {
            [JsonConverter(typeof(MillisecondTimestampStringConverter))]
            public DateTime MyProperty { get; set; }
            [JsonConverter(typeof(MillisecondTimestampStringConverter))]
            public DateTime? MyProperty1 { get; set; }

        }
        [Fact]
        public void SerializeObject()
        {
            DateTime now = DateTime.Now;
            TestClass testClass = new TestClass()
            {
                MyProperty = now,
                MyProperty1 = null,

            };

            string str = JsonConvert.SerializeObject(testClass);
            Assert.Contains(((now - MillisecondTimestampStringConverter.UnixTimestampLocalZero).Ticks/ 10000).ToString(), str);
            Assert.DoesNotContain("\"null\"", str);
        }
        [Fact]
        public void DeserializeObject()
        {
            string str = "{\"MyProperty\":\"1547196591508\",\"MyProperty1\":\"\"}";
            TestClass testClass = JsonConvert.DeserializeObject<TestClass>(str);
            Assert.True(testClass.MyProperty == MillisecondTimestampStringConverter.UnixTimestampLocalZero.AddMilliseconds(1547196591508));
            Assert.True(testClass.MyProperty1 == null);
        }
    }
}
