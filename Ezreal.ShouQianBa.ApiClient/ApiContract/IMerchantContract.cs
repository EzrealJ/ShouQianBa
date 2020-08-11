using Ezreal.ShouQianBa.ApiClient.ApiParameterModels.Request.Merchant;
using Ezreal.ShouQianBa.ApiClient.ApiParameterModels.Response;
using Ezreal.ShouQianBa.ApiClient.ApiParameterModels.Response.Merchant;
using Ezreal.ShouQianBa.ApiClient.Sign;
using System;
using System.Threading;
using WebApiClient;
using WebApiClient.Attributes;
using WebApiClient.Parameterables;

namespace Ezreal.ShouQianBa.ApiClient.ApiContract
{
    /// <summary>
    /// 商户相关接口
    /// </summary>
    [Obsolete("收钱吧收紧了相关权限,沟通后表示此接口可以删除,声明作废")]
    public interface IMerchantContract : IHttpApi
    {
        /// <summary>
        /// 创建商户
        /// </summary>
        /// <param name="serviceProviderSignSettings"></param>
        /// <param name="createMerchantRequestModel">创建商户的信息</param>
        /// <param name="timeout">超时时间,可以覆盖预定义特性<see cref="TimeoutAttribute"/></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [Timeout(10 * 1000)]
        [HttpPost("v2/merchant/create")]
        [JsonReturn]
        ITask<Response<MerchantCreateResponseModel>> Create(
            [Headers]ServiceProviderSignSettings serviceProviderSignSettings,
            [JsonContent]MerchantCreateRequestModel createMerchantRequestModel,
            [Timeout]TimeSpan? timeout = null,
            CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// 查询商户信息
        /// </summary>
        /// <param name="serviceProviderSignSettings"></param>
        /// <param name="merchantInfoRequestModel"></param>
        /// <param name="timeout">超时时间,可以覆盖预定义特性<see cref="TimeoutAttribute"/></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [Timeout(5 * 1000)]
        [HttpPost("v2/merchant/info")]
        [JsonReturn]
        ITask<Response<MerchantInfoResponseModel>> Info(
            [Headers]ServiceProviderSignSettings serviceProviderSignSettings,
            [JsonContent]MerchantInfoRequestModel merchantInfoRequestModel,
            [Timeout]TimeSpan? timeout = null,
            CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// 禁用商户
        /// </summary>
        /// <param name="serviceProviderSignSettings"></param>
        /// <param name="closeMerchantRequestModel"></param>
        /// <param name="timeout">超时时间,可以覆盖预定义特性<see cref="TimeoutAttribute"/></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [Timeout(5 * 1000)]
        [HttpPost("v2/merchant/close")]
        [JsonReturn]
        ITask<Response<MerchantCloseResponseModel>> Close(
            [Headers]ServiceProviderSignSettings serviceProviderSignSettings,
            [JsonContent]MerchantCloseRequestModel closeMerchantRequestModel,
            [Timeout]TimeSpan? timeout = null,
            CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// 根据银行卡号获取银行信息
        /// </summary>
        /// <param name="serviceProviderSignSettings"></param>
        /// <param name="bankRequestModel"></param>
        /// <param name="timeout">超时时间,可以覆盖预定义特性<see cref="TimeoutAttribute"/></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [Timeout(5 * 1000)]
        [HttpPost("v2/merchant/banks")]
        [JsonReturn]
        ITask<Response<BankResponseModel>> Banks(
            [Headers]ServiceProviderSignSettings serviceProviderSignSettings,
            [JsonContent]BankRequestModel bankRequestModel,
            [Timeout]TimeSpan? timeout = null,
            CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// 模糊查询银行支行
        /// </summary>
        /// <param name="serviceProviderSignSettings"></param>
        /// <param name="bankBranchesRequestModel"></param>
        /// <param name="timeout">超时时间,可以覆盖预定义特性<see cref="TimeoutAttribute"/></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [Timeout(5 * 1000)]
        [HttpPost("v2/merchant/branches")]
        [JsonReturn]
        ITask<Response<BankBranchesResponseModel>> BankBranches(
            [Headers]ServiceProviderSignSettings serviceProviderSignSettings,
            [JsonContent]BankBranchesRequestModel bankBranchesRequestModel,
            [Timeout]TimeSpan? timeout = null,
            CancellationToken cancellationToken = default(CancellationToken)
            );

        /// <summary>
        /// 上传图片
        /// </summary>
        /// <param name="serviceProviderSignSettings"></param>
        /// <param name="imageUploadRequestModel"></param>
        /// <param name="timeout">超时时间,可以覆盖预定义特性<see cref="TimeoutAttribute"/></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [Timeout(10 * 1000)]
        [HttpPost("v2/merchant/upload")]
        [JsonReturn]
        ITask<Response<ImageUploadResponseModel>> ImageUpload(
            [Headers]ServiceProviderSignSettings serviceProviderSignSettings,
            [JsonContent]ImageUploadRequestModel imageUploadRequestModel,
            [Timeout]TimeSpan? timeout = null,
            CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// 对公银行查询接口
        /// </summary>
        /// <param name="serviceProviderSignSettings"></param>
        /// <param name="pubBankRequestModel"></param>
        /// <param name="timeout">超时时间,可以覆盖预定义特性<see cref="TimeoutAttribute"/></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [Timeout(5 * 1000)]
        [HttpPost("v2/merchant/pub_banks")]
        [JsonReturn]
        ITask<Response<PubBankResponseModel>> PubBank(
            [Headers]ServiceProviderSignSettings serviceProviderSignSettings,
            [JsonContent]PubBankRequestModel pubBankRequestModel,
            [Timeout]TimeSpan? timeout = null,
            CancellationToken cancellationToken = default(CancellationToken));
    }
}