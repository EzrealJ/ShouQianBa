using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using WebApiClient;

namespace Ezreal.ShouQianBa.ApiClient
{
    /// <summary>
    /// 收钱吧全局操作
    /// </summary>
    public class ShouQianBaGlobal
    {
        /// <summary>
        /// 静态的全局配置信息
        /// </summary>
        public static ShouQianBaGlobalConfig GlobalConfig { get; set; } = new ShouQianBaGlobalConfig();
        /// <summary>
        /// 初始化全局配置
        /// <para>在没有DI的情况下可以使用它来初始化配置</para>
        /// </summary>
        /// <param name="action"></param>   
        /// <param name="loggerFactory">日志工厂</param>
        public static void InitializeDefaultConfig(Action<ShouQianBaGlobalConfig> action, ILoggerFactory loggerFactory = null)
        {
            action.Invoke(GlobalConfig);
            HttpApiConfig.DefaultJsonFormatter = ShouQianBaGlobal.GlobalConfig.DefaultJsonFormatter;
            Action<HttpApiConfig> configAction = config =>
             {
                 config.HttpHost = new Uri(GlobalConfig.ApiUri);
                 GlobalConfig.ApiActionFilters.ToList().ForEach(filter => config.GlobalFilters.Add(filter));
                 if (GlobalConfig.UseLog)
                 {
                     config.GlobalFilters.Add(new WebApiClient.Attributes.TraceFilterAttribute());
                 }
                 config.FormatOptions.DateTimeFormat = WebApiClient.DateTimeFormats.ISO8601_WithMillisecond;
                 config.LoggerFactory = loggerFactory;
             };

            HttpApiFactory.Add<ApiContract.IMerchantContract>().ConfigureHttpApiConfig(configAction);
            HttpApiFactory.Add<ApiContract.ITerminalContract>().ConfigureHttpApiConfig(configAction);
            HttpApiFactory.Add<ApiContract.IPayContract>().ConfigureHttpApiConfig(configAction);


        }

        public static TInterface Create<TInterface>() where TInterface : class, IHttpApi
        {
            return HttpApiFactory.Create<TInterface>();
        }
    }
}
