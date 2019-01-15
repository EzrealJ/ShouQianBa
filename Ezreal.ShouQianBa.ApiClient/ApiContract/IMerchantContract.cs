using Ezreal.ShouQianBa.ApiClient.Attributes;
using Ezreal.ShouQianBa.ApiClient.ApiParameterModels.Request;
using Ezreal.ShouQianBa.ApiClient.ApiParameterModels.Response;
using System;
using System.Collections.Generic;
using System.Text;
using WebApiClient;
using WebApiClient.Attributes;
using Ezreal.ShouQianBa.ApiClient.Sign;
using Ezreal.ShouQianBa.ApiClient.ApiParameterModels.Response.Merchant;
using Ezreal.ShouQianBa.ApiClient.ApiParameterModels.Request.Merchant;
using WebApiClient.Parameterables;

namespace Ezreal.ShouQianBa.ApiClient.ApiContract
{
    /// <summary>
    /// 商户相关接口
    /// </summary>
    public interface IMerchantContract : IHttpApi
    {
        /// <summary>
        /// 创建商户
        /// </summary>
        /// <param name="serviceProviderSigner">签名对象</param>
        /// <param name="createMerchantRequestModel">创建商户的信息</param>
        /// <param name="timeout">超时时间,可以覆盖预定义特性<see cref="TimeoutAttribute"/></param>
        /// <returns></returns>
        [Timeout(10 * 1000)]
        [HttpPost("v2/merchant/create")]
        [JsonReturn]
        ITask<Response<MerchantCreateResponseModel>> Create([Headers]ServiceProviderSignProvider serviceProviderSigner, [JsonContent]MerchantCreateRequestModel createMerchantRequestModel, Timeout timeout = null);
        /// <summary>
        /// 查询商户信息
        /// </summary>
        /// <param name="serviceProviderSigner"></param>
        /// <param name="merchantInfoRequestModel"></param>
        /// <param name="timeout">超时时间,可以覆盖预定义特性<see cref="TimeoutAttribute"/></param>
        /// <returns></returns>
        [Timeout(5 * 1000)]
        [HttpPost("v2/merchant/info")]
        [JsonReturn]
        ITask<Response<MerchantInfoResponseModel>> Info([Headers]ServiceProviderSignProvider serviceProviderSigner, [JsonContent]MerchantInfoRequestModel merchantInfoRequestModel, Timeout timeout = null);
        /// <summary>
        /// 禁用商户
        /// </summary>
        /// <param name="serviceProviderSigner"></param>
        /// <param name="closeMerchantRequestModel"></param>
        /// <param name="timeout">超时时间,可以覆盖预定义特性<see cref="TimeoutAttribute"/></param>
        /// <returns></returns>
        [Timeout(5 * 1000)]
        [HttpPost("v2/merchant/close")]
        [JsonReturn]
        ITask<Response<MerchantCloseResponseModel>> Close([Headers]ServiceProviderSignProvider serviceProviderSigner, [JsonContent]MerchantCloseRequestModel closeMerchantRequestModel, Timeout timeout = null);

        /// <summary>
        /// 根据银行卡号获取银行信息
        /// </summary>
        /// <param name="serviceProviderSigner"></param>
        /// <param name="bankRequestModel"></param>
        /// <param name="timeout">超时时间,可以覆盖预定义特性<see cref="TimeoutAttribute"/></param>
        /// <returns></returns>
        [Timeout(5 * 1000)]
        [HttpPost("v2/merchant/banks")]
        [JsonReturn]
        ITask<Response<BankResponseModel>> Banks([Headers]ServiceProviderSignProvider serviceProviderSigner, [JsonContent]BankRequestModel bankRequestModel, Timeout timeout = null);
        /// <summary>
        /// 模糊查询银行支行
        /// </summary>
        /// <param name="serviceProviderSigner"></param>
        /// <param name="bankBranchesRequestModel"></param>
        /// <param name="timeout">超时时间,可以覆盖预定义特性<see cref="TimeoutAttribute"/></param>
        /// <returns></returns>
        [Timeout(5 * 1000)]
        [HttpPost("v2/merchant/branches")]
        [JsonReturn]
        ITask<Response<BankBranchesResponseModel>> BankBranches([Headers]ServiceProviderSignProvider serviceProviderSigner, [JsonContent]BankBranchesRequestModel bankBranchesRequestModel, Timeout timeout = null);
        /// <summary>
        /// 上传图片
        /// </summary>
        /// <param name="serviceProviderSigner"></param>
        /// <param name="imageUploadRequestModel"></param>
        /// <param name="timeout">超时时间,可以覆盖预定义特性<see cref="TimeoutAttribute"/></param>
        /// <returns></returns>
        [Timeout(10 * 1000)]
        [HttpPost("v2/merchant/upload")]
        [JsonReturn]
        ITask<Response<ImageUploadResponseModel>> ImageUpload([Headers]ServiceProviderSignProvider serviceProviderSigner, [JsonContent]ImageUploadRequestModel imageUploadRequestModel, Timeout timeout = null);

        /// <summary>
        /// 对公银行查询接口
        /// </summary>
        /// <param name="serviceProviderSigner"></param>
        /// <param name="pubBankRequestModel"></param>
        /// <param name="timeout">超时时间,可以覆盖预定义特性<see cref="TimeoutAttribute"/></param>
        /// <returns></returns>
        [Timeout(5 * 1000)]
        [HttpPost("v2/merchant/pub_banks")]
        [JsonReturn]
        ITask<Response<PubBankResponseModel>> PubBank([Headers]ServiceProviderSignProvider serviceProviderSigner, [JsonContent]PubBankRequestModel pubBankRequestModel, Timeout timeout = null);

    }
}
