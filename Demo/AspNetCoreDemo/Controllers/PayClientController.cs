using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Ezreal.ShouQianBa.ApiClient.Api;
using Ezreal.ShouQianBa.ApiClient.ApiContract;
using Ezreal.ShouQianBa.ApiClient.ApiModels.Generic;
using Ezreal.ShouQianBa.ApiClient.ApiModels.Request.Pay;
using Ezreal.ShouQianBa.ApiClient.ApiModels.Response;
using Ezreal.ShouQianBa.ApiClient.ApiModels.Response.Pay;
using Ezreal.ShouQianBa.ApiClient.Enums;
using Ezreal.ShouQianBa.ApiClient.Sign;
using Microsoft.AspNetCore.Mvc;
using WebApiClient;

namespace AspNetCoreDemo.Controllers
{
    /// <summary>
    /// 支付
    /// </summary>
    [Route("[controller]")]
    public class PayClientController : Controller
    {
        public PayClientController(IPayContract payClient, TerminalSignSettings terminalSignSettings)
        {
            PayClient = payClient;
            TerminalSignSettings = terminalSignSettings;
        }

        public IPayContract PayClient { get; }
        public TerminalSignSettings TerminalSignSettings { get; }



        /// <summary>
        /// 支付
        /// </summary>
        /// <param name="requestModel"></param>
        /// <param name="terminalSignSettings"></param>
        /// <returns></returns>
        [HttpPost(nameof(Pay))]
        public async Task<Response<OrderGenericResponseModel>> Pay([FromBody]OrderCreateRequestModel requestModel, [FromQuery]TerminalSignSettings terminalSignSettings)
        {
            terminalSignSettings = string.IsNullOrWhiteSpace(terminalSignSettings.TerminalKey + terminalSignSettings.TerminalSerialNo) ? TerminalSignSettings : terminalSignSettings;
            requestModel.TerminalSerialNo = string.IsNullOrWhiteSpace(requestModel.TerminalSerialNo) ? terminalSignSettings.TerminalSerialNo : requestModel.TerminalSerialNo;
            return await PayClient.Pay(terminalSignSettings,requestModel);
        }
        /// <summary>
        /// 预创建订单
        /// </summary>
        /// <param name="requestModel"></param>
        /// <param name="terminalSignSettings"></param>
        /// <returns></returns>
        [HttpPost(nameof(Precreate))]
        public async Task<Response<OrderPrecreateSyncResponseModel>> Precreate([FromBody]OrderPrecreateRequestModel requestModel, [FromQuery]TerminalSignSettings terminalSignSettings)
        {
            terminalSignSettings = string.IsNullOrWhiteSpace(terminalSignSettings.TerminalKey + terminalSignSettings.TerminalSerialNo) ? TerminalSignSettings : terminalSignSettings;
            requestModel.TerminalSerialNo = string.IsNullOrWhiteSpace(requestModel.TerminalSerialNo) ? terminalSignSettings.TerminalSerialNo : requestModel.TerminalSerialNo;
            return await PayClient.Precreate(terminalSignSettings, requestModel);
        }
        /// <summary>
        /// 查询订单
        /// </summary>
        /// <param name="requestModel"></param>
        /// <param name="terminalSignSettings"></param>
        /// <returns></returns>
        [HttpGet(nameof(Query))]
        public async Task<Response<OrderGenericResponseModel>> Query([FromQuery]OrderTokenRequestModel requestModel, [FromQuery]TerminalSignSettings terminalSignSettings)
        {
            terminalSignSettings = string.IsNullOrWhiteSpace(terminalSignSettings.TerminalKey + terminalSignSettings.TerminalSerialNo) ? TerminalSignSettings : terminalSignSettings;
            requestModel.TerminalSerialNo = string.IsNullOrWhiteSpace(requestModel.TerminalSerialNo) ? terminalSignSettings.TerminalSerialNo : requestModel.TerminalSerialNo;
            return await PayClient.Query(terminalSignSettings, requestModel);
        }
        /// <summary>
        /// 取消订单
        /// </summary>
        /// <param name="requestModel"></param>
        /// <param name="terminalSignSettings"></param>
        /// <returns></returns>
        [HttpPost(nameof(Cancel))]
        public async Task<Response<OrderGenericResponseModel>> Cancel([FromBody]OrderTokenRequestModel requestModel, [FromQuery]TerminalSignSettings terminalSignSettings)
        {
            terminalSignSettings = string.IsNullOrWhiteSpace(terminalSignSettings.TerminalKey + terminalSignSettings.TerminalSerialNo) ? TerminalSignSettings : terminalSignSettings;
            requestModel.TerminalSerialNo = string.IsNullOrWhiteSpace(requestModel.TerminalSerialNo) ? terminalSignSettings.TerminalSerialNo : requestModel.TerminalSerialNo;
            return await PayClient.Cancel(terminalSignSettings, requestModel);
        }
        /// <summary>
        /// 手动撤单
        /// </summary>
        /// <param name="requestModel"></param>
        /// <param name="terminalSignSettings"></param>
        /// <returns></returns>
        [HttpPost(nameof(Revoke))]
        public async Task<Response<OrderGenericResponseModel>> Revoke([FromBody]OrderTokenRequestModel requestModel, [FromQuery]TerminalSignSettings terminalSignSettings)
        {
            terminalSignSettings = string.IsNullOrWhiteSpace(terminalSignSettings.TerminalKey + terminalSignSettings.TerminalSerialNo) ? TerminalSignSettings : terminalSignSettings;
            requestModel.TerminalSerialNo = string.IsNullOrWhiteSpace(requestModel.TerminalSerialNo) ? terminalSignSettings.TerminalSerialNo : requestModel.TerminalSerialNo;
            return await PayClient.Revoke(terminalSignSettings, requestModel);
        }
        /// <summary>
        /// 退款
        /// </summary>
        /// <param name="requestModel"></param>
        /// <param name="terminalSignSettings"></param>
        /// <returns></returns>
        [HttpPost(nameof(Refund))]
        public async Task<Response<OrderGenericResponseModel>> Refund([FromBody]OrderRefundRequestModel requestModel, [FromQuery]TerminalSignSettings terminalSignSettings)
        {
            terminalSignSettings = string.IsNullOrWhiteSpace(terminalSignSettings.TerminalKey + terminalSignSettings.TerminalSerialNo) ? TerminalSignSettings : terminalSignSettings;
            requestModel.TerminalSerialNo = string.IsNullOrWhiteSpace(requestModel.TerminalSerialNo) ? terminalSignSettings.TerminalSerialNo : requestModel.TerminalSerialNo;
            return await PayClient.Refund(terminalSignSettings, requestModel);
        }


