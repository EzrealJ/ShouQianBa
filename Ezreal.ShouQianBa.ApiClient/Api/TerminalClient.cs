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
    public class TerminalClient
    {
        public TerminalClient(ITerminalContract terminalContract )
        {
            TerminalContract = terminalContract ?? HttpApiFactory.Create<ITerminalContract>();
        }

        public ITerminalContract TerminalContract { get; }

        public ITask<Response<TerminalActivateResponseModel>> Activate(TerminalActivateRequestModel requestModel, ServiceProviderSignSettings serviceProviderSignSettings = null, TimeSpan timeout = default(TimeSpan), CancellationToken cancellationToken = default(CancellationToken))
        {
            return TerminalContract.Activate(requestModel.SignByServiceProviderSignProvider(serviceProviderSignSettings), requestModel, new WebApiClient.Parameterables.Timeout(timeout), cancellationToken);
        }

        public ITask<Response<TerminalCheckinResponseModel>> Pay(TerminalCheckinRequestModel requestModel, TerminalSignSettings terminalSignSettings, TimeSpan timeout = default(TimeSpan), CancellationToken cancellationToken = default(CancellationToken))
        {
            return TerminalContract.Checkin(requestModel.SignByTerminalSignProvider(terminalSignSettings), requestModel, new WebApiClient.Parameterables.Timeout(timeout), cancellationToken);
        }
    }
}
