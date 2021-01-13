using Ezreal.ShouQianBa.ApiClient.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ezreal.ShouQianBa.ApiClient.ApiModels.Response.Merchant
{
    /// <summary>
    /// 开户银行接口响应模型
    /// </summary>
    public class BankResponseModel :IBusinessResponseModel
    {
        /// <summary>
        /// 状态码
        /// </summary>
        [ApiParameterName("result_code")]
        public string ResultCode { get; set; }
        /// <summary>
        /// 开户银行名称
        /// </summary>
        [ApiParameterName("data")]
        public string BankName { get; set; }

    }
}
