
using Ezreal.SDK.ShouQianBa.Attributes;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ezreal.SDK.ShouQianBa.ApiParameterModels.Response.Terminal
{
   public class TerminalActivateResponseModel:IBusinessResponseModel, Sign.ITerminalSignToken
    {
        [ApiParameterName("terminal_sn")]
        public string TerminalSerialNo { get; set; }
        [ApiParameterName("terminal_key")]
        public string TerminalKey { get; set; }
    }
}
