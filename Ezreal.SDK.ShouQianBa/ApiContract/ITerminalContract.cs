using Ezreal.SDK.ShouQianBa.ApiParameterModels.Response;
using Ezreal.SDK.ShouQianBa.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiClient;
using WebApiClient.Attributes;
using Ezreal.SDK.ShouQianBa.ApiParameterModels.Request.Terminal;
using Ezreal.SDK.ShouQianBa.ApiParameterModels.Response.Terminal;
using Ezreal.SDK.ShouQianBa.Sign;
using WebApiClient.Parameterables;
using Ezreal.SDK.ShouQianBa.ApiParameterModels.Request;

namespace Ezreal.SDK.ShouQianBa.ApiContract
{
    [HttpHost("https://api-vendor.shouqianba.com/")]
    public interface ITerminalContract:IHttpApi
    {
        [Timeout(5 * 1000)]
        [HttpPost("terminal/activate")]
        [JsonReturn]
        ITask<Response<TerminalActivateResponseModel>> Activate([Headers]ServiceProviderSignProvider<TerminalActivateRequestModel> serviceProviderSigner, [JsonContent]TerminalActivateRequestModel terminalActivateRequestModel, Timeout timeout = null);

        [Timeout(5 * 1000)]
        [HttpPost("terminal/checkin")]
        [JsonReturn]
        ITask<Response<TerminalCheckinResponseModel>> Checkin([Headers]TerminalSignProvider<TerminalCheckinRequestModel> terminalSignProvider, [JsonContent]TerminalCheckinRequestModel terminalCheckinRequestModel, Timeout timeout = null);

        [Obsolete("根据文档尚不能明确正确的签名/上传方式,作者认为其描述是片面的，不合理的;文档要求使用zip格式压缩,压缩后得到的文件,如何签名? base64?亦或是直接MD5 hash Hex?仍需要application/json的Header?")]
        [Timeout(5 * 1000)]
        [HttpPost("terminal/uploadLog")]
        [JsonReturn]
        ITask<ResponseModel> UploadLog([Headers]TerminalSignProvider<RequestModel> terminalSignProvider, [JsonContent]MulitpartFile mulitpartFile);
    }
}