        /// <summary>
        /// 标准流程的支付
        /// </summary>
        /// <param name="requestModel"></param>
        /// <param name="terminalSignSettings"></param>
        /// <returns></returns>
        [HttpPost(nameof(PayStandard))]
        public async Task<ShouQianBaOrder> PayStandard([FromBody]OrderCreateRequestModel requestModel, [FromQuery]TerminalSignSettings terminalSignSettings)
        {
            if (requestModel == null)
            {
                throw new ArgumentNullException(nameof(requestModel));
            }
            terminalSignSettings = string.IsNullOrWhiteSpace(terminalSignSettings.TerminalKey + terminalSignSettings.TerminalSerialNo) ? TerminalSignSettings : terminalSignSettings;
            requestModel.TerminalSerialNo = string.IsNullOrWhiteSpace(requestModel.TerminalSerialNo) ? terminalSignSettings.TerminalSerialNo : requestModel.TerminalSerialNo;
           

            //重要！此示例是理论示例，代码正确性尚未验证

            //当面付示例
            //OrderCreateRequestModel orderCreateRequestModel = new OrderCreateRequestModel();
            //orderCreateRequestModel.TerminalSerialNo = terminalSignSettings.TerminalSerialNo;
            //orderCreateRequestModel.DeviceID = "设备的唯一编码";
            //orderCreateRequestModel.ClientSerialNo = "调用方的订单号";
            //orderCreateRequestModel.Operator = "调用方业务关联的操作员";
            //orderCreateRequestModel.PayCertificate = "支付凭证,条码支付场景下为条码内容";
            //orderCreateRequestModel.Summary = $"扣款{0.01}元";
            //orderCreateRequestModel.TotalAmount = 0.01m;
            OrderCreateRequestModel orderCreateRequestModel = requestModel;
            Response<OrderGenericResponseModel> result = null;
            try
            {
                result = await PayClient.Pay(terminalSignSettings, orderCreateRequestModel, TimeSpan.FromSeconds(2))
                .Retry(3, TimeSpan.FromSeconds(5))
                .WhenCatch<HttpStatusFailureException>(ex => ex.StatusCode == System.Net.HttpStatusCode.RequestTimeout);
            }
            //与支付宝/微信等支付服务直接提供商相比，此接口的流程存在差异，收钱吧方面这个请求是同步且持续阻塞的
            //当用户未支付时会一直pending，并不会返回等待支付的状态，因此Pay接口的预定义超时时间是50ms
            //一般而言是等待可以直接得到最终的正确结果,但不建议使用此方式，示例仍设定2s超时时间，在其超时后通过轮询的方式轮询最终态来确定结果
            catch (TaskCanceledException)
            {
                //此处消除 主动超时 异常使业务继续
            }
            catch (Exception)
            {
                throw;
            }
            if (result != null
                && result.ExistsBusinessResponseContent
                && result.BusinessResponseContent.IsEffectiveOrder
                && result.BusinessResponseContent.Order.OrderStatus == OrderStatusEnum.PAID)
            {
                //符合此条件不必轮询,直接认为成功
            }
            OrderTokenRequestModel orderTokenRequestModel = new OrderTokenRequestModel()
            {
                TerminalSerialNo = orderCreateRequestModel.TerminalSerialNo,
                ClientSerialNo = orderCreateRequestModel.ClientSerialNo,
                //由于Pay接口调用时无法确定拿到结果,因此收钱吧方面的订单号是不确定的,因此不建议使用此值。
                SerialNo = null
            };
            CancellationTokenSource queryTaskCancelTokenSource = new CancellationTokenSource();
            //创建一个取消轮询的任务
            Task queryTimeoutTask = Task.Delay(TimeSpan.FromSeconds(60)).ContinueWith(task => queryTaskCancelTokenSource.Cancel());
            try
            {
                result = await PayClient.Query( terminalSignSettings, orderTokenRequestModel, TimeSpan.FromSeconds(2), queryTaskCancelTokenSource.Token)
                .Retry(30, TimeSpan.FromSeconds(2))//设定轮询等待为2s，轮询不超过30次
                .WhenCatch<HttpStatusFailureException>(ex => ex.StatusCode == System.Net.HttpStatusCode.RequestTimeout)
                .WhenResult(response =>
                {
                    if (!response.ExistsBusinessResponseContent)
                    {
                        return false;//请求异常中止重试
                    }
                    if (!response.BusinessResponseContent.IsEffectiveOrder)
                    {
                        return false;//业务异常中止重试
                    }

                    if (!response.BusinessResponseContent.Order.IsFinalOrderStatus)
                    {
                        //未达最终态继续重试
                        Console.WriteLine("查询轮询" + response.BusinessResponseContent?.Order?.OrderStatus);
                        return true;
                    }
                    return false;//订单到达最终态中止重试
                }
                );
            }
            catch (TaskCanceledException)
            {
                //此处消除业务持续阻塞导致超时的异常使业务继续
            }
            catch (Exception)
            {
                throw;
            }

            if (result != null
                && result.ExistsBusinessResponseContent
                && result.BusinessResponseContent.IsEffectiveOrder
                && result.BusinessResponseContent.Order.IsFinalOrderStatus)
            {
                if (result.BusinessResponseContent.Order.OrderStatus == OrderStatusEnum.PAID)
                {
                    //符合此条件认为轮询到支付成功
                    return result.BusinessResponseContent.Order;
                }
                else
                {
                    //符合此条件认为轮询到支付失败
                    return result.BusinessResponseContent.Order;
                }
            }
            else
            {
                //类似查询任务,轮询查询无法得到成功结果时，需要调用撤单接口

                CancellationTokenSource cancelTaskCancelTokenSource = new CancellationTokenSource();
                //创建一个取消轮询的任务
                Task cancleTimeoutTask = Task.Delay(TimeSpan.FromSeconds(50)).ContinueWith(task => cancelTaskCancelTokenSource.Cancel());

                try
                {
                    result = await PayClient.Cancel( terminalSignSettings, orderTokenRequestModel, TimeSpan.FromSeconds(2), cancelTaskCancelTokenSource.Token)
                    .Retry(30, TimeSpan.FromSeconds(2))//设定轮询等待为2s，轮询不超过30次
                    .WhenCatch<HttpStatusFailureException>(ex => ex.StatusCode == System.Net.HttpStatusCode.RequestTimeout)
                    .WhenResult(response =>
                    {
                        if (!response.ExistsBusinessResponseContent)
                        {
                            return false;//请求异常中止重试
                        }
                        if (!response.BusinessResponseContent.IsEffectiveOrder)
                        {
                            return false;//业务异常中止重试
                        }

                        if (!response.BusinessResponseContent.Order.IsFinalOrderStatus)
                        {
                            //未达最终态继续重试
                            Console.WriteLine("撤销轮询" + response.BusinessResponseContent?.Order?.OrderStatus);
                            return true;
                        }
                        return false;//订单到达最终态中止重试
                    }
                    );
                }
                catch (TaskCanceledException)
                {
                    //此处消除异常使业务继续
                }
                catch (Exception)
                {
                    throw;
                }
                if (result != null
                && result.ExistsBusinessResponseContent
                && result.BusinessResponseContent.IsEffectiveOrder
                && result.BusinessResponseContent.Order.OrderStatus == OrderStatusEnum.PAY_CANCELED)
                {
                    //符合此条件认为轮询到撤销完成
                    return result.BusinessResponseContent.Order;
                }
                return result?.BusinessResponseContent?.Order;
            }
            //判断撤单结果
        }
    }
}
