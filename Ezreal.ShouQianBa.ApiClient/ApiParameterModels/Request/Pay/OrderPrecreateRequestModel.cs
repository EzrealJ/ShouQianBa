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
    public class OrderPrecreateRequestModel : RequestModel, Sign.ITerminalSignable
    {
        /// <summary>
        /// *收钱吧终端ID
        /// </summary>
        [ApiParameterName("terminal_sn")]
        public string TerminalSerialNo { get; set; }
        /// <summary>
        ///*调用方订单号
        /// </summary>

        [ApiParameterName("client_sn")]
        public string ClientSerialNo { get; set; }
        /// <summary>
        /// *总金额
        /// <para>以分为单位,不超过10位纯数字字符串,超过1亿元的收款请使用银行转账</para>
        /// <para>[***调用时请使用以元为单位的<see cref="decimal"/>值,将在发起请求时自动转换为以分计的值]</para>
        /// </summary>

        [ApiParameterName("total_amount")]
        [JsonConverter(typeof(CentStringConverter))]
        public decimal TotalAmount { get; set; }
        /// <summary>
        /// 支付方式，一旦设置，将限定为指定的支付方式
        /// </summary>
        [ApiParameterName("payway")]
        [JsonConverter(typeof(EnumValueStringConverter))]
        public Enums.PaywayEnum? Payway { get; set; }


        /// <summary>
        /// ?二级支付方式
        /// <para>
        /// 如果要使用WAP支付，则必须传 "3", 使用小程序支付请传"4"
        /// </para>
        /// </summary>
        [ApiParameterName("sub_payway")]
        [JsonConverter(typeof(EnumValueStringConverter))]
        public Enums.SubPaywayEnum? SubPayway { get; set; }

        /// <summary>
        /// 付款人在支付提供商平台上的ID
        /// <para>
        /// wap支付，小程序支付必传 ，微信WAP支付必须传open_id,支付宝WAP支付必传用户授权的userId
        /// </para>
        /// </summary>

        [ApiParameterName("payer_uid")]
        public string PayerUserID { get; set; }

        /// <summary>
        /// *交易摘要
        /// </summary>
        [ApiParameterName("subject")]
        public string Summary { get; set; }
        /// <summary>
        /// *操作员
        /// </summary>

        [ApiParameterName("operator")]
        public string Operator { get; set; }
        /// <summary>
        /// 详细描述
        /// </summary>

        [ApiParameterName("description")]
        public string Description { get; set; }

        /// <summary>
        /// 经度
        /// <para>若设置则必须设置纬度</para>
        /// </summary>
        [ApiParameterName("longitude")]
        public string Longitude { get; set; }

        /// <summary>
        /// 纬度<para>若设置则必须设置经度</para>
        /// </summary>
        [ApiParameterName("latitude")]
        public string Latitude { get; set; }


        /// <summary>
        /// 扩展信息
        /// <para>
        /// 收钱吧与特定第三方单独约定的参数集合,json格式，最多支持24个字段，每个字段key长度不超过64字节，value长度不超过256字节
        /// </para>
        /// <para>直接设置对象即可，发起请求时会序列化</para>
        /// </summary>
        [ApiParameterName("extended")]
        public dynamic Extra { get; set; }
        /// <summary>
        /// 商品详情
        /// </summary>
        [ApiParameterName("goods_details")]
        public List<GoodsDetail> GoodsDetails { get; set; }
        /// <summary>
        /// 任何希望原样返回的内容
        /// </summary>

        [ApiParameterName("reflect")]
        public string Tag { get; set; }
        /// <summary>
        /// 异步回调地址
        /// </summary>

        [ApiParameterName("notify_url")]
        public string NotifyUrl { get; set; }
    }
}
