using Ezreal.SDK.ShouQianBa.ApiContract;
using Ezreal.SDK.ShouQianBa.ApiParameterModels;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using WebApiClient;

namespace Ezreal.SDK.ShouQianBa
{
    public class GlobalConfig
    {
        public const string ProductionEnvironmentApiUri = "https://api-vendor.shouqianba.com/";
        public const string SandboxEnvironmentApiUri = "http://api-sandbox.test.shouqianba.com/";
        public GlobalConfig()
        {

        }

        /// <summary>
        /// 默认的收钱吧服务商配置
        /// </summary>
        public ServiceProviderSettings DefaultShouQianBaServiceProviderSettings { get; set; }

        public string ApiUri { get => UseSandbox ? SandboxEnvironmentApiUri : ProductionEnvironmentApiUri; }

        public bool UseSandbox { get; set; } = false;

        public IJsonFormatter DefaultJsonFormatter { get; set; } = new ApiJsonFormatter();
        public List<IApiActionFilter> ApiActionFilters { get; set; } = new List<IApiActionFilter>();
    }
}
