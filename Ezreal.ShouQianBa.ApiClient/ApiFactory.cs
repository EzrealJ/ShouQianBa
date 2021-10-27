using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ezreal.ShouQianBa.ApiClient.Api;
using Ezreal.ShouQianBa.ApiClient.ApiContract;

namespace Ezreal.ShouQianBa.ApiClient
{
    /// <summary>
    /// Api工厂
    /// </summary>
    public class ApiFactory
    {
        /// <summary>
        /// 创建设备相关Client
        /// </summary>
        /// <returns></returns>
        public static TerminalClient CreateTerminalClient() => new TerminalClient(null);
        /// <summary>
        /// 创建支付相关Client
        /// </summary>
        /// <returns></returns>
        public static PayClient CreatePayClient() => new PayClient(null);
    }
}
