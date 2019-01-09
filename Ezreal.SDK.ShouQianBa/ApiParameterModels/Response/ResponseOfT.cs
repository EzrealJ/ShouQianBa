using Ezreal.SDK.ShouQianBa.Attributes;
using Ezreal.SDK.ShouQianBa.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ezreal.SDK.ShouQianBa.ApiParameterModels.Response
{
    public class Response<T> : ResponseModel where T : IBusinessResponseModel
    {

        /// <summary>
        /// 业务返回内容
        /// </summary>

        [ApiParameterName("biz_response")]
        public T BusinessResponseContent { get; set; }

    }
}
