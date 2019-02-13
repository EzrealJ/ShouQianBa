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
        /// <summary>
        /// 订单已创建/支付中
        /// </summary>
        [Description("订单已创建/支付中")]
        CREATED,
        /// <summary>
        /// 订单支付成功
        /// </summary>
        [Description("订单支付成功")]
        PAID,
        /// <summary>
        /// 支付失败并且已经成功充正
        /// </summary>
        [Description("支付失败并且已经成功充正")]
        PAY_CANCELED,
        /// <summary>
        /// 支付失败，不确定是否已经成功充正, 请联系收钱吧客服确认是否支付成功
        /// </summary>
        [Description("支付失败，不确定是否已经成功充正, 请联系收钱吧客服确认是否支付成功")]
        PAY_ERROR,
        /// <summary>
        /// 已成功全额退款
        /// </summary>
        [Description("已成功全额退款")]
        REFUNDED,
        /// <summary>
        /// 已成功部分退款
        /// </summary>
        [Description("已成功部分退款")]
        PARTIAL_REFUNDED,
        /// <summary>
        /// 退款失败并且不确定第三方支付通道的最终退款状态
        /// </summary>
        [Description("退款失败并且不确定第三方支付通道的最终退款状态")]
        REFUND_ERROR,
        /// <summary>
        /// 客户端发起的撤单已成功
        /// </summary>
        [Description("客户端发起的撤单已成功")]
        CANCELED,
        /// <summary>
        /// 客户端发起的撤单失败并且不确定第三方支付通道的最终状态
        /// </summary>
        [Description("客户端发起的撤单失败并且不确定第三方支付通道的最终状态")]
        CANCEL_ERROR,
        /// <summary>
        /// 撤单进行中
        /// </summary>
        [Description("撤单进行中")]
        CANCEL_INPROGRESS,
        /// <summary>
        /// 无效的状态码
        /// </summary>
        [Description("无效的状态码")]
        INVALID_STATUS_CODE
    }
}
