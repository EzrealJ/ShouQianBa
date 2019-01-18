using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ezreal.ShouQianBa.ApiClient.Enums
{
    public enum OrderStatusEnum
    {
        [Description("订单已创建/支付中")]
        CREATED,
        [Description("订单支付成功")]
        PAID,
        [Description("支付失败并且已经成功充正")]
        PAY_CANCELED,
        [Description("支付失败，不确定是否已经成功充正, 请联系收钱吧客服确认是否支付成功")]
        PAY_ERROR,
        [Description("已成功全额退款")]
        REFUNDED,
        [Description("已成功部分退款")]
        PARTIAL_REFUNDED,
        [Description("退款失败并且不确定第三方支付通道的最终退款状态")]
        REFUND_ERROR,
        [Description("客户端发起的撤单已成功")]
        CANCELED,
        [Description("客户端发起的撤单失败并且不确定第三方支付通道的最终状态")]
        CANCEL_ERROR,
        [Description("撤单进行中")]
        CANCEL_INPROGRESS,
        [Description("无效的状态码")]
        INVALID_STATUS_CODE
    }
}
