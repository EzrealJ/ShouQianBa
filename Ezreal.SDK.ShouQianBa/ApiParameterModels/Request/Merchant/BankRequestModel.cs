using Ezreal.SDK.ShouQianBa.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ezreal.SDK.ShouQianBa.ApiParameterModels.Request.Merchant
{
    /// <summary>
    /// 开户银行接口请求模型
    /// <para>
    ///
    /// </para>
    /// <seealso cref="https://doc.shouqianba.com/zh-cn/api/interface/merchantBanks.html"/>
    /// </summary>
    public class BankRequestModel : RequestModel
    {
        /// <summary>
        /// 银行卡号
        /// </summary>
        [ApiParameterName("bank_card")]
        public string BankCard { get; set; }
    }
}
