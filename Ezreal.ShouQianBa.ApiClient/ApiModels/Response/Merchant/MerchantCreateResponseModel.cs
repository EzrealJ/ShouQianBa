using Ezreal.ShouQianBa.ApiClient.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ezreal.ShouQianBa.ApiClient.ApiModels.Response.Merchant
{
    /// <summary>
    /// 商户创建接口响应模型
    /// </summary>
    public class MerchantCreateResponseModel : IBusinessResponseModel
    {
        /// <summary>
        /// 状态码
        /// </summary>
        [ApiParameterName("result_code")]
        public string ResultCode { get; set; }
        /// <summary>
        /// 商户概要信息
        /// </summary>
        [ApiParameterName("data")]
        public CreateMerchantResponseData Data { get; set; }
        /// <summary>
        /// 创建商户响应结果
        /// </summary>
        public class CreateMerchantResponseData
        {
            /// <summary>
            /// 商户编号
            /// </summary>
            [ApiParameterName("merchant_sn")]
            public string MerchantSerialNo { get; set; }
            /// <summary>
            /// 门店编号
            /// </summary>
            [ApiParameterName("store_sn")]
            public string StoreSerialNo { get; set; }
            /// <summary>
            /// 终端编号
            /// </summary>
            [ApiParameterName("terminal_sn")]
            public string TerminalSerialNo { get; set; }
            /// <summary>
            /// 终端Key
            /// </summary>
            [ApiParameterName("terminal_key")]
            public string TerminalKey { get; set; }
        }

    }
}
