using Ezreal.ShouQianBa.ApiClient.Attributes;
using Ezreal.ShouQianBa.ApiClient.Converters;
using Ezreal.ShouQianBa.ApiClient.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ezreal.ShouQianBa.ApiClient.ApiModels.Generic
{
    /// <summary>
    /// 收钱吧订单模型
    /// </summary>
    public class ShouQianBaOrder
    {
        /// <summary>
        /// 收钱吧终端ID
        /// </summary>
        [ApiParameterName("terminal_sn")]
        public string TerminalSerialNo { get; set; }

        /// <summary>
        ///收钱吧订单号
        /// </summary>

        [ApiParameterName("sn")]
        public string SerialNo { get; set; }
        /// <summary>
        ///调用方订单号
        /// </summary>

        [ApiParameterName("client_sn")]
        public string ClientSerialNo { get; set; }

        /// <summary>
        ///支付提供商订单号
        /// </summary>

        [ApiParameterName("trade_no")]
        public string PayProviderTradeSerialNo { get; set; }
        /// <summary>
        /// 流水状态
        /// </summary>
        [ApiParameterName("status")]
        public string Status { get; set; }

        /// <summary>
        /// 订单状态
        /// </summary>
        [ApiParameterName("order_status")]
        [JsonConverter(typeof(StringEnumConverter))]
        public OrderStatusEnum OrderStatus { get; set; }


        /// <summary>
        /// 支付方式
        /// </summary>
        [ApiParameterName("payway")]
        [JsonConverter(typeof(EnumValueStringConverter))]
        public PaywayEnum Payway { get; set; }

        /// <summary>
        /// 支付方式名称
        /// </summary>
        [ApiParameterName("payway_name")]
        public string PaywayName { get; set; }

        /// <summary>
        /// 二级支付方式
        /// </summary>
        [ApiParameterName("sub_payway")]
        [JsonConverter(typeof(EnumValueStringConverter))]
        public SubPaywayEnum SubPayway { get; set; }

        /// <summary>
        /// 付款人在支付提供商平台上的ID
        /// </summary>

        [ApiParameterName("payer_uid")]
        public string PayerUserID { get; set; }

        /// <summary>
        /// 付款人在支付提供商平台上的账号
        /// </summary>

        [ApiParameterName("payer_login")]
        public string PayerAccount { get; set; }

        /// <summary>
        /// 总金额,以分计
        /// </summary>

        [ApiParameterName("total_amount")]
        [JsonConverter(typeof(CentStringConverter))]
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// 实收金额,以分计
        /// </summary>

        [ApiParameterName("net_amount")]
        [JsonConverter(typeof(CentStringConverter))]
        public decimal RealAmount { get; set; }

        /// <summary>
        /// 交易摘要
        /// </summary>
        [ApiParameterName("subject")]
        public string Summary { get; set; }



        /// <summary>
        /// 付款动作在收钱吧的完成时间(时间戳)
        /// </summary>

        [ApiParameterName("finish_time")]
        [JsonConverter(typeof(MillisecondTimestampStringConverter))]
        public DateTime? FinishTime { get; set; }

        /// <summary>
        /// 付款动作在支付提供商的完成时间(时间戳)
        /// </summary>

        [ApiParameterName("channel_finish_time")]
        [JsonConverter(typeof(MillisecondTimestampStringConverter))]
        public DateTime? PayProviderFinishTime { get; set; }
        /// <summary>
        /// 操作员
        /// </summary>

        [ApiParameterName("operator")]
        public string Operator { get; set; }
        /// <summary>
        /// 任何希望原样返回的内容
        /// </summary>

        [ApiParameterName("reflect")]
        public string Tag { get; set; }

        /// <summary>
        /// 扩展信息
        /// <para>
        /// 收钱吧与特定第三方单独约定的参数集合,json格式，最多支持24个字段，每个字段key长度不超过64字节，value长度不超过256字节
        /// </para>
        /// </summary>
        [ApiParameterName("payment_list")]
        public dynamic PaymentList { get; set; }
        /// <summary>
        /// 订单最终态状态集
        /// <para>
        /// 定义符合订单最终态的状态集合,包含<see cref="OrderStatusEnum.PAID"/>、<see cref="OrderStatusEnum.PAID"/>、<see cref="OrderStatusEnum.PAY_CANCELED"/>、<see cref="OrderStatusEnum.PARTIAL_REFUNDED"/>、<see cref="OrderStatusEnum.CANCELED"/>
        /// </para>
        /// </summary>
        public static readonly OrderStatusEnum[] OrderFinalStatus = new OrderStatusEnum[] {
           OrderStatusEnum.PAID,
           OrderStatusEnum.PAY_CANCELED,
           OrderStatusEnum.REFUNDED,
           OrderStatusEnum.PARTIAL_REFUNDED,
           OrderStatusEnum.CANCELED
        };
        /// <summary>
        /// 订单是否最终态
        /// <para>
        /// 判断OrderStatus是否是<see cref="OrderFinalStatus"/>中包含的项
        /// </para>
        /// <para>
        /// 文档约定,若订单不是最终状态,需要继续查询订单状态或者调用撤单操作
        /// </para>
        /// </summary>
        public bool IsFinalOrderStatus { get => OrderFinalStatus.Contains(this.OrderStatus); }
    }
}
