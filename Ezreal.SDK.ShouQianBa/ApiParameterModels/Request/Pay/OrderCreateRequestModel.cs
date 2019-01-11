using Ezreal.SDK.ShouQianBa.Attributes;
using Ezreal.SDK.ShouQianBa.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ezreal.SDK.ShouQianBa.ApiParameterModels.Request.Pay
{
    public class OrderCreateRequestModel : RequestModel
    {
        /// <summary>
        /// 【必须】收钱吧终端ID
        /// </summary>
        [ApiParameterName("terminal_sn")]
        public string TerminalSerialNo { get; set; }
        /// <summary>
        ///【必须】调用方订单号
        /// </summary>

        [ApiParameterName("client_sn")]
        public string ClientSerialNo { get; set; }
        /// <summary>
        /// 【必须】总金额,以分计
        /// </summary>

        [ApiParameterName("total_amount")]
        [JsonConverter(typeof(CentStringConverter))]
        public decimal TotalAmount { get; set; }
        /// <summary>
        /// 【非必须】支付方式，一旦设置，将限定为指定的支付方式
        /// </summary>
        [ApiParameterName("payway")]
        [JsonConverter(typeof(EnumValueStringConverter))]
        public Enums.PaywayEnum? Payway { get; set; }
        /// <summary>
        /// 【必须】支付凭证,条码支付场景下为条码内容
        /// </summary>

        [ApiParameterName("dynamic_id")]
        public string PayCertificate { get; set; }

        /// <summary>
        /// 【必须】交易摘要
        /// </summary>
        [ApiParameterName("subject")]
        public string Summary { get; set; }
        /// <summary>
        /// 【必须】操作员
        /// </summary>

        [ApiParameterName("operator")]
        public string Operator { get; set; }
        /// <summary>
        /// 【非必须】详细描述
        /// </summary>

        [ApiParameterName("description")]
        public string Description { get; set; }

        /// <summary>
        /// 【非必须】经度，若设置则必须设置纬度
        /// </summary>
        [ApiParameterName("longitude")]
        public string Longitude { get; set; }

        /// <summary>
        /// 【非必须】纬度，若设置则必须设置经度
        /// </summary>
        [ApiParameterName("latitude")]
        public string Latitude { get; set; }
        /// <summary>
        /// 【非必须】设备唯一识别码
        /// </summary>

        [ApiParameterName("device_id")]
        public string DeviceID { get; set; }

        /// <summary>
        /// 扩展信息
        /// <para>
        /// 收钱吧与特定第三方单独约定的参数集合,json格式，最多支持24个字段，每个字段key长度不超过64字节，value长度不超过256字节
        /// </para>
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
