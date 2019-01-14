using Ezreal.SDK.ShouQianBa.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ezreal.SDK.ShouQianBa.ApiParameterModels.Request.Merchant
{
    /// <summary>
    /// 商户信息接口请求模型
    /// <para>
    /// https://doc.shouqianba.com/zh-cn/api/interface/merchantInfo.html
    /// </para>
    /// </summary>
    public class MerchantInfoRequestModel : RequestModel
    {
        /// <summary>
        /// 服务商序列号
        /// </summary>
        [ApiParameterName("vendor_sn")]
        public string ServiceProviderSerialNo { get; set; }

        /// <summary>
        /// 商户号
        /// </summary>
        [ApiParameterName("merchant_sn")]
        public string MerchantSerialNo { get; set; }
    }
}
