using Ezreal.ShouQianBa.ApiClient.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ezreal.ShouQianBa.ApiClient.ApiParameterModels.Response.Merchant
{
    public class ImageUploadResponseModel: IBusinessResponseModel
    {

        [ApiParameterName("result_code")]
        public string ResultCode { get; set; }
        [ApiParameterName("data")]
        public string FileURI { get; set; }

    }
}
