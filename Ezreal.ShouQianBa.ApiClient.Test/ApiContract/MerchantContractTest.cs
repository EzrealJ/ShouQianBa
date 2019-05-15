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
        public async void GetBanks_BankCardNo_ReturnsOKResultCode(string bankCardNo)
        {
            if(string.IsNullOrWhiteSpace(ShouQianBaGlobal.GlobalConfig.DefaultShouQianBaServiceProviderSettings.ServiceProviderKey+ ShouQianBaGlobal.GlobalConfig.DefaultShouQianBaServiceProviderSettings.ServiceProviderSerialNo))
            {
                throw new ArgumentException("DefaultShouQianBaServiceProviderSettings must be initialized", nameof(ShouQianBaGlobal.GlobalConfig.DefaultShouQianBaServiceProviderSettings));
            }
            BankRequestModel requestModel = new BankRequestModel() { BankCard = bankCardNo };
            Response<BankResponseModel> result = await ApiFactory.CreateMerchantClient()
                .Banks(requestModel)
                .Retry(3, TimeSpan.FromSeconds(5))
                .WhenCatch<HttpStatusFailureException>(ex => ex.StatusCode == System.Net.HttpStatusCode.RequestTimeout);
            Assert.NotNull(result);
            Assert.True(result.ResultCode == Enums.ResponseResultCodeEnum.OK);
        }


        [Theory]
        [InlineData(@"中国")]
        [InlineData(@"农业")]
        [InlineData(@"招商")]
        public async void GetPubBank_BankName_NotEmptyBankBranchesList(string bankName)
        {
            if (string.IsNullOrWhiteSpace(ShouQianBaGlobal.GlobalConfig.DefaultShouQianBaServiceProviderSettings.ServiceProviderKey + ShouQianBaGlobal.GlobalConfig.DefaultShouQianBaServiceProviderSettings.ServiceProviderSerialNo))
            {
                throw new ArgumentException("DefaultShouQianBaServiceProviderSettings must be initialized", nameof(ShouQianBaGlobal.GlobalConfig.DefaultShouQianBaServiceProviderSettings));
            }
            PubBankRequestModel requestModel = new PubBankRequestModel() { BankName = bankName };

            Response<PubBankResponseModel> result = await ApiFactory.CreateMerchantClient().PubBank( requestModel);

            Assert.NotNull(result);
            Assert.True(result.ResultCode == Enums.ResponseResultCodeEnum.OK);
            Assert.NotEmpty(result.BusinessResponseContent.BankBranchesList);
        }

        [Theory]
        [InlineData(@"中国银行", "320506")]
        [InlineData(@"中国农业银行", "320506")]
        [InlineData(@"招商银行", "330103")]
        public async void GetBankBranches_BankNameBankArea_NotEmptyBankBranchesList(string bankName, string bankArea)
        {
            if (string.IsNullOrWhiteSpace(ShouQianBaGlobal.GlobalConfig.DefaultShouQianBaServiceProviderSettings.ServiceProviderKey + ShouQianBaGlobal.GlobalConfig.DefaultShouQianBaServiceProviderSettings.ServiceProviderSerialNo))
            {
                throw new ArgumentException("DefaultShouQianBaServiceProviderSettings must be initialized", nameof(ShouQianBaGlobal.GlobalConfig.DefaultShouQianBaServiceProviderSettings));
            }
            
            BankBranchesRequestModel requestModel = new BankBranchesRequestModel() { BankName = bankName, BankArea = bankArea };
      

            Response<BankBranchesResponseModel> result = await ApiFactory.CreateMerchantClient().BankBranches( requestModel);

            Assert.NotNull(result);
            Assert.True(result.ResultCode == Enums.ResponseResultCodeEnum.OK);
            Assert.NotEmpty(result.BusinessResponseContent.BankBranchesList);
        }


        [Theory]
        [InlineData(@"./Files/desktop.png")]
        public async void ImageUpload_FilePath_NotEmptyFileURI(string filePath)
        {
            if (string.IsNullOrWhiteSpace(ShouQianBaGlobal.GlobalConfig.DefaultShouQianBaServiceProviderSettings.ServiceProviderKey + ShouQianBaGlobal.GlobalConfig.DefaultShouQianBaServiceProviderSettings.ServiceProviderSerialNo))
            {
                throw new ArgumentException("DefaultShouQianBaServiceProviderSettings must be initialized", nameof(ShouQianBaGlobal.GlobalConfig.DefaultShouQianBaServiceProviderSettings));
            }
            Image image = Image.FromFile(filePath);
            ImageUploadRequestModel requestModel = ImageUploadRequestModel.FromImage(image);

            Response<ImageUploadResponseModel> result = await ApiFactory.CreateMerchantClient().ImageUpload(requestModel);

            Assert.NotNull(result);
            Assert.True(result.ResultCode == Enums.ResponseResultCodeEnum.OK);
            Assert.NotEmpty(result.BusinessResponseContent.FileURI);

        }


    }
}
