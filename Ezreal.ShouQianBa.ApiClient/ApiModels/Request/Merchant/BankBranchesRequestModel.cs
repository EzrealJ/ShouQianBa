using Ezreal.ShouQianBa.ApiClient.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ezreal.ShouQianBa.ApiClient.ApiModels.Request.Merchant
{
    /// <summary>
    /// 银行支行接口请求模型
    /// <para>
    ///https://doc.shouqianba.com/zh-cn/api/interface/merchantBranches.html
    /// </para>
    /// </summary>
    public class BankBranchesRequestModel : RequestModel
    {
        /// <summary>
        /// *银行名称
        /// </summary>
        [ApiParameterName("bank_name")]
        public string BankName { get; set; }

        /// <summary>
        /// *银行所在地区编码
        /// </summary>
        [ApiParameterName("bank_area")]
        public string BankArea { get; set; }
    }
}
