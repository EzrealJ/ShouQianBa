using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Ezreal.ShouQianBa.ApiClient.ApiContract;
using Ezreal.ShouQianBa.ApiClient.ApiParameterModels.Request.Merchant;
using Ezreal.ShouQianBa.ApiClient.ApiParameterModels.Response;
using Ezreal.ShouQianBa.ApiClient.ApiParameterModels.Response.Merchant;
using Ezreal.ShouQianBa.ApiClient.Sign;
using Microsoft.AspNetCore.Mvc;


namespace AspNetCoreDemo.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(IMerchantContract merchantContract)
        {
            MerchantContract = merchantContract;
        }

        public IMerchantContract MerchantContract { get; }


        [HttpGet]
        public async Task<Response<PubBankResponseModel>> PubBankAsync(string bankName)
        {


            PubBankRequestModel requestModel = new PubBankRequestModel() { BankName = bankName };
            var sign = ServiceProviderSignProvider.CreateFromServiceProviderSettings().Sign(requestModel);

            Response<PubBankResponseModel> result = await MerchantContract.PubBank(sign, requestModel);

            return result;
        }
    }
}
