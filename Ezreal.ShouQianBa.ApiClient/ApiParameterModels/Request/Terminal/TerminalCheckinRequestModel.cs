using Ezreal.ShouQianBa.ApiClient.ApiParameterModels.Generic;
using Ezreal.ShouQianBa.ApiClient.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ezreal.ShouQianBa.ApiClient.ApiParameterModels.Request.Terminal
{
    public class TerminalCheckinRequestModel : RequestModel
    {
        /// <summary>
        /// 【必须】终端号
        /// </summary>
        [ApiParameterName("terminal_sn")]
        public string TerminalSerialNo { get; set; }
        /// <summary>
        /// 【必须】设备唯一身份ID
        /// </summary>
        [ApiParameterName("device_id")]
        public string DeviceID { get; set; }

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
