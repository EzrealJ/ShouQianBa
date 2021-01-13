using Ezreal.ShouQianBa.ApiClient.Attributes;

namespace Ezreal.ShouQianBa.ApiClient.ApiModels.Response.Merchant
{
    /// <summary>
    /// 商户信息接口响应模型
    /// </summary>
    public class MerchantInfoResponseModel : IBusinessResponseModel
    {
        /// <summary>
        /// 状态码
        /// </summary>
        [ApiParameterName("result_code")]
        public string ResultCode { get; set; }
        /// <summary>
        /// 商户信息
        /// </summary>
        [ApiParameterName("data")]
        public MerchantInfoResponseData Data { get; set; }
        /// <summary>
        /// 商户信息响应结果
        /// </summary>
        public class MerchantInfoResponseData
        {
            /// <summary>
            /// 商户号
            /// </summary>
            [ApiParameterName("merchant_sn")]
            public string MerchantSerialNo { get; set; }

            /// <summary>
            /// 外部商户号
            /// </summary>
            [ApiParameterName("client_sn")]
            private string ClientSerialNo { get; set; }
            /// <summary>
            /// 商户名
            /// </summary>
            [ApiParameterName("merchant_name")]
            public string Name { get; set; }

            /// <summary>
            /// 联系人
            /// </summary>
            [ApiParameterName("contact_name")]
            public string ContactPerson { get; set; }
            /// <summary>
            /// 联系电话
            /// </summary>
            [ApiParameterName("contact_cellphone")]
            public string ContactCellphone { get; set; }
            /// <summary>
            /// 邮编
            /// </summary>
            [ApiParameterName("area")]
            public string Area { get; set; }
            /// <summary>
            /// 地址
            /// </summary>
            [ApiParameterName("street_address")]
            public string Address { get; set; }
            /// <summary>
            /// 银行卡号
            /// </summary>

            [ApiParameterName("bank_card")]
            public string BankCard { get; set; }
            /// <summary>
            /// 开户行
            /// </summary>
            [ApiParameterName("bank_name")]
            public string BankName { get; set; }
            /// <summary>
            /// 开户行邮编
            /// </summary>
            [ApiParameterName("bank_area")]
            public string BankArea { get; set; }
            /// <summary>
            /// 开户支行
            /// </summary>
            [ApiParameterName("branch_name")]
            public string BranchName { get; set; }
            /// <summary>
            /// 预留电话
            /// </summary>
            [ApiParameterName("bank_cellphone")]
            public string BankCellphone { get; set; }
            /// <summary>
            /// 法人
            /// </summary>
            [ApiParameterName("holder")]
            public string Holder { get; set; }
            /// <summary>
            /// 统一状态
            /// </summary>

            [ApiParameterName("unified_status")]
            public string UnifiedStatus { get; set; }
            /// <summary>
            /// 错误信息
            /// </summary>

            [ApiParameterName("error_message")]
            public string ErrorMessage { get; set; }
        }
    }
}