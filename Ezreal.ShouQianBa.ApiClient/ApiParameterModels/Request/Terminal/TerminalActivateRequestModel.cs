using Ezreal.ShouQianBa.ApiClient.ApiParameterModels.Generic;
using Ezreal.ShouQianBa.ApiClient.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ezreal.ShouQianBa.ApiClient.ApiParameterModels.Request.Terminal
{
    public class TerminalActivateRequestModel : RequestModel, Sign.IServiceSignable
    {
        /// <summary>
        /// *从服务商平台获取
        /// </summary>
        [ApiParameterName("app_id")]
        public string AppID { get; set; }
        /// <summary>
        /// *激活码
        /// </summary>
        [ApiParameterName("code")]
        public string ActiveCode { get; set; }
        /// <summary>
        /// *设备唯一身份ID
        /// </summary>
        [ApiParameterName("device_id")]
        public string DeviceID { get; set; }
        /// <summary>
        /// 【非必需，但经过确认一般必须无】调用方终端号
        /// </summary>

        [ApiParameterName("client_sn")]
        public string ClientSerialNo { get; set; }
        /// <summary>
        /// 终端名
        /// </summary>

        [ApiParameterName("name")]
        public string Name { get; set; }
        /// <summary>
        /// 系统信息
        /// </summary>
        [ApiParameterName("os_info")]
        public string OSInfo { get; set; } = "C#"; /*= $"OS:{System.Environment.OSVersion.ToString()},Platform:{System.Environment.Version.ToString()},Language:C#";*/
        /// <summary>
        /// SDK版本
        /// </summary>
        [ApiParameterName("sdk_version")]
        public string SdkVersion { get; set; } = "Ezreal.ShouQianBa.ApiClient@0.2.0(Bate)";
    }
}
