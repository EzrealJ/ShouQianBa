using Ezreal.ShouQianBa.ApiClient.Attributes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Ezreal.ShouQianBa.ApiClient.ApiParameterModels.Request.Merchant
{
    /// <summary>
    /// 图片上传接口请求模型
    /// <para>
    ///https://doc.shouqianba.com/zh-cn/api/interface/merchantUpload.html
    /// </para>
    /// </summary>
    public class ImageUploadRequestModel : RequestModel, Sign.IServiceSignable
    {
        /// <summary>
        /// *图片Base64编码
        /// </summary>
        [ApiParameterName("file")]
        public string ImageBase64String { get; set; }
        /// <summary>
        /// 从<see cref="Image"/>实例创建<see cref="ImageUploadRequestModel"/>
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        public static ImageUploadRequestModel FromImage(Image image)
        {
            using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
            {
                image.Save(memoryStream, image.RawFormat);
                byte[] bytes = memoryStream.GetBuffer();
                string base64string = Convert.ToBase64String(bytes);
                return new ImageUploadRequestModel() { ImageBase64String = base64string };
            }
        }
    }
}
