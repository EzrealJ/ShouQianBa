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
        /// 【必须】从服务商平台获取
        /// </summary>
        [ApiParameterName("app_id")]
        public string AppID { get; set; }
        /// <summary>
        /// 【必须】激活码
        /// </summary>
        [ApiParameterName("code")]
        public string ActiveCode { get; set; }
        /// <summary>
        /// 【必须】设备唯一身份ID
        /// </summary>
        [ApiParameterName("device_id")]
        public string DeviceID { get; set; }
        /// <summary>
        /// 调用方终端号
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
        public string OSInfo { get; set; }
        /// <summary>
        /// SDK版本
        /// </summary>
        [ApiParameterName("sdk_version")]
        public string SdkVersion { get; set; }
    }
}
