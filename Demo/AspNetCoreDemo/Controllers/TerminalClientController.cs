using Ezreal.ShouQianBa.ApiClient.Api;
using Ezreal.ShouQianBa.ApiClient.ApiParameterModels.Request.Terminal;
using Ezreal.ShouQianBa.ApiClient.ApiParameterModels.Response;
using Ezreal.ShouQianBa.ApiClient.ApiParameterModels.Response.Terminal;
using Ezreal.ShouQianBa.ApiClient.Sign;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreDemo.Controllers
{
    /// <summary>
    /// 终端
    /// </summary>
    [Route("[controller]")]
    public class TerminalClientController : Controller
    {
        public TerminalClientController(TerminalClient terminalClient)
        {
            TerminalClient = terminalClient;
        }

        public TerminalClient TerminalClient { get; }

        /// <summary>
        /// 激活
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        [HttpPost(nameof(Activate))]
        public async Task<Response<TerminalActivateResponseModel>> Activate(TerminalActivateRequestModel requestModel)
        {
            return await TerminalClient.Activate(requestModel);
        }
        /// <summary>
        /// 签到
        /// </summary>
        /// <param name="requestModel"></param>
        /// <param name="terminalSignSettings"></param>
        /// <returns></returns>
        [HttpPost(nameof(Checkin))]
        public async Task<Response<TerminalCheckinResponseModel>> Checkin(TerminalCheckinRequestModel requestModel, TerminalSignSettings terminalSignSettings)
        {
            return await TerminalClient.Checkin(requestModel, terminalSignSettings);
        }
    }
}
