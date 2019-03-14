using Ezreal.ShouQianBa.ApiClient.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ezreal.ShouQianBa.ApiClient.ApiParameterModels.Request.Merchant
{
    /// <summary>
    /// 开户银行接口请求模型
    /// <para>
    ///https://doc.shouqianba.com/zh-cn/api/interface/merchantBanks.html
    /// </para>
    /// </summary>
    public class BankRequestModel : RequestModel, Sign.IServiceSignable
    {
        /// <summary>
        /// *银行卡号
        /// </summary>
        [ApiParameterName("bank_card")]
        public string BankCard { get; set; }
    }
}
