using Ezreal.ShouQianBa.ApiClient.ApiContract;
using Ezreal.ShouQianBa.ApiClient.ApiParameterModels;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using WebApiClient;

namespace Ezreal.ShouQianBa.ApiClient
{
    /// <summary>
    /// 收钱吧全局配置
    /// </summary>
    public class ShouQianBaGlobalConfig
    {
        /// <summary>
        /// 生产环境Uri
        /// </summary>
        public string ProductionEnvironmentApiUri { get; set; } = "https://vsi-api.shouqianba.com";
        /// <summary>
        /// 沙箱环境Uri
        /// </summary>
        public string SandboxEnvironmentApiUri { get; set; } = "http://api-sandbox.test.shouqianba.com/";

        /// <summary>
        /// 默认的收钱吧服务商配置
        /// </summary>
        public ServiceProviderSettings DefaultShouQianBaServiceProviderSettings { get; set; }
        /// <summary>
        /// Api地址
        /// </summary>
        public string ApiUri { get => UseSandbox ? SandboxEnvironmentApiUri : ProductionEnvironmentApiUri; }
        /// <summary>
        /// 使用沙箱,默认false
        /// </summary>
        public bool UseSandbox { get; set; } = false;

        /// <summary>
        /// 启用日志,默认false
        /// <para>
        /// 将会在日志中记录请求内容
        /// </para>
        /// </summary>
        public bool UseLog { get; set; } = false;

        /// <summary>
        /// 全局拦截器集合
        /// </summary>
        public List<IApiActionFilter> ApiActionFilters { get; set; } = new List<IApiActionFilter>();
    }
}
