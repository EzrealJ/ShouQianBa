using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ezreal.ShouQianBa.ApiClient.Api;
using Ezreal.ShouQianBa.ApiClient.ApiContract;

namespace Ezreal.ShouQianBa.ApiClient
{
    public class ApiFactory
    {
        public static MerchantClient CreateMerchantClient() => new MerchantClient(null);


    }
}
