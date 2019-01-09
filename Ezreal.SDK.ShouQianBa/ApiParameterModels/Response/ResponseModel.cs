using Ezreal.SDK.ShouQianBa.Attributes;
using Ezreal.SDK.ShouQianBa.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ezreal.SDK.ShouQianBa.ApiParameterModels.Response
{
    public class ResponseModel : ApiParameterModelBase
    {
        /// <summary>
        /// 响应码
        /// </summary>
        [ApiParameterName("result_code")]
        public ResponseResultCodeEnum ResultCode { get; set; }
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
    }
}
