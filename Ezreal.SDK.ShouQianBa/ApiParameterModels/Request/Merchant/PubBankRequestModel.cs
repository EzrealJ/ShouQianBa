using Ezreal.SDK.ShouQianBa.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ezreal.SDK.ShouQianBa.ApiParameterModels.Request.Merchant
{
    /// <summary>
    /// 对公银行搜索接口请求模型
    /// <para>
    ///
    /// </para>
    /// <seealso cref="https://doc.shouqianba.com/zh-cn/api/interface/merchantPubBanks.html"/>
    /// </summary>
    public class PubBankRequestModel : RequestModel
    {
        /// <summary>
        /// 银行名称,支持模糊查询
        /// </summary>
        [ApiParameterName("bank_name")]
        public string BankName { get; set; }
    }
}
