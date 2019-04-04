using Ezreal.ShouQianBa.ApiClient.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ezreal.ShouQianBa.ApiClient.ApiParameterModels.Response.Merchant
{
    /// <summary>
    /// 商户禁用接口响应模型
    /// </summary>
    public class MerchantCloseResponseModel : IBusinessResponseModel
    {
        /// <summary>
        /// 状态码
        /// </summary>
        [ApiParameterName("result_code")]
        public string ResultCode { get; set; }


    }
}
