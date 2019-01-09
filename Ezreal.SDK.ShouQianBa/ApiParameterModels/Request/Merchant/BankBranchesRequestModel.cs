using Ezreal.SDK.ShouQianBa.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ezreal.SDK.ShouQianBa.ApiParameterModels.Request.Merchant
{
    /// <summary>
    /// 银行支行接口请求模型
    /// <para>
    ///
    /// </para>
    /// <seealso cref="https://doc.shouqianba.com/zh-cn/api/interface/merchantBranches.html"/>
    /// </summary>
    public class BankBranchesRequestModel : RequestModel
    {
        /// <summary>
        /// 银行名称
        /// </summary>
        [ApiParameterName("bank_name")]
        public string BankName { get; set; }

        /// <summary>
        /// 银行所在地区编码
        /// </summary>
        [ApiParameterName("bank_area")]
        public string BankArea { get; set; }
    }
}
