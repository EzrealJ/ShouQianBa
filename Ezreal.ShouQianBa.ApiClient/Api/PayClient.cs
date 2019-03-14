using Ezreal.ShouQianBa.ApiClient.ApiContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiClient;
using Ezreal.ShouQianBa.ApiClient.Sign;
using Ezreal.ShouQianBa.ApiClient.ApiParameterModels.Response;
using Ezreal.ShouQianBa.ApiClient.ApiParameterModels.Request.Pay;
using Ezreal.ShouQianBa.ApiClient.ApiParameterModels.Response.Pay;
using System.Threading;
using Ezreal.ShouQianBa.ApiClient.Extension;

namespace Ezreal.ShouQianBa.ApiClient.Api
{
    /// <summary>
    /// 支付请求
    /// </summary>
    public class PayClient
    {
        /// <summary>
        /// 支付Client
        /// </summary>
        /// <param name="payContract">支付交互协议,可以从依赖注入环境获取,当无法获取到传入的实例时则调用<see cref="HttpApiFactory.Create{IPayContract}()"/></param>
        public PayClient(IPayContract payContract)
        {
            PayContract = payContract ?? HttpApiFactory.Create<IPayContract>();
        }
        /// <summary>
        /// 支付交互协议
        /// </summary>
        public IPayContract PayContract { get; }

        /// <summary>
        /// 使用传入的签名配置签名并代理调用<see cref="IPayContract.Pay"/>
        /// </summary>
        /// <param name="requestModel"></param>
        /// <param name="terminalSignSettings"></param>
        /// <param name="timeout"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public ITask<Response<OrderGenericResponseModel>> Pay(OrderCreateRequestModel requestModel, TerminalSignSettings terminalSignSettings, TimeSpan? timeout = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return PayContract.Pay(requestModel.SignByTerminalSignProvider(terminalSignSettings), requestModel, timeout == null ? null : new WebApiClient.Parameterables.Timeout(timeout.Value), cancellationToken);
        }
        /// <summary>
        /// 使用传入的签名配置签名并代理调用<see cref="IPayContract.Precreate"/>
        /// </summary>
        /// <param name="requestModel"></param>
        /// <param name="terminalSignSettings"></param>
        /// <param name="timeout"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public ITask<Response<OrderPrecreateSyncResponseModel>> Precreate(OrderPrecreateRequestModel requestModel, TerminalSignSettings terminalSignSettings, TimeSpan? timeout = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return PayContract.Precreate(requestModel.SignByTerminalSignProvider(terminalSignSettings), requestModel, timeout == null ? null : new WebApiClient.Parameterables.Timeout(timeout.Value), cancellationToken);
        }
        /// <summary>
        /// 使用传入的签名配置签名并代理调用<see cref="IPayContract.Query"/>
        /// </summary>
        /// <param name="requestModel"></param>
        /// <param name="terminalSignSettings"></param>
        /// <param name="timeout"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public ITask<Response<OrderGenericResponseModel>> Query(OrderTokenRequestModel requestModel, TerminalSignSettings terminalSignSettings, TimeSpan? timeout = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return PayContract.Query(requestModel.SignByTerminalSignProvider(terminalSignSettings), requestModel, timeout == null ? null : new WebApiClient.Parameterables.Timeout(timeout.Value), cancellationToken);
        }
        /// <summary>
        /// 使用传入的签名配置签名并代理调用<see cref="IPayContract.Cancel"/>
        /// </summary>
        /// <param name="requestModel"></param>
        /// <param name="terminalSignSettings"></param>
        /// <param name="timeout"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public ITask<Response<OrderGenericResponseModel>> Cancel(OrderTokenRequestModel requestModel, TerminalSignSettings terminalSignSettings, TimeSpan? timeout = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return PayContract.Cancel(requestModel.SignByTerminalSignProvider(terminalSignSettings), requestModel, timeout == null ? null : new WebApiClient.Parameterables.Timeout(timeout.Value), cancellationToken);
        }
        /// <summary>
        /// 使用传入的签名配置签名并代理调用<see cref="IPayContract.Revoke"/>
        /// </summary>
        /// <param name="requestModel"></param>
        /// <param name="terminalSignSettings"></param>
        /// <param name="timeout"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public ITask<Response<OrderGenericResponseModel>> Revoke(OrderTokenRequestModel requestModel, TerminalSignSettings terminalSignSettings, TimeSpan? timeout = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return PayContract.Revoke(requestModel.SignByTerminalSignProvider(terminalSignSettings), requestModel, timeout == null ? null : new WebApiClient.Parameterables.Timeout(timeout.Value), cancellationToken);
        }
        /// <summary>
        /// 使用传入的签名配置签名并代理调用<see cref="IPayContract.Refund"/>
        /// </summary>
        /// <param name="requestModel"></param>
        /// <param name="terminalSignSettings"></param>
        /// <param name="timeout"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public ITask<Response<OrderGenericResponseModel>> Refund(OrderRefundRequestModel requestModel, TerminalSignSettings terminalSignSettings, TimeSpan? timeout = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return PayContract.Refund(requestModel.SignByTerminalSignProvider(terminalSignSettings), requestModel, timeout == null ? null : new WebApiClient.Parameterables.Timeout(timeout.Value), cancellationToken);
        }

    }

}
