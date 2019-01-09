using Ezreal.SDK.ShouQianBa.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ezreal.SDK.ShouQianBa.ApiParameterModels.Response.Merchant
{
    public class PubBankResponseModel: IBusinessResponseModel
    {

        [ApiParameterName("result_code")]
        public string ResultCode { get; set; }
        [ApiParameterName("data")]
        public List<string> BankBranchesList { get; set; }

    }
}
