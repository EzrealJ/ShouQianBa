using Ezreal.ShouQianBa.ApiClient.ApiContract;
using Ezreal.ShouQianBa.ApiClient.ApiParameterModels.Request.Merchant;
using Ezreal.ShouQianBa.ApiClient.ApiParameterModels.Response;
using Ezreal.ShouQianBa.ApiClient.ApiParameterModels.Response.Merchant;
using Ezreal.ShouQianBa.ApiClient.Sign;
using Ezreal.ShouQianBa.ApiClient.Extension;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiClient;
using Xunit;

namespace Ezreal.ShouQianBa.ApiClient.Test.ApiContract
{
    public class MerchantContractTest : TestBase
    {
        [Theory]
        [InlineData(@"6227002021280187342")]
        [InlineData(@"6222600260001072444")]
        [InlineData(@"6217790001073282390")]
        public async void Banks(string bankCardNo)
        {
            BankRequestModel requestModel = new BankRequestModel() { BankCard = bankCardNo };
            var apiInstense = Global.Create<IMerchantContract>();
            var sign = ServiceProviderSignProvider.CreateFromServiceProviderSettings().Sign(requestModel);          
            Response<BankResponseModel> result = await apiInstense.Banks(sign, requestModel);
            Assert.NotNull(result);
            Assert.True(result.ResultCode == Enums.ResponseResultCodeEnum.OK);
        }


        [Theory]
        [InlineData(@"中国")]
        [InlineData(@"农业")]
        [InlineData(@"招商")]
        public async void PubBank(string bankName)
        {
            var apiInstense = Global.Create<IMerchantContract>();


            PubBankRequestModel requestModel = new PubBankRequestModel() { BankName = bankName };
            var sign = ServiceProviderSignProvider.CreateFromServiceProviderSettings().Sign(requestModel);

            Response<PubBankResponseModel> result = await apiInstense.PubBank(sign, requestModel);

            Assert.NotNull(result);
            Assert.True(result.ResultCode == Enums.ResponseResultCodeEnum.OK);
            Assert.NotEmpty(result.BusinessResponseContent.BankBranchesList);
        }

        [Theory]
        //[InlineData(@"中国银行", "320506")]
        //[InlineData(@"中国农业银行", "320506")]
        [InlineData(@"招商银行", "330103")]
        public async void BankBranches(string bankName, string bankArea)
        {
            var apiInstense = Global.Create<IMerchantContract>();


            BankBranchesRequestModel requestModel = new BankBranchesRequestModel() { BankName = bankName, BankArea = bankArea };
            var sign = ServiceProviderSignProvider.CreateFromServiceProviderSettings().Sign(requestModel);

            Response<BankBranchesResponseModel> result = await apiInstense.BankBranches(sign, requestModel);

            Assert.NotNull(result);
            Assert.True(result.ResultCode == Enums.ResponseResultCodeEnum.OK);
            Assert.NotEmpty(result.BusinessResponseContent.BankBranchesList);
        }


        [Theory]
        [InlineData(@"./Files/desktop.png")]
        public async void ImageUpload(string filePath)
        {

            var apiInstense = Global.Create<IMerchantContract>();
            Image image = Image.FromFile(filePath);
            ImageUploadRequestModel requestModel = ImageUploadRequestModel.FromImage(image);
            var sign = ServiceProviderSignProvider.CreateFromServiceProviderSettings().Sign(requestModel);

            Response<ImageUploadResponseModel> result = await apiInstense.ImageUpload(sign, requestModel);

            Assert.NotNull(result);
            Assert.True(result.ResultCode == Enums.ResponseResultCodeEnum.OK);
            Assert.NotEmpty(result.BusinessResponseContent.FileURI);

        }


    }
}
