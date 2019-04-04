using Ezreal.ShouQianBa.ApiClient.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ezreal.ShouQianBa.ApiClient.ApiParameterModels.Response.Merchant
{
    /// <summary>
    /// 对公银行搜索接口响应模型
    /// </summary>
    public class PubBankResponseModel: IBusinessResponseModel
    {
        /// <summary>
        /// 状态码
        /// </summary>
        [ApiParameterName("result_code")]
        public string ResultCode { get; set; }
        /// <summary>
        /// 对公银行列表
        /// </summary>
        [ApiParameterName("data")]
        public List<string> BankBranchesList { get; set; }

    }
}
