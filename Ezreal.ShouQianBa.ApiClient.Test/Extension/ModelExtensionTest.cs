using Ezreal.ShouQianBa.ApiClient.ApiParameterModels.Request.Merchant;
using System;
using System.Collections.Generic;
using System.Text;
using Ezreal.ShouQianBa.ApiClient.Extension;
using Xunit;

namespace Ezreal.ShouQianBa.ApiClient.Test.Extension
{
    public class ModelExtensionTest
    {
        [Fact]
        public void NameOfApiParameter()
        {
            ImageUploadRequestModel imageUploadRequestModel = new ImageUploadRequestModel();
            string apiParameterName = imageUploadRequestModel.NameOfApiParameter(t => t.ImageBase64String);
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
