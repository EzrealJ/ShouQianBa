using Ezreal.SDK.ShouQianBa.Converters;
using Newtonsoft.Json;
using Xunit;

namespace Ezreal.SDK.ShouQianBa.Test.DataConvert
{
    public class EnumValueStringConverterTest
    {

        public enum Enum1 : byte
        {
            A = 1,
            B = 2,
        }
        public enum Enum2 : short
        {
            C = 3,
            D = 4,
        }
        public enum Enum3 : int
        {
            E = 5,
            F = 6,
        }
        public class TestClass
        {
            [JsonConverter(typeof(EnumValueStringConverter))]
            public Enum1 MyProperty { get; set; }
            [JsonConverter(typeof(EnumValueStringConverter))]
            public Enum2 MyProperty1 { get; set; }
            [JsonConverter(typeof(EnumValueStringConverter))]
            public Enum3 MyProperty2 { get; set; }
        }
        [Fact]
        public void SerializeObject()
        {
            TestClass testClass = new TestClass()
            {
                MyProperty = Enum1.A,
                MyProperty1 = Enum2.C,
                MyProperty2 = Enum3.E
            };

            string str = JsonConvert.SerializeObject(testClass);
            Assert.Contains("\"1\"", str);
            Assert.Contains("\"3\"", str);
            Assert.Contains("\"5\"", str);
        }
        [Fact]
        public void DeserializeObject()
        {
            string str = "{\"MyProperty\":\"2\",\"MyProperty1\":\"4\",\"MyProperty2\":\"6\"}";
            TestClass testClass = JsonConvert.DeserializeObject<TestClass>(str);
            Assert.True(testClass.MyProperty == Enum1.B);
            Assert.True(testClass.MyProperty1 == Enum2.D);
            Assert.True(testClass.MyProperty2 == Enum3.F);
        }
    }
}
