using Ezreal.SDK.ShouQianBa.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ezreal.SDK.ShouQianBa.ApiParameterModels.Response.Merchant
{
    public class MerchantCreateResponseModel : IBusinessResponseModel
    {

        [ApiParameterName("result_code")]
        public string ResultCode { get; set; }
        [ApiParameterName("data")]
        public CreateMerchantResponseData Data { get; set; }

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
