using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using WebApiClient;

namespace Ezreal.SDK.ShouQianBa
{
    public class Global
    {
        public static GlobalConfig GlobalConfig { get; set; } = new GlobalConfig();
        public static void AddDefaultConfig(Action<GlobalConfig> action)
        {
            action.Invoke(GlobalConfig);
            HttpApiFactory.Add<ApiContract.IMerchantContract>().ConfigureHttpApiConfig(c =>
           {
               c.HttpHost = new Uri(GlobalConfig.ApiUri);
               GlobalConfig.ApiActionFilters.ToList().ForEach(filter => c.GlobalFilters.Add(filter));
               c.FormatOptions.DateTimeFormat = WebApiClient.DateTimeFormats.ISO8601_WithMillisecond;

           });
            HttpApiFactory.Add<ApiContract.ITerminalContract>().ConfigureHttpApiConfig(c =>
            {
                c.HttpHost = new Uri(GlobalConfig.ApiUri);
                GlobalConfig.ApiActionFilters.ToList().ForEach(filter => c.GlobalFilters.Add(filter));
                c.FormatOptions.DateTimeFormat = WebApiClient.DateTimeFormats.ISO8601_WithMillisecond;

            });
            HttpApiFactory.Add<ApiContract.IPayContract>().ConfigureHttpApiConfig(c =>
            {
                c.HttpHost = new Uri(GlobalConfig.ApiUri);
                GlobalConfig.ApiActionFilters.ToList().ForEach(filter => c.GlobalFilters.Add(filter));
                c.FormatOptions.DateTimeFormat = WebApiClient.DateTimeFormats.ISO8601_WithMillisecond;

            });

        }

        public static TInterface Create<TInterface>() where TInterface : class, IHttpApi
        {
            return HttpApiFactory.Create<TInterface>();
        }
    }
}
