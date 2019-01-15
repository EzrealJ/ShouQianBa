using Ezreal.ShouQianBa.ApiClient.Converters;
using Newtonsoft.Json;
using Xunit;

namespace Ezreal.ShouQianBa.ApiClient.Test.Converters
{
    public class CentStringConverterTest
    {
        public class TestClass
        {
            [JsonConverter(typeof(CentStringConverter))]
            public float MyProperty { get; set; }
            [JsonConverter(typeof(CentStringConverter))]
            public double MyProperty1 { get; set; }
            [JsonConverter(typeof(CentStringConverter))]
            public decimal MyProperty2 { get; set; }
        }
        [Fact]
        public void SerializeObject()
        {

            TestClass testClass = new TestClass()
            {
                MyProperty = 12.3f,
                MyProperty1 = 11.2d,
                MyProperty2 = 52.3m
            };

            string str = JsonConvert.SerializeObject(testClass);
            Assert.Contains("\"1230\"", str);
            Assert.Contains("\"1120\"", str);
            Assert.Contains("\"5230\"", str);

        }
        [Fact]
        public void DeserializeObject()
        {
            string str = "{\"MyProperty\":\"1230\",\"MyProperty1\":\"1120\",\"MyProperty2\":\"5230\"}";
            TestClass testClass = JsonConvert.DeserializeObject<TestClass>(str);
            Assert.True(testClass.MyProperty == 12.3f);
            Assert.True(testClass.MyProperty1 == 11.2d);
            Assert.True(testClass.MyProperty2 == 52.3m);
        }
    }


}
