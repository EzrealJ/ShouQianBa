using Ezreal.SDK.ShouQianBa.ApiParameterModels.Request;
using Ezreal.SDK.ShouQianBa.ApiParameterModels.Request.Merchant;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Ezreal.SDK.ShouQianBa.Test.Models.Request
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
