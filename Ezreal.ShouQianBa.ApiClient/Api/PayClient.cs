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
    public class PayClient
    {
        public PayClient(IPayContract payContract)
        {
            PayContract = payContract ?? HttpApiFactory.Create<IPayContract>();
        }

        public IPayContract PayContract { get; }


        public ITask<Response<OrderGenericResponseModel>> Pay(OrderCreateRequestModel requestModel, TerminalSignSettings terminalSignSettings, TimeSpan timeout = default(TimeSpan), CancellationToken cancellationToken = default(CancellationToken))
        {
            return PayContract.Pay(requestModel.SignByTerminalSignProvider(terminalSignSettings), requestModel, new WebApiClient.Parameterables.Timeout(timeout), cancellationToken);
        }

        public ITask<Response<OrderPrecreateSyncResponseModel>> Precreate(OrderPrecreateRequestModel requestModel, TerminalSignSettings terminalSignSettings, TimeSpan timeout = default(TimeSpan), CancellationToken cancellationToken = default(CancellationToken))
        {
            return PayContract.Precreate(requestModel.SignByTerminalSignProvider(terminalSignSettings), requestModel, new WebApiClient.Parameterables.Timeout(timeout), cancellationToken);
        }

        public ITask<Response<OrderGenericResponseModel>> Query(OrderTokenRequestModel requestModel, TerminalSignSettings terminalSignSettings, TimeSpan timeout = default(TimeSpan), CancellationToken cancellationToken = default(CancellationToken))
        {
            return PayContract.Query(requestModel.SignByTerminalSignProvider(terminalSignSettings), requestModel, new WebApiClient.Parameterables.Timeout(timeout), cancellationToken);
        }

        public ITask<Response<OrderGenericResponseModel>> Cancel(OrderTokenRequestModel requestModel, TerminalSignSettings terminalSignSettings, TimeSpan timeout = default(TimeSpan), CancellationToken cancellationToken = default(CancellationToken))
        {
            return PayContract.Cancel(requestModel.SignByTerminalSignProvider(terminalSignSettings), requestModel, new WebApiClient.Parameterables.Timeout(timeout), cancellationToken);
        }

        public ITask<Response<OrderGenericResponseModel>> Revoke(OrderTokenRequestModel requestModel, TerminalSignSettings terminalSignSettings, TimeSpan timeout = default(TimeSpan), CancellationToken cancellationToken = default(CancellationToken))
        {
            return PayContract.Revoke(requestModel.SignByTerminalSignProvider(terminalSignSettings), requestModel, new WebApiClient.Parameterables.Timeout(timeout), cancellationToken);
        }

        public ITask<Response<OrderGenericResponseModel>> Pay(OrderRefundRequestModel requestModel, TerminalSignSettings terminalSignSettings, TimeSpan timeout = default(TimeSpan), CancellationToken cancellationToken = default(CancellationToken))
        {
            return PayContract.Refund(requestModel.SignByTerminalSignProvider(terminalSignSettings), requestModel, new WebApiClient.Parameterables.Timeout(timeout), cancellationToken);
        }
    }

    public static class PayClientExtension
    {

    }
}
