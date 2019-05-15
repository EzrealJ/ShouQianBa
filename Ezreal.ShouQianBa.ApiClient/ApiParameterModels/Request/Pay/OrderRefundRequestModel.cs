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
    public class OrderRefundRequestModel : RequestModel
    {
        /// <summary>
        /// *收钱吧终端ID
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
        ///商户退款流水号
        /// </summary>

        [ApiParameterName("client_tsn")]
        public string ClientRefundSerialNo { get; set; }

        /// <summary>
        ///*退款请求唯一编号
        ///<para>
        ///正常情况下，对同一笔订单进行多次退款请求时该字段不能重复；重试同一请求请保持不变
        /// </para>
        /// </summary>

        [ApiParameterName("refund_request_no")]
        public string RefundRequestNo { get; set; }
        /// <summary>
        /// *退款金额
        /// <para>以分为单位,不超过10位纯数字字符串,超过1亿元的收款请使用银行转账</para>
        /// <para>[***调用时请使用以元为单位的<see cref="decimal"/>值,将在发起请求时自动转换为以分计的值]</para>
        /// </summary>

        [ApiParameterName("refund_amount")]
        [JsonConverter(typeof(CentStringConverter))]
        public decimal RefundAmount { get; set; }


        /// <summary>
        /// *操作员
        /// </summary>

        [ApiParameterName("operator")]
        public string Operator { get; set; }


        /// <summary>
        /// 扩展信息
        /// <para>
        /// 收钱吧与特定第三方单独约定的参数集合,json格式，最多支持24个字段，每个字段key长度不超过64字节，value长度不超过256字节
        /// </para>
        /// <para>只需要设置对象即可,发起请求时会进行序列化</para>
        /// </summary>
        [ApiParameterName("extended")]
        public dynamic Extra { get; set; }
        /// <summary>
        /// 商品详情
        /// </summary>
        [ApiParameterName("goods_details")]
        public List<GoodsDetail> GoodsDetails { get; set; }

    }
}
