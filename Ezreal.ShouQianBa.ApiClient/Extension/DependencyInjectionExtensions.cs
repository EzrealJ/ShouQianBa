#if NETSTANDARD2_0
using Ezreal.ShouQianBa.ApiClient.ApiContract;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiClient;
using WebApiClient.Attributes;
using WebApiClient.Extensions.DependencyInjection;

namespace Ezreal.ShouQianBa.ApiClient.Extension
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddShouqianbaApiClient(this IServiceCollection services, Action<HttpApiConfig, IServiceProvider> configOptionsSetter = null)
        {
            services.TryAddSingleton<ShouQianBaGlobalConfig>();
            void x(HttpApiConfig c, IServiceProvider sp)
            {
                configOptionsSetter?.Invoke(c, sp);
                c.GlobalFilters.Add(new Filter.SignFilter());
                c.FormatOptions.DateTimeFormat = DateTimeFormats.ISO8601_WithMillisecond;
                ShouQianBaGlobalConfig shouQianBaGlobalConfig = sp?.GetService<ShouQianBaGlobalConfig>();
                if (shouQianBaGlobalConfig != null)
                {
                    c.HttpHost = shouQianBaGlobalConfig.UseSandbox ? new Uri(shouQianBaGlobalConfig.SandboxEnvironmentApiUri) : new Uri(shouQianBaGlobalConfig.ProductionEnvironmentApiUri);
                    if (shouQianBaGlobalConfig.UseLog)
                    {
                        c.GlobalFilters.Add(new TraceFilterAttribute());
                    }
                    shouQianBaGlobalConfig.ApiActionFilters.ToList().ForEach(filter => c.GlobalFilters.Add(filter));
                }
                c.HttpHost = c.HttpHost ?? new Uri("https://vsi-api.shouqianba.com");
                c.FormatOptions.IgnoreNullProperty = true;


            }
            services.AddHttpApi<ITerminalContract>().ConfigureHttpApiConfig(x);
            services.AddHttpApi<IPayContract>().ConfigureHttpApiConfig(x);
            return services;
        }
    }
}

#endif