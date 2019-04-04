using Ezreal.ShouQianBa.ApiClient.Attributes;
using Ezreal.ShouQianBa.ApiClient.Converters;
using Ezreal.ShouQianBa.ApiClient.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ezreal.ShouQianBa.ApiClient.ApiParameterModels.Response
{
    /// <summary>
    /// 响应模型
    /// </summary>
    public class ResponseModel : ApiParameterModelBase
    {
        /// <summary>
        /// 响应码
        /// </summary>
        [ApiParameterName("result_code")]
        [JsonConverter(typeof(EnumValueStringConverter))]
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
