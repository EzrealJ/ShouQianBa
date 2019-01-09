using Ezreal.SDK.ShouQianBa.ApiParameterModels.Request.Pay;
using Ezreal.SDK.ShouQianBa.ApiParameterModels.Response;
using Ezreal.SDK.ShouQianBa.ApiParameterModels.Response.Pay;
using Ezreal.SDK.ShouQianBa.Attributes;
using Ezreal.SDK.ShouQianBa.Sign;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiClient;
using WebApiClient.Attributes;
using WebApiClient.Parameterables;

namespace Ezreal.SDK.ShouQianBa.ApiContract
{
    public interface IPayContract:IHttpApi
    {
        [Timeout(5 * 1000)]
        [HttpPost("upay/v2/pay")]
        [JsonReturn]
        ITask<Response<OrderGenericResponseModel>> Pay([Headers]TerminalSignProvider<OrderCreateRequestModel> terminalSignProvider, [JsonContent]OrderCreateRequestModel orderCreateRequestModel, Timeout timeout = null);
        [Timeout(5 * 1000)]
        [HttpPost("upay/v2/precreate")]
        [JsonReturn]
        ITask<Response<OrderPrecreateSyncResponseModel>> Precreate([Headers]TerminalSignProvider<OrderPrecreateRequestModel> terminalSignProvider, [JsonContent]OrderPrecreateRequestModel orderPrecreateRequestModel, Timeout timeout = null);
        [Timeout(5 * 1000)]
        [HttpPost("upay/v2/query")]
        [JsonReturn]
        ITask<Response<OrderGenericResponseModel>> Query([Headers]TerminalSignProvider<OrderTokenRequestModel> terminalSignProvider, [JsonContent]OrderTokenRequestModel orderTokenRequestModel, Timeout timeout = null);
        [Timeout(5 * 1000)]
        [HttpPost("upay/v2/cancel")]
        [JsonReturn]
        ITask<Response<OrderGenericResponseModel>> Cancel([Headers]TerminalSignProvider<OrderTokenRequestModel> terminalSignProvider, [JsonContent]OrderTokenRequestModel orderTokenRequestModel, Timeout timeout = null);
        [Timeout(5 * 1000)]
        [HttpPost("upay/v2/revoke")]
        [JsonReturn]
        ITask<Response<OrderGenericResponseModel>> Revoke([Headers]TerminalSignProvider<OrderTokenRequestModel> terminalSignProvider, [JsonContent]OrderTokenRequestModel orderTokenRequestModel, Timeout timeout = null);
        [Timeout(5 * 1000)]
        [HttpPost("upay/v2/refund")]
        [JsonReturn]
        ITask<Response<OrderGenericResponseModel>> Refund([Headers]TerminalSignProvider<OrderRefundRequestModel> terminalSignProvider, [JsonContent]OrderRefundRequestModel orderRefundRequestModel, Timeout timeout = null);
    }
}
