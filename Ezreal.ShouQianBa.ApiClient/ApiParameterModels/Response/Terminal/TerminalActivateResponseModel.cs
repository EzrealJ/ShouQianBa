
using Ezreal.ShouQianBa.ApiClient.Attributes;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ezreal.ShouQianBa.ApiClient.ApiParameterModels.Response.Terminal
{
   public class TerminalActivateResponseModel:IBusinessResponseModel
    {
        [ApiParameterName("terminal_sn")]
        public string TerminalSerialNo { get; set; }
        [ApiParameterName("terminal_key")]
        public string TerminalKey { get; set; }
    }
}
