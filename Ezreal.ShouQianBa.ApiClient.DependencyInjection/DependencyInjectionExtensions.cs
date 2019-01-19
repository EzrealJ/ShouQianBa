using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebApiClient;

namespace Ezreal.ShouQianBa.ApiClient.DependencyInjection
{
    public static class DependencyInjectionExtensions
    {
        /// <summary>
        /// 添加HttpApi
        /// 返回HttpApi工厂
        /// </summary>
        /// <typeparam name="TInterface">接口类型</typeparam>
        /// <param name="services"></param>
        /// <returns></returns>
        public static void AddShouQianBaApiClient(this IServiceCollection services, Action<GlobalConfig> action)

        {
            services.AddSingleton(Global.GlobalConfig);
            action.Invoke(Global.GlobalConfig);
            Action<HttpApiConfig> configAction = config =>
            {
                config.HttpHost = new Uri(Global.GlobalConfig.ApiUri);
                Global.GlobalConfig.ApiActionFilters.ToList().ForEach(filter => config.GlobalFilters.Add(filter));
                config.FormatOptions.DateTimeFormat = DateTimeFormats.ISO8601_WithMillisecond;
                config.JsonFormatter = Global.GlobalConfig.DefaultJsonFormatter;
            };

            services.HttpApiFactoryBuilder<ApiContract.IMerchantContract>(configAction);
            services.HttpApiFactoryBuilder<ApiContract.ITerminalContract>(configAction);
            services.HttpApiFactoryBuilder<ApiContract.IPayContract>(configAction);

            services.AddTransient<Api.MerchantClient>();
            services.AddTransient<Api.TerminalClient>();
            services.AddTransient<Api.PayClient>();

        }


        /// <summary>
        /// HttpApi实例工厂创建器
        /// </summary>
        /// <param name="services"></param>
        private static void HttpApiFactoryBuilder<TInterface>(this IServiceCollection services, Action<HttpApiConfig> configAction)
            where TInterface : class, IHttpApi
        {
            services.AddSingleton<IHttpApiFactory<TInterface>, HttpApiFactory<TInterface>>(p =>
            {
                return new HttpApiFactory<TInterface>()
                .ConfigureHttpApiConfig(c => configAction?.Invoke(c));
            });

            services.AddTransient(p =>
            {
                var factory = p.GetRequiredService<IHttpApiFactory<TInterface>>();
                return factory.CreateHttpApi();
            });
        }
    }
}
