
using Ezreal.ShouQianBa.ApiClient.Attributes;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ezreal.ShouQianBa.ApiClient.ApiParameterModels.Response.Terminal
{
    /// <summary>
    /// 终端激活接口响应模型
    /// </summary>
   public class TerminalActivateResponseModel:IBusinessResponseModel
    {
        /// <summary>
        /// 终端编号
        /// </summary>
        [ApiParameterName("terminal_sn")]
        public string TerminalSerialNo { get; set; }
        /// <summary>
        /// 终端Key
        /// </summary>
        [ApiParameterName("terminal_key")]
        public string TerminalKey { get; set; }
    }
}
