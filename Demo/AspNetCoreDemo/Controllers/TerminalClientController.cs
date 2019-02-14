using Ezreal.ShouQianBa.ApiClient.Api;
using Ezreal.ShouQianBa.ApiClient.ApiParameterModels.Request.Terminal;
using Ezreal.ShouQianBa.ApiClient.ApiParameterModels.Response;
using Ezreal.ShouQianBa.ApiClient.ApiParameterModels.Response.Terminal;
using Ezreal.ShouQianBa.ApiClient.Sign;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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
        /// <param name="serviceProviderSignSettings"></param>
        /// <returns></returns>
        [HttpPost(nameof(Activate))]
        public async Task<Response<TerminalActivateResponseModel>> Activate([FromBody]TerminalActivateRequestModel requestModel, [FromQuery]ServiceProviderSignSettings serviceProviderSignSettings)
        {
            return await TerminalClient.Activate(requestModel, serviceProviderSignSettings);
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

        /// <summary>
        /// 刷新默认的终端签名信息
        /// </summary>
        /// <returns></returns>
        [HttpGet(nameof(RefreshDefaultTerminalSignSettings))]
        public async Task<bool> RefreshDefaultTerminalSignSettings([FromServices]TerminalSignSettings terminalSignSettings)
        {
            if (terminalSignSettings == null)
            {
                throw new ArgumentNullException(nameof(terminalSignSettings), "The TerminalSignSettings.json file must be provided in the root directory as the default terminal signature configuration!");
            }
            Response<TerminalCheckinResponseModel> checkinResult = await TerminalClient.Checkin(new TerminalCheckinRequestModel() { DeviceID = DefaultTerminalInfo.DeviceID, TerminalSerialNo = terminalSignSettings.TerminalSerialNo }, terminalSignSettings);
            if(checkinResult.ExistsBusinessResponseContent)
            {
                terminalSignSettings.TerminalSerialNo = checkinResult.BusinessResponseContent.TerminalSerialNo;
                terminalSignSettings.TerminalKey = checkinResult.BusinessResponseContent.TerminalKey;
                await System.IO.File.WriteAllTextAsync(Path.Combine(Startup.ApplicationPath, "TerminalSignSettings.json"), JsonConvert.SerializeObject(terminalSignSettings));
                return true;
            }
            return false;
        }
    }
}
