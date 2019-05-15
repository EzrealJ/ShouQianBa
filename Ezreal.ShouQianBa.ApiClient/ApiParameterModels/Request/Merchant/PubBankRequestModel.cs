using Ezreal.ShouQianBa.ApiClient.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ezreal.ShouQianBa.ApiClient.ApiParameterModels.Request.Merchant
{
    /// <summary>
    /// 对公银行搜索接口请求模型
    /// <para>
    ///https://doc.shouqianba.com/zh-cn/api/interface/merchantPubBanks.html
    /// </para>
    /// </summary>
    public class PubBankRequestModel : RequestModel
    {
        /// <summary>
        /// *银行名称,支持模糊查询
        /// </summary>
        [ApiParameterName("bank_name")]
        public string BankName { get; set; }
    }
}
