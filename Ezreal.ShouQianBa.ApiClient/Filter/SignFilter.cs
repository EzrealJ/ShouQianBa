using Ezreal.ShouQianBa.ApiClient.Sign;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using WebApiClient;
using WebApiClient.Contexts;

namespace Ezreal.ShouQianBa.ApiClient.Filter
{
    public class SignFilter : IApiActionFilter
    {
        public async Task OnBeginRequestAsync(ApiActionContext context)
        {

            await this.SignRequestAsync(context);

        }

        public Task OnEndRequestAsync(ApiActionContext context)
        {
#if NET45
            return Task.FromResult<object>(null);
#else
            return Task.CompletedTask;
#endif
        }

        /// <summary>
        /// 添加签名
        /// </summary>
        /// <param name="context">请求上下文</param>
        protected virtual async Task SignRequestAsync(ApiActionContext context)
        {
            ISignSettings signSettings = context.ApiActionDescriptor.Arguments.FirstOrDefault(arg => arg is ISignSettings) as ISignSettings;
            context.RequestMessage.Headers.Authorization = new SignProvider(signSettings).Sign(await context.RequestMessage.Content.ReadAsStringAsync());
        }
    }
}
