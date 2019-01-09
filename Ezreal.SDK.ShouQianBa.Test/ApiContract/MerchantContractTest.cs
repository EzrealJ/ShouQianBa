using Ezreal.SDK.ShouQianBa.ApiContract;
using Ezreal.SDK.ShouQianBa.ApiParameterModels.Request.Merchant;
using Ezreal.SDK.ShouQianBa.ApiParameterModels.Response;
using Ezreal.SDK.ShouQianBa.ApiParameterModels.Response.Merchant;
using Ezreal.SDK.ShouQianBa.Sign;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiClient;
using Xunit;

namespace Ezreal.SDK.ShouQianBa.Test.ApiContract
{
    public class MerchantContractTest : TestBase
    {
        [Theory]
        [InlineData(@"6227002021280187342")]
        [InlineData(@"6222600260001072444")]
        [InlineData(@"6217790001073282390")]
        public async void Banks(string bankCardNo)
        {
            var apiInstense = Global.Create<IMerchantContract>();


            BankRequestModel requestModel = new BankRequestModel() { BankCard = bankCardNo };
            ServiceProviderSignProvider<BankRequestModel> shouQianBaServiceProviderSigner = new ServiceProviderSignProvider<BankRequestModel>(requestModel);

            Response<BankResponseModel> result = await apiInstense.Banks(shouQianBaServiceProviderSigner, requestModel);

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
            ServiceProviderSignProvider<PubBankRequestModel> shouQianBaServiceProviderSigner = new ServiceProviderSignProvider<PubBankRequestModel>(requestModel);

            Response<PubBankResponseModel> result = await apiInstense.PubBank(shouQianBaServiceProviderSigner, requestModel);

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
            ServiceProviderSignProvider<BankBranchesRequestModel> shouQianBaServiceProviderSigner = new ServiceProviderSignProvider<BankBranchesRequestModel>(requestModel);

            Response<BankBranchesResponseModel> result = await apiInstense.BankBranches(shouQianBaServiceProviderSigner, requestModel);

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
            ServiceProviderSignProvider<ImageUploadRequestModel> shouQianBaServiceProviderSigner = new ServiceProviderSignProvider<ImageUploadRequestModel>(requestModel);

            Response<ImageUploadResponseModel> result = await apiInstense.ImageUpload(shouQianBaServiceProviderSigner, requestModel);

            Assert.NotNull(result);
            Assert.True(result.ResultCode == Enums.ResponseResultCodeEnum.OK);
            Assert.NotEmpty(result.BusinessResponseContent.FileURI);
        }


    }
}
