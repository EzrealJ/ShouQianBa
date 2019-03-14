using Ezreal.ShouQianBa.ApiClient.ApiContract;
using Ezreal.ShouQianBa.ApiClient.ApiParameterModels.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiClient;
using Ezreal.ShouQianBa.ApiClient.ApiParameterModels.Request.Terminal;
using Ezreal.ShouQianBa.ApiClient.ApiParameterModels.Response.Terminal;
using Ezreal.ShouQianBa.ApiClient.Extension;
using Ezreal.ShouQianBa.ApiClient.Sign;
using System.Threading;

namespace Ezreal.ShouQianBa.ApiClient.Api
{
    /// <summary>
    /// 设备请求
    /// </summary>
    public class TerminalClient
    {
        /// <summary>
        /// 设备Client
        /// </summary>
        /// <param name="terminalContract">设备交互协议，可以从依赖注入环境获取,当无法获取到传入的实例时则调用<see cref="HttpApiFactory.Create{ITerminalContract}()"/></param>
        public TerminalClient(ITerminalContract terminalContract)
        {
            TerminalContract = terminalContract ?? HttpApiFactory.Create<ITerminalContract>();
        }
        /// <summary>
        /// 设备交互协议
        /// </summary>
        public ITerminalContract TerminalContract { get; }
        /// <summary>
        /// 使用全局默认或传入的签名配置签名并代理调用<see cref="ITerminalContract.Activate"/>
        /// </summary>
        /// <param name="requestModel"></param>
        /// <param name="serviceProviderSignSettings"></param>
        /// <param name="timeout"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public ITask<Response<TerminalActivateResponseModel>> Activate(TerminalActivateRequestModel requestModel, ServiceProviderSignSettings serviceProviderSignSettings = null, TimeSpan? timeout = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return TerminalContract.Activate(requestModel.SignByServiceProviderSignProvider(serviceProviderSignSettings), requestModel, timeout == null ? null : new WebApiClient.Parameterables.Timeout(timeout.Value), cancellationToken);
        }
        /// <summary>
        /// 使用传入的签名配置签名并代理调用<see cref="ITerminalContract.Checkin"/>
        /// </summary>
        /// <param name="requestModel"></param>
        /// <param name="terminalSignSettings"></param>
        /// <param name="timeout"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public ITask<Response<TerminalCheckinResponseModel>> Checkin(TerminalCheckinRequestModel requestModel, TerminalSignSettings terminalSignSettings, TimeSpan? timeout = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return TerminalContract.Checkin(requestModel.SignByTerminalSignProvider(terminalSignSettings), requestModel, timeout == null ? null : new WebApiClient.Parameterables.Timeout(timeout.Value), cancellationToken);
        }
    }
}
