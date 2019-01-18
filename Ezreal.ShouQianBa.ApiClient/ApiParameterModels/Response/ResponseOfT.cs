using Ezreal.ShouQianBa.ApiClient.Attributes;
using Ezreal.ShouQianBa.ApiClient.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ezreal.ShouQianBa.ApiClient.ApiParameterModels.Response
{
    public class Response<T> : ResponseModel where T : IBusinessResponseModel
    {

        /// <summary>
        /// 业务返回内容
        /// </summary>

        [ApiParameterName("biz_response")]
        public T BusinessResponseContent { get; set; }
        /// <summary>
        /// 存在有效的业务响应
        /// </summary>
        public bool ExistsBusinessResponseContent { get => this.BusinessResponseContent.Equals(default(T)); }

    }
}
