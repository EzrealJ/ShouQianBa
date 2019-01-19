using Ezreal.ShouQianBa.ApiClient.ApiParameterModels.Request.Merchant;
using Ezreal.ShouQianBa.ApiClient.ApiParameterModels.Response;
using Ezreal.ShouQianBa.ApiClient.ApiParameterModels.Response.Merchant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiClient;

namespace AspNetCoreDemo.Controllers
{
    public class Home1Controller
    {
        public Home1Controller(Ezreal.ShouQianBa.ApiClient.Api.MerchantClient merchantClient)
        {
            MerchantClient = merchantClient;
        }

        public Ezreal.ShouQianBa.ApiClient.Api.MerchantClient MerchantClient { get; }
        public async Task<Response<BankResponseModel>> BanksAsync(string bankCardNo)
        {
            BankRequestModel requestModel = new BankRequestModel() { BankCard = bankCardNo };
            Response<BankResponseModel> result = await MerchantClient
                .Banks(requestModel)
                .Retry(3, TimeSpan.FromSeconds(5))
                .WhenCatch<HttpStatusFailureException>(ex => ex.StatusCode == System.Net.HttpStatusCode.RequestTimeout);
            return result;
        }
    }
}
