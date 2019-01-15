using Ezreal.ShouQianBa.ApiClient.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ezreal.ShouQianBa.ApiClient.ApiParameterModels.Response.Pay
{
    public class OrderPrecreateSyncResponseModel : IBusinessResponseModel
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
        public PayPrecreateSyncResponseData Data { get; set; }

        public class PayPrecreateSyncResponseData : Generic.ShouQianBaOrder
        {
            /// <summary>
            /// 二维码内容
            /// </summary>

            [ApiParameterName("qr_code")]
            public string QRCode { get; set; }

            /// <summary>
            /// 支付通道返回的调用WAP支付需要传递的信息
            /// </summary>

            [ApiParameterName("wap_pay_request")]
            public string WapPayRequest { get; set; }

        }
    }
}
