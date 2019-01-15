using Ezreal.ShouQianBa.ApiClient.ApiParameterModels.Request.Pay;
using Ezreal.ShouQianBa.ApiClient.ApiParameterModels.Response;
using Ezreal.ShouQianBa.ApiClient.ApiParameterModels.Response.Pay;
using Ezreal.ShouQianBa.ApiClient.Attributes;
using Ezreal.ShouQianBa.ApiClient.Sign;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiClient;
using WebApiClient.Attributes;
using WebApiClient.Parameterables;

namespace Ezreal.ShouQianBa.ApiClient.ApiContract
{
    /// <summary>
    /// 支付相关接口
    /// </summary>
    public interface IPayContract : IHttpApi
    {
        /// <summary>
        /// 创建订单
        /// <para>
        /// 一般用于发起当面付扫码交易
        /// </para>
        /// <para>
        /// 与支付宝/微信等支付服务直接提供商相比，此接口的流程存在差异，收钱吧方面这个请求是同步且持续阻塞的，当用户未支付时会一直pending，并不会返回等待支付的状态，因此此接口的预定义超时时间是50ms
        /// </para>
        /// </summary>
        /// <param name="terminalSignProvider">签名对象</param>
        /// <param name="orderCreateRequestModel">创建订单的信息</param>
        /// <param name="timeout">超时时间,可以覆盖预定义特性<see cref="TimeoutAttribute"/></param>
        /// <returns></returns>
        [Timeout(50 * 1000)]
        [HttpPost("upay/v2/pay")]
        [JsonReturn]
        ITask<Response<OrderGenericResponseModel>> Pay([Headers]TerminalSignProvider<OrderCreateRequestModel> terminalSignProvider, [JsonContent]OrderCreateRequestModel orderCreateRequestModel, Timeout timeout = null);
        /// <summary>
        /// 订单预创建接口
        /// <para>
        /// 一般用于生成二维码提供给用户扫码支付
        /// </para>
        /// </summary>
        /// <param name="terminalSignProvider">签名对象</param>
        /// <param name="orderPrecreateRequestModel">预创建订单的信息</param>
        /// <param name="timeout">超时时间,可以覆盖预定义特性<see cref="TimeoutAttribute"/></param>
        /// <returns></returns>
        [Timeout(5 * 1000)]
        [HttpPost("upay/v2/precreate")]
        [JsonReturn]
        ITask<Response<OrderPrecreateSyncResponseModel>> Precreate([Headers]TerminalSignProvider<OrderPrecreateRequestModel> terminalSignProvider, [JsonContent]OrderPrecreateRequestModel orderPrecreateRequestModel, Timeout timeout = null);
        /// <summary>
        /// 查询订单接口
        /// </summary>
        /// <param name="terminalSignProvider">签名对象</param>
        /// <param name="orderTokenRequestModel">订单凭证对象<seealso cref="OrderTokenRequestModel"/></param>
        /// <param name="timeout">超时时间,可以覆盖预定义特性<see cref="TimeoutAttribute"/></param>
        /// <returns></returns>
        [Timeout(5 * 1000)]
        [HttpPost("upay/v2/query")]
        [JsonReturn]
        ITask<Response<OrderGenericResponseModel>> Query([Headers]TerminalSignProvider<OrderTokenRequestModel> terminalSignProvider, [JsonContent]OrderTokenRequestModel orderTokenRequestModel, Timeout timeout = null);
        /// <summary>
        /// 取消订单
        /// </summary>
        /// <param name="terminalSignProvider">签名对象</param>
        /// <param name="orderTokenRequestModel">订单凭证对象<seealso cref="OrderTokenRequestModel"/></param>
        /// <param name="timeout">超时时间,可以覆盖预定义特性<see cref="TimeoutAttribute"/></param>
        /// <returns></returns>
        [Timeout(5 * 1000)]
        [HttpPost("upay/v2/cancel")]
        [JsonReturn]
        ITask<Response<OrderGenericResponseModel>> Cancel([Headers]TerminalSignProvider<OrderTokenRequestModel> terminalSignProvider, [JsonContent]OrderTokenRequestModel orderTokenRequestModel, Timeout timeout = null);
        /// <summary>
        /// 手动撤单
        /// <para>
        /// 整体和<seealso cref="IPayContract.Cancel(TerminalSignProvider{OrderTokenRequestModel}, OrderTokenRequestModel, Timeout)"/>的结果没有任何差异,但执行人工撤单时建议使用此接口，这样会在收钱吧方的数据上体现出区别
        /// </para>
        /// </summary>
        /// <param name="terminalSignProvider">签名对象</param>
        /// <param name="orderTokenRequestModel">订单凭证对象<seealso cref="OrderTokenRequestModel"/></param>
        /// <param name="timeout">超时时间,可以覆盖预定义特性<see cref="TimeoutAttribute"/></param>
        /// <returns></returns>
        [Timeout(5 * 1000)]
        [HttpPost("upay/v2/revoke")]
        [JsonReturn]
        ITask<Response<OrderGenericResponseModel>> Revoke([Headers]TerminalSignProvider<OrderTokenRequestModel> terminalSignProvider, [JsonContent]OrderTokenRequestModel orderTokenRequestModel, Timeout timeout = null);
        /// <summary>
        /// 退款
        /// </summary>
        /// <param name="terminalSignProvider">签名对象</param>
        /// <param name="orderRefundRequestModel">退款参数对象<seealso cref="OrderRefundRequestModel"/></param>
        /// <param name="timeout">超时时间,可以覆盖预定义特性<see cref="TimeoutAttribute"/></param>
        /// <returns></returns>
        [Timeout(5 * 1000)]
        [HttpPost("upay/v2/refund")]
        [JsonReturn]
        ITask<Response<OrderGenericResponseModel>> Refund([Headers]TerminalSignProvider<OrderRefundRequestModel> terminalSignProvider, [JsonContent]OrderRefundRequestModel orderRefundRequestModel, Timeout timeout = null);
    }
}
