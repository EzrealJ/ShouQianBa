using Ezreal.ShouQianBa.ApiClient.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ezreal.ShouQianBa.ApiClient.ApiParameterModels.Response.Merchant
{
    /// <summary>
    /// 图片上传接口响应模型
    /// </summary>
    public class ImageUploadResponseModel: IBusinessResponseModel
    {
        /// <summary>
        /// 状态码
        /// </summary>
        [ApiParameterName("result_code")]
        public string ResultCode { get; set; }
        /// <summary>
        /// 文件URI
        /// </summary>
        [ApiParameterName("data")]
        public string FileURI { get; set; }

    }
}
