using Ezreal.ShouQianBa.ApiClient.ApiParameterModels.Request.Merchant;
using Ezreal.ShouQianBa.ApiClient.ApiParameterModels.Response;
using Ezreal.ShouQianBa.ApiClient.ApiParameterModels.Response.Merchant;
using Ezreal.ShouQianBa.ApiClient.Sign;
using System.Threading;
using WebApiClient;
using WebApiClient.Attributes;
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
        /// <param name="sign">签名</param>
        /// <param name="createMerchantRequestModel">创建商户的信息</param>
        /// <param name="timeout">超时时间,可以覆盖预定义特性<see cref="TimeoutAttribute"/></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [Timeout(10 * 1000)]
        [HttpPost("v2/merchant/create")]
        [JsonReturn]
        ITask<Response<MerchantCreateResponseModel>> Create(
            [Headers]Sign<ServiceProviderSignProvider, MerchantCreateRequestModel> sign,
            [JsonContent]MerchantCreateRequestModel createMerchantRequestModel,
            WebApiClient.Parameterables.Timeout timeout = null,
            CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// 查询商户信息
        /// </summary>
        /// <param name="sign">签名</param>
        /// <param name="merchantInfoRequestModel"></param>
        /// <param name="timeout">超时时间,可以覆盖预定义特性<see cref="TimeoutAttribute"/></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [Timeout(5 * 1000)]
        [HttpPost("v2/merchant/info")]
        [JsonReturn]
        ITask<Response<MerchantInfoResponseModel>> Info(
            [Headers]Sign<ServiceProviderSignProvider, MerchantInfoRequestModel> sign,
            [JsonContent]MerchantInfoRequestModel merchantInfoRequestModel,
            WebApiClient.Parameterables.Timeout timeout = null,
            CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// 禁用商户
        /// </summary>
        /// <param name="sign">签名</param>
        /// <param name="closeMerchantRequestModel"></param>
        /// <param name="timeout">超时时间,可以覆盖预定义特性<see cref="TimeoutAttribute"/></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [Timeout(5 * 1000)]
        [HttpPost("v2/merchant/close")]
        [JsonReturn]
        ITask<Response<MerchantCloseResponseModel>> Close(
            [Headers]Sign<ServiceProviderSignProvider, MerchantCloseRequestModel> sign,
            [JsonContent]MerchantCloseRequestModel closeMerchantRequestModel,
            WebApiClient.Parameterables.Timeout timeout = null,
            CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// 根据银行卡号获取银行信息
        /// </summary>
        /// <param name="sign">签名</param>
        /// <param name="bankRequestModel"></param>
        /// <param name="timeout">超时时间,可以覆盖预定义特性<see cref="TimeoutAttribute"/></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [Timeout(5 * 1000)]
        [HttpPost("v2/merchant/banks")]
        [JsonReturn]
        ITask<Response<BankResponseModel>> Banks(
            [Headers]Sign<ServiceProviderSignProvider, BankRequestModel> sign,
            [JsonContent]BankRequestModel bankRequestModel,
            WebApiClient.Parameterables.Timeout timeout = null,
            CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// 模糊查询银行支行
        /// </summary>
        /// <param name="sign">签名</param>
        /// <param name="bankBranchesRequestModel"></param>
        /// <param name="timeout">超时时间,可以覆盖预定义特性<see cref="TimeoutAttribute"/></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [Timeout(5 * 1000)]
        [HttpPost("v2/merchant/branches")]
        [JsonReturn]
        ITask<Response<BankBranchesResponseModel>> BankBranches(
            [Headers]Sign<ServiceProviderSignProvider, BankBranchesRequestModel> sign,
            [JsonContent]BankBranchesRequestModel bankBranchesRequestModel,
            WebApiClient.Parameterables.Timeout timeout = null,
            CancellationToken cancellationToken = default(CancellationToken)
            );

        /// <summary>
        /// 上传图片
        /// </summary>
        /// <param name="sign">签名</param>
        /// <param name="imageUploadRequestModel"></param>
        /// <param name="timeout">超时时间,可以覆盖预定义特性<see cref="TimeoutAttribute"/></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [Timeout(10 * 1000)]
        [HttpPost("v2/merchant/upload")]
        [JsonReturn]
        ITask<Response<ImageUploadResponseModel>> ImageUpload(
            [Headers]Sign<ServiceProviderSignProvider, ImageUploadRequestModel> sign,
            [JsonContent]ImageUploadRequestModel imageUploadRequestModel,
            WebApiClient.Parameterables.Timeout timeout = null,
            CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// 对公银行查询接口
        /// </summary>
        /// <param name="sign">签名</param>
        /// <param name="pubBankRequestModel"></param>
        /// <param name="timeout">超时时间,可以覆盖预定义特性<see cref="TimeoutAttribute"/></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [Timeout(5 * 1000)]
        [HttpPost("v2/merchant/pub_banks")]
        [JsonReturn]
        ITask<Response<PubBankResponseModel>> PubBank(
            [Headers]Sign<ServiceProviderSignProvider, PubBankRequestModel> sign,
            [JsonContent]PubBankRequestModel pubBankRequestModel,
            WebApiClient.Parameterables.Timeout timeout = null,
            CancellationToken cancellationToken = default(CancellationToken));
    }
}