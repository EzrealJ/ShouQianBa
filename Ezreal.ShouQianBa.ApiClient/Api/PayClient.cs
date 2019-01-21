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
        public PayClient(IPayContract payContract)
        {
            PayContract = payContract ?? HttpApiFactory.Create<IPayContract>();
        }

        public IPayContract PayContract { get; }


        public ITask<Response<OrderGenericResponseModel>> Pay(OrderCreateRequestModel requestModel, TerminalSignSettings terminalSignSettings, TimeSpan? timeout = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return PayContract.Pay(requestModel.SignByTerminalSignProvider(terminalSignSettings), requestModel, timeout==null?null:new WebApiClient.Parameterables.Timeout(timeout.Value), cancellationToken);
        }

        public ITask<Response<OrderPrecreateSyncResponseModel>> Precreate(OrderPrecreateRequestModel requestModel, TerminalSignSettings terminalSignSettings, TimeSpan? timeout = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return PayContract.Precreate(requestModel.SignByTerminalSignProvider(terminalSignSettings), requestModel, timeout==null?null:new WebApiClient.Parameterables.Timeout(timeout.Value), cancellationToken);
        }

        public ITask<Response<OrderGenericResponseModel>> Query(OrderTokenRequestModel requestModel, TerminalSignSettings terminalSignSettings, TimeSpan? timeout = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return PayContract.Query(requestModel.SignByTerminalSignProvider(terminalSignSettings), requestModel, timeout==null?null:new WebApiClient.Parameterables.Timeout(timeout.Value), cancellationToken);
        }

        public ITask<Response<OrderGenericResponseModel>> Cancel(OrderTokenRequestModel requestModel, TerminalSignSettings terminalSignSettings, TimeSpan? timeout = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return PayContract.Cancel(requestModel.SignByTerminalSignProvider(terminalSignSettings), requestModel, timeout==null?null:new WebApiClient.Parameterables.Timeout(timeout.Value), cancellationToken);
        }

        public ITask<Response<OrderGenericResponseModel>> Revoke(OrderTokenRequestModel requestModel, TerminalSignSettings terminalSignSettings, TimeSpan? timeout = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return PayContract.Revoke(requestModel.SignByTerminalSignProvider(terminalSignSettings), requestModel, timeout==null?null:new WebApiClient.Parameterables.Timeout(timeout.Value), cancellationToken);
        }

        public ITask<Response<OrderGenericResponseModel>> Refund(OrderRefundRequestModel requestModel, TerminalSignSettings terminalSignSettings, TimeSpan? timeout = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return PayContract.Refund(requestModel.SignByTerminalSignProvider(terminalSignSettings), requestModel, timeout==null?null:new WebApiClient.Parameterables.Timeout(timeout.Value), cancellationToken);
        }

    }

}
