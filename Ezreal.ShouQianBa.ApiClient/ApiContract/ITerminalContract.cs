using Ezreal.ShouQianBa.ApiClient.ApiModels.Response;
using Ezreal.ShouQianBa.ApiClient.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiClient;
using WebApiClient.Attributes;
using Ezreal.ShouQianBa.ApiClient.ApiModels.Request.Terminal;
using Ezreal.ShouQianBa.ApiClient.ApiModels.Response.Terminal;
using Ezreal.ShouQianBa.ApiClient.Sign;
using WebApiClient.Parameterables;
using Ezreal.ShouQianBa.ApiClient.ApiModels.Request;
using System.Threading;

namespace Ezreal.ShouQianBa.ApiClient.ApiContract
{
    /// <summary>
    /// 设备相关接口
    /// </summary>


    public interface ITerminalContract : IHttpApi
    {
        /// <summary>
        /// 设备激活
        /// </summary>
        /// <param name="serviceProviderSignSettings"></param>
        /// <param name="terminalActivateRequestModel"></param>
        /// <param name="timeout">超时时间,可以覆盖预定义特性<see cref="TimeoutAttribute"/></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [Timeout(5 * 1000)]
        [HttpPost("terminal/activate")]
        [JsonReturn]
        ITask<Response<TerminalActivateResponseModel>> Activate([Headers]ServiceProviderSignSettings serviceProviderSignSettings, [JsonContent]TerminalActivateRequestModel terminalActivateRequestModel, [Timeout]TimeSpan? timeout = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// 设备签到
        /// </summary>
        /// <param name="terminalSignSettings"></param>
        /// <param name="terminalCheckinRequestModel"></param>
        /// <param name="timeout">超时时间,可以覆盖预定义特性<see cref="TimeoutAttribute"/></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [Timeout(5 * 1000)]
        [HttpPost("terminal/checkin")]
        [JsonReturn]
        ITask<Response<TerminalCheckinResponseModel>> Checkin([Headers]TerminalSignSettings terminalSignSettings, [JsonContent]TerminalCheckinRequestModel terminalCheckinRequestModel, [Timeout]TimeSpan? timeout = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// 上传日志
        /// <para>
        /// 收钱吧方面建议日志本地保存
        /// </para>
        /// </summary>
        /// <param name="terminalSignSettings"></param>
        /// <param name="logFile"></param>
        /// <param name="timeout"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [Timeout(5 * 1000)]
        [HttpPost("terminal/uploadLog")]
        [JsonReturn]
        ITask<ResponseModel> UploadLog([Headers]TerminalSignSettings terminalSignSettings, [JsonContent]MulitpartFile logFile, [Timeout]TimeSpan? timeout = null, CancellationToken cancellationToken = default(CancellationToken));
    }
}
