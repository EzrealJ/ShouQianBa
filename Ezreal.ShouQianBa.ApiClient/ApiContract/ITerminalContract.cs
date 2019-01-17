using Ezreal.ShouQianBa.ApiClient.ApiParameterModels.Response;
using Ezreal.ShouQianBa.ApiClient.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiClient;
using WebApiClient.Attributes;
using Ezreal.ShouQianBa.ApiClient.ApiParameterModels.Request.Terminal;
using Ezreal.ShouQianBa.ApiClient.ApiParameterModels.Response.Terminal;
using Ezreal.ShouQianBa.ApiClient.Sign;
using WebApiClient.Parameterables;
using Ezreal.ShouQianBa.ApiClient.ApiParameterModels.Request;
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
        /// <param name="serviceProviderSigner"></param>
        /// <param name="terminalActivateRequestModel"></param>
        /// <param name="timeout">超时时间,可以覆盖预定义特性<see cref="TimeoutAttribute"/></param>
        /// <returns></returns>
        [Timeout(5 * 1000)]
        [HttpPost("terminal/activate")]
        [JsonReturn]
        ITask<Response<TerminalActivateResponseModel>> Activate([Headers]Sign<ServiceProviderSignProvider, TerminalActivateRequestModel> sign, [JsonContent]TerminalActivateRequestModel terminalActivateRequestModel,  WebApiClient.Parameterables.Timeout timeout = null,CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// 设备签到
        /// </summary>
        /// <param name="terminalSignProvider"></param>
        /// <param name="terminalCheckinRequestModel"></param>
        /// <param name="timeout">超时时间,可以覆盖预定义特性<see cref="TimeoutAttribute"/></param>
        /// <returns></returns>
        [Timeout(5 * 1000)]
        [HttpPost("terminal/checkin")]
        [JsonReturn]
        ITask<Response<TerminalCheckinResponseModel>> Checkin([Headers]Sign<TerminalSignProvider, TerminalCheckinRequestModel> sign, [JsonContent]TerminalCheckinRequestModel terminalCheckinRequestModel,  WebApiClient.Parameterables.Timeout timeout = null,CancellationToken cancellationToken = default(CancellationToken));
        ///// <summary>
        ///// 上传日志
        ///// <para>
        ///// 收钱吧方面建议日志本地保存，此接口因文档描述模糊暂不可用
        ///// </para>
        ///// </summary>
        ///// <param name="terminalSignProvider"></param>
        ///// <param name="mulitpartFile"></param>
        ///// <returns></returns>
        //[Obsolete("根据文档尚不能明确正确的签名/上传方式,作者认为其描述是片面的，不合理的;文档要求使用zip格式压缩,压缩后得到的文件,如何签名? base64?亦或是直接MD5 hash Hex?仍需要application/json的Header?")]
        //[Timeout(5 * 1000)]
        //[HttpPost("terminal/uploadLog")]
        //[JsonReturn]
        //ITask<ResponseModel> UploadLog([Headers]Sign<TerminalSignProvider, RequestModel> sign, [JsonContent]MulitpartFile mulitpartFile,  WebApiClient.Parameterables.Timeout timeout = null,CancellationToken cancellationToken = default(CancellationToken));
    }
}
