using Ezreal.ShouQianBa.ApiClient.ApiParameterModels.Request.Merchant;
using Ezreal.ShouQianBa.ApiClient.ApiParameterModels.Response;
using Ezreal.ShouQianBa.ApiClient.ApiParameterModels.Response.Merchant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiClient;
using Ezreal.ShouQianBa.ApiClient.Sign;
using System.Threading;
using Ezreal.ShouQianBa.ApiClient.ApiContract;
using Ezreal.ShouQianBa.ApiClient.Extension;

namespace Ezreal.ShouQianBa.ApiClient.Api
{
    /// <summary>
    /// 商户请求
    /// </summary>
    public class MerchantClient
    {
        /// <summary>
        /// 商户Client
        /// </summary>
        /// <param name="merchantContract">商户交互协议,可以从依赖注入环境获取,当无法获取到传入的实例时则调用<see cref="HttpApiFactory.Create{IMerchantContract}()"/></param>
        public MerchantClient(IMerchantContract merchantContract)
        {
            MerchantContract = merchantContract ?? HttpApiFactory.Create<IMerchantContract>();
        }
        /// <summary>
        /// 商户交互协议
        /// </summary>
        public IMerchantContract MerchantContract { get; }

        /// <summary>
        /// 使用全局默认或传入的签名配置签名并代理调用<see cref="IMerchantContract.Create"/>
        /// </summary>
        /// <param name="requestModel"></param>
        /// <param name="serviceProviderSignSettings"></param>
        /// <param name="timeout"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public ITask<Response<MerchantCreateResponseModel>> Create(MerchantCreateRequestModel requestModel, ServiceProviderSignSettings serviceProviderSignSettings = null, TimeSpan? timeout = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return MerchantContract.Create(requestModel.SignByServiceProviderSignProvider(serviceProviderSignSettings), requestModel, timeout==null?null:new WebApiClient.Parameterables.Timeout(timeout.Value), cancellationToken);
        }
        /// <summary>
        /// 使用全局默认或传入的签名配置签名并代理调用<see cref="IMerchantContract.Info"/>
        /// </summary>
        /// <param name="requestModel"></param>
        /// <param name="serviceProviderSignSettings"></param>
        /// <param name="timeout"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public ITask<Response<MerchantInfoResponseModel>> Info(MerchantInfoRequestModel requestModel, ServiceProviderSignSettings serviceProviderSignSettings = null, TimeSpan? timeout = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return MerchantContract.Info(requestModel.SignByServiceProviderSignProvider(serviceProviderSignSettings), requestModel, timeout==null?null:new WebApiClient.Parameterables.Timeout(timeout.Value), cancellationToken);
        }
        /// <summary>
        /// 使用全局默认或传入的签名配置签名并代理调用<see cref="IMerchantContract.Close"/>
        /// </summary>
        /// <param name="requestModel"></param>
        /// <param name="serviceProviderSignSettings"></param>
        /// <param name="timeout"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public ITask<Response<MerchantCloseResponseModel>> Close(MerchantCloseRequestModel requestModel, ServiceProviderSignSettings serviceProviderSignSettings = null, TimeSpan? timeout = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return MerchantContract.Close(requestModel.SignByServiceProviderSignProvider(serviceProviderSignSettings), requestModel, timeout==null?null:new WebApiClient.Parameterables.Timeout(timeout.Value), cancellationToken);
        }
        /// <summary>
        /// 使用全局默认或传入的签名配置签名并代理调用<see cref="IMerchantContract.Banks"/>
        /// </summary>
        /// <param name="requestModel"></param>
        /// <param name="serviceProviderSignSettings"></param>
        /// <param name="timeout"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public ITask<Response<BankResponseModel>> Banks(BankRequestModel requestModel, ServiceProviderSignSettings serviceProviderSignSettings = null, TimeSpan? timeout = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return MerchantContract.Banks(requestModel.SignByServiceProviderSignProvider(serviceProviderSignSettings), requestModel, timeout==null?null:new WebApiClient.Parameterables.Timeout(timeout.Value), cancellationToken);
        }
        /// <summary>
        /// 使用全局默认或传入的签名配置签名并代理调用<see cref="IMerchantContract.BankBranches"/>
        /// </summary>
        /// <param name="requestModel"></param>
        /// <param name="serviceProviderSignSettings"></param>
        /// <param name="timeout"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public ITask<Response<BankBranchesResponseModel>> BankBranches(BankBranchesRequestModel requestModel, ServiceProviderSignSettings serviceProviderSignSettings = null, TimeSpan? timeout = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return MerchantContract.BankBranches(requestModel.SignByServiceProviderSignProvider(serviceProviderSignSettings), requestModel, timeout==null?null:new WebApiClient.Parameterables.Timeout(timeout.Value), cancellationToken);
        }
        /// <summary>
        /// 使用全局默认或传入的签名配置签名并代理调用<see cref="IMerchantContract.PubBank"/>
        /// </summary>
        /// <param name="requestModel"></param>
        /// <param name="serviceProviderSignSettings"></param>
        /// <param name="timeout"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public ITask<Response<PubBankResponseModel>> PubBank(PubBankRequestModel requestModel, ServiceProviderSignSettings serviceProviderSignSettings = null, TimeSpan? timeout = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return MerchantContract.PubBank(requestModel.SignByServiceProviderSignProvider(serviceProviderSignSettings), requestModel, timeout==null?null:new WebApiClient.Parameterables.Timeout(timeout.Value), cancellationToken);
        }
        /// <summary>
        /// 使用全局默认或传入的签名配置签名并代理调用<see cref="IMerchantContract.ImageUpload"/>
        /// </summary>
        /// <param name="requestModel"></param>
        /// <param name="serviceProviderSignSettings"></param>
        /// <param name="timeout"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public ITask<Response<ImageUploadResponseModel>> ImageUpload(ImageUploadRequestModel requestModel, ServiceProviderSignSettings serviceProviderSignSettings = null, TimeSpan? timeout = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return MerchantContract.ImageUpload(requestModel.SignByServiceProviderSignProvider(serviceProviderSignSettings), requestModel, timeout==null?null:new WebApiClient.Parameterables.Timeout(timeout.Value), cancellationToken);
        }




    }
}
