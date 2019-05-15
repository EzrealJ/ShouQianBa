using Ezreal.ShouQianBa.ApiClient.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ezreal.ShouQianBa.ApiClient.ApiParameterModels.Request.Merchant
{
    /// <summary>
    /// 商户禁用接口请求模型
    /// <para>
    /// https://doc.shouqianba.com/zh-cn/api/interface/merchantClose.html
    /// </para>
    /// </summary>
    public class MerchantCloseRequestModel : RequestModel
    {
        /// <summary>
        /// *服务商序列号
        /// </summary>
        [ApiParameterName("vendor_sn")]
        public string ServiceProviderSerialNo { get; set; }

        /// <summary>
        /// *商户号
        /// </summary>
        [ApiParameterName("merchant_sn")]
        public string MerchantSerialNo { get; set; }
    }
}
