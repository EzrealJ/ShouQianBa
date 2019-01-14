using Ezreal.SDK.ShouQianBa.Attributes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Ezreal.SDK.ShouQianBa.ApiParameterModels.Request.Merchant
{
    /// <summary>
    /// 开户银行接口请求模型
    /// <para>
    ///https://doc.shouqianba.com/zh-cn/api/interface/merchantUpload.html
    /// </para>
    /// </summary>
    public class ImageUploadRequestModel : RequestModel
    {
        /// <summary>
        /// 图片Base64编码
        /// </summary>
        [ApiParameterName("file")]
        public string ImageBase64String { get; set; }
        /// <summary>
        /// 从<see cref="Image"/>实例创建
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
