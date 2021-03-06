﻿using Ezreal.ShouQianBa.ApiClient.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ezreal.ShouQianBa.ApiClient.ApiModels.Response.Pay
{
    /// <summary>
    /// 预创建订单同步响应结果
    /// </summary>
    public class OrderPrecreateSyncResponseModel : IBusinessResponseModel
    {
        /// <summary>
        /// 状态码
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
        /// <summary>
        /// 订单预创建信息
        /// </summary>
        [ApiParameterName("data")]
        public PayPrecreateSyncResponseData Data { get; set; }
        /// <summary>
        /// 预创建订单同步响应内容模型
        /// </summary>
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
