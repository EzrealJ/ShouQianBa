using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using WebApiClient;

namespace Ezreal.ShouQianBa.ApiClient
{
    public class Global
    {
        /// <summary>
        /// 静态的全局配置信息
        /// </summary>
        public static GlobalConfig GlobalConfig { get; set; } = new GlobalConfig();
        /// <summary>
        /// 初始化全局配置
        /// <para>在没有DI的情况下可以使用它来初始化配置</para>
        /// </summary>
        /// <param name="action"></param>
        public static void InitializeDefaultConfig(Action<GlobalConfig> action)
        {
            action.Invoke(GlobalConfig);

            Action<HttpApiConfig> configAction = config =>
             {
                 config.HttpHost = new Uri(GlobalConfig.ApiUri);
                 GlobalConfig.ApiActionFilters.ToList().ForEach(filter => config.GlobalFilters.Add(filter));
                 config.FormatOptions.DateTimeFormat = WebApiClient.DateTimeFormats.ISO8601_WithMillisecond;
             };

            HttpApiFactory.Add<ApiContract.IMerchantContract>().ConfigureHttpApiConfig(configAction);
            HttpApiFactory.Add<ApiContract.ITerminalContract>().ConfigureHttpApiConfig(configAction);
            HttpApiFactory.Add<ApiContract.IMerchantContract>().ConfigureHttpApiConfig(configAction);


        }

        public static TInterface Create<TInterface>() where TInterface : class, IHttpApi
        {
            return HttpApiFactory.Create<TInterface>();
        }
    }
}
