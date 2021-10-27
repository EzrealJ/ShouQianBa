using Ezreal.ShouQianBa.ApiClient.ApiModels.Request.Pay;
using Ezreal.ShouQianBa.ApiClient.Extension;
using Xunit;

namespace Ezreal.ShouQianBa.ApiClient.Test.Extension
{
    public class ModelExtensionTest
    {
        [Fact]
        public void NameOfApiParameter()
        {
            OrderCreateRequestModel orderCreateRequestModel = new OrderCreateRequestModel();
            string apiParameterName = orderCreateRequestModel.NameOfApiParameter(t => t.ClientSerialNo);
            Assert.True(apiParameterName == "file");
        }

        [Fact]
        public void DoubleToCentString()
        {
            Assert.True(0.01d.ToCentString() == "1");
        }

        [Fact]
        public void DecimalToCentString()
        {
            Assert.True(0.01m.ToCentString() == "1");
        }
    }
}
