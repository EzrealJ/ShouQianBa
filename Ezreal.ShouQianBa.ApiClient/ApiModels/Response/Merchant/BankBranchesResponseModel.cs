using Ezreal.ShouQianBa.ApiClient.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ezreal.ShouQianBa.ApiClient.ApiModels.Response.Merchant
{
    /// <summary>
    /// 银行支行接口响应模型
    /// </summary>
    public class BankBranchesResponseModel:IBusinessResponseModel
    {
        /// <summary>
        /// 状态码
        /// </summary>
        [ApiParameterName("result_code")]
        public string ResultCode { get; set; }
        /// <summary>
        /// 银行列表
        /// </summary>
        [ApiParameterName("data")]
        public List<string> BankBranchesList { get; set; }

    }
}
