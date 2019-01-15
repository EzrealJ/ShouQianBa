using Ezreal.ShouQianBa.ApiClient.ApiContract;
using Ezreal.ShouQianBa.ApiClient.ApiParameterModels;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using WebApiClient;

namespace Ezreal.ShouQianBa.ApiClient
{
    public class GlobalConfig
    {
        /// <summary>
        /// 生产环境Uri
        /// </summary>
        public const string ProductionEnvironmentApiUri = "https://api-vendor.shouqianba.com/";
        /// <summary>
        /// 沙箱环境Uri
        /// </summary>
        public const string SandboxEnvironmentApiUri = "http://api-sandbox.test.shouqianba.com/";


        /// <summary>
        /// 默认的收钱吧服务商配置
        /// </summary>
        public ServiceProviderSettings DefaultShouQianBaServiceProviderSettings { get; set; }
        /// <summary>
        /// Api地址
        /// </summary>
        public string ApiUri { get => UseSandbox ? SandboxEnvironmentApiUri : ProductionEnvironmentApiUri; }
        /// <summary>
        /// 使用沙箱
        /// </summary>
        public bool UseSandbox { get; set; } = false;
        /// <summary>
        /// 默认的Json序列化设置
        /// <para>
        /// 在没有详细阅读代码的情况下请不要改动
        /// </para>
        /// </summary>
        public IJsonFormatter DefaultJsonFormatter { get; set; } = new ApiJsonFormatter();
        public List<IApiActionFilter> ApiActionFilters { get; set; } = new List<IApiActionFilter>();
    }
}
