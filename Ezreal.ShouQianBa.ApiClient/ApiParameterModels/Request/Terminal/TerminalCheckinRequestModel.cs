using Ezreal.ShouQianBa.ApiClient.ApiParameterModels.Generic;
using Ezreal.ShouQianBa.ApiClient.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ezreal.ShouQianBa.ApiClient.ApiParameterModels.Request.Terminal
{
    /// <summary>
    /// 终端签到请求模型
    /// </summary>
    public class TerminalCheckinRequestModel : RequestModel, Sign.ITerminalSignable
    {
        /// <summary>
        /// *终端号
        /// </summary>
        [ApiParameterName("terminal_sn")]
        public string TerminalSerialNo { get; set; }
        /// <summary>
        /// *设备唯一身份ID
        /// </summary>
        [ApiParameterName("device_id")]
        public string DeviceID { get; set; }

        /// <summary>
        /// 系统信息
        /// </summary>
        [ApiParameterName("os_info")]
        public string OSInfo { get; } = "C#";
        /// <summary>
        /// SDK版本
        /// </summary>
        [ApiParameterName("sdk_version")]
        public string SdkVersion { get; set; } = "Ezreal.ShouQianBa.ApiClient@0.2.0(Bate)";
    }
}
