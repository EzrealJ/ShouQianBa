using Ezreal.ShouQianBa.ApiClient.Attributes;

namespace Ezreal.ShouQianBa.ApiClient.ApiParameterModels.Response.Merchant
{
    public class MerchantInfoResponseModel : IBusinessResponseModel
    {
        [ApiParameterName("result_code")]
        public string ResultCode { get; set; }

        [ApiParameterName("data")]
        public CreateMerchantResponseData Data { get; set; }

        public class CreateMerchantResponseData 
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

            [ApiParameterName("merchant_name")]
            public string Name { get; set; }


            [ApiParameterName("contact_name")]
            public string ContactPerson { get; set; }

            [ApiParameterName("contact_cellphone")]
            public string ContactCellphone { get; set; }

            [ApiParameterName("area")]
            public string Area { get; set; }
            [ApiParameterName("street_address")]
            public string Address { get; set; }

            [ApiParameterName("bank_card")]
            public string BankCard { get; set; }
            [ApiParameterName("bank_name")]
            public string BankName { get; set; }
            [ApiParameterName("bank_area")]
            public string BankArea { get; set; }
            [ApiParameterName("branch_name")]
            public string BranchName { get; set; }
            [ApiParameterName("bank_cellphone")]
            public string BankCellphone { get; set; }
            [ApiParameterName("holder")]
            public string Holder { get; set; }

            [ApiParameterName("unified_status")]
            public string UnifiedStatus { get; set; }

            [ApiParameterName("error_message")]
            public string ErrorMessage { get; set; }
        }
    }
}