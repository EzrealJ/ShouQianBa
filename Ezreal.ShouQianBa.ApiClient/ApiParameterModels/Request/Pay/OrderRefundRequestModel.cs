using Ezreal.ShouQianBa.ApiClient.Attributes;
using Ezreal.ShouQianBa.ApiClient.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ezreal.ShouQianBa.ApiClient.ApiParameterModels.Request.Pay
{
    /// <summary>
    /// 退款请求模型
    /// </summary>
    public class OrderRefundRequestModel : RequestModel, Sign.ITerminalSignable
    {
        /// <summary>
        /// 【必须】收钱吧终端ID
        /// </summary>
        [ApiParameterName("terminal_sn")]
        public string TerminalSerialNo { get; set; }

        /// <summary>
        ///【可选必须】收钱吧订单号
        /// </summary>

        [ApiParameterName("sn")]
        public string SerialNo { get; set; }
        /// <summary>
        ///【可选必须】调用方订单号
        /// </summary>

        [ApiParameterName("client_sn")]
        public string ClientSerialNo { get; set; }

        /// <summary>
        ///【非必须】商户退款流水号
        /// </summary>

        [ApiParameterName("client_tsn")]
        public string ClientRefundSerialNo { get; set; }

        /// <summary>
        ///【必须】退款请求唯一编号
        ///<para>
        ///正常情况下，对同一笔订单进行多次退款请求时该字段不能重复；重试同一请求请保持不变
        /// </para>
        /// </summary>

        [ApiParameterName("refund_request_no")]
        public string RefundRequestNo { get; set; }
        /// <summary>
        /// 【必须】退款金额,以分计
        /// </summary>

        [ApiParameterName("refund_amount")]
        [JsonConverter(typeof(CentStringConverter))]
        public decimal RefundAmount { get; set; }


        /// <summary>
        /// 【必须】操作员
        /// </summary>

        [ApiParameterName("operator")]
        public string Operator { get; set; }


        /// <summary>
        /// 【非必需】扩展信息
        /// <para>
        /// 收钱吧与特定第三方单独约定的参数集合,json格式，最多支持24个字段，每个字段key长度不超过64字节，value长度不超过256字节
        /// </para>
        /// </summary>
        [ApiParameterName("extended")]
        public dynamic Extra { get; set; }
        /// <summary>
        /// 【非必需】商品详情
        /// </summary>
        [ApiParameterName("goods_details")]
        public List<GoodsDetail> GoodsDetails { get; set; }

    }
}
