using Ezreal.ShouQianBa.ApiClient.ApiParameterModels.Request;
using Ezreal.ShouQianBa.ApiClient.ApiParameterModels.Request.Merchant;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Ezreal.ShouQianBa.ApiClient.Test.Models.Request
{
    public class ImageUploadRequestModelTest
    {
        [Theory]
        [InlineData(@"./Files/desktop.png")]
        public void FromImage(string filePath)
        {
            Image image = Image.FromFile(filePath);
            ImageUploadRequestModel imageUploadRequestModel = ImageUploadRequestModel.FromImage(image);
            Assert.NotNull(imageUploadRequestModel);
            Assert.NotEmpty(imageUploadRequestModel.ImageBase64String);
        }
    }
}
