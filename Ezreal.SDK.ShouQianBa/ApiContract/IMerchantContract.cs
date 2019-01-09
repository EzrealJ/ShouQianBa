using Ezreal.SDK.ShouQianBa.Attributes;
using Ezreal.SDK.ShouQianBa.ApiParameterModels.Request;
using Ezreal.SDK.ShouQianBa.ApiParameterModels.Response;
using System;
using System.Collections.Generic;
using System.Text;
using WebApiClient;
using WebApiClient.Attributes;
using Ezreal.SDK.ShouQianBa.Sign;
using Ezreal.SDK.ShouQianBa.ApiParameterModels.Response.Merchant;
using Ezreal.SDK.ShouQianBa.ApiParameterModels.Request.Merchant;
using WebApiClient.Parameterables;

namespace Ezreal.SDK.ShouQianBa.ApiContract
{
    [HttpHost("https://api-vendor.shouqianba.com/")]
    public interface IMerchantContract : IHttpApi
    {

        [Timeout(10 * 1000)]
        [HttpPost("v2/merchant/create")]
        [JsonReturn]
        ITask<Response<MerchantCreateResponseModel>> Create([Headers]ServiceProviderSignProvider<MerchantCreateRequestModel> serviceProviderSigner, [JsonContent]MerchantCreateRequestModel createMerchantRequestModel, Timeout timeout = null);

        [Timeout(5 * 1000)]
        [HttpPost("v2/merchant/info")]
        [JsonReturn]
        ITask<Response<MerchantInfoResponseModel>> Info([Headers]ServiceProviderSignProvider<MerchantInfoRequestModel> serviceProviderSigner, [JsonContent]MerchantInfoRequestModel merchantInfoRequestModel, Timeout timeout = null);

        [Timeout(5 * 1000)]
        [HttpPost("v2/merchant/close")]
        [JsonReturn]
        ITask<Response<MerchantCloseResponseModel>> Close([Headers]ServiceProviderSignProvider<MerchantCloseRequestModel> serviceProviderSigner, [JsonContent]MerchantCloseRequestModel closeMerchantRequestModel, Timeout timeout = null);


        [Timeout(5 * 1000)]
        [HttpPost("v2/merchant/banks")]
        [JsonReturn]
        ITask<Response<BankResponseModel>> Banks([Headers]ServiceProviderSignProvider<BankRequestModel> serviceProviderSigner, [JsonContent]BankRequestModel bankRequestModel, Timeout timeout = null);

        [Timeout(5 * 1000)]
        [HttpPost("v2/merchant/branches")]
        [JsonReturn]
        ITask<Response<BankBranchesResponseModel>> BankBranches([Headers]ServiceProviderSignProvider<BankBranchesRequestModel> serviceProviderSigner, [JsonContent]BankBranchesRequestModel bankBranchesRequestModel, Timeout timeout = null);

        [Timeout(10 * 1000)]
        [HttpPost("v2/merchant/upload")]
        [JsonReturn]
        ITask<Response<ImageUploadResponseModel>> ImageUpload([Headers]ServiceProviderSignProvider<ImageUploadRequestModel> serviceProviderSigner, [JsonContent]ImageUploadRequestModel imageUploadRequestModel, Timeout timeout = null);


        [Timeout(5 * 1000)]
        [HttpPost("v2/merchant/pub_banks")]
        [JsonReturn]
        ITask<Response<PubBankResponseModel>> PubBank([Headers]ServiceProviderSignProvider<PubBankRequestModel> serviceProviderSigner, [JsonContent]PubBankRequestModel pubBankRequestModel, Timeout timeout = null);

    }
}
