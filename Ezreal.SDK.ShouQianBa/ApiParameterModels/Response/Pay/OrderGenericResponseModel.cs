using Ezreal.SDK.ShouQianBa.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ezreal.SDK.ShouQianBa.ApiParameterModels.Response.Pay
{
    public class OrderGenericResponseModel : IBusinessResponseModel
    {
        /// <summary>
        /// 响应码
        /// </summary>
        [ApiParameterName("result_code")]
        public string ResultCode { get; set; }
        /// <summary>
        /// 错误码
        /// </summary>

        [ApiParameterName("error_code")]
        public string ErrorCode { get; set; }
        /// <summary>
        /// 错误信息
        /// </summary>

        [ApiParameterName("error_message")]
        public string ErrorMessage { get; set; }

        [ApiParameterName("data")]
        public Generic.ShouQianBaOrder Order { get; set; }
    }
}
