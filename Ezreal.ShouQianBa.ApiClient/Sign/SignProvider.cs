
using Ezreal.ShouQianBa.ApiClient.ApiModels.Request;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;
using WebApiClient;
using WebApiClient.DataAnnotations;

namespace Ezreal.ShouQianBa.ApiClient.Sign
{
    /// <summary>
    /// 签名提供对象
    /// </summary>
    public class SignProvider
    {
        public SignProvider(ISignSettings signSettings)
        {
            SignSettings = signSettings ?? throw new ArgumentNullException(nameof(signSettings));
        }
        
        public ISignSettings SignSettings { get; set; }
        /// <summary>
        /// 签名
        /// </summary>
        /// <param name="bodyContent"></param>
        /// <returns></returns>
        public virtual AuthenticationHeaderValue Sign(string bodyContent)
        {
            string signBody = $"{bodyContent}{SignSettings.Key}";
            return new AuthenticationHeaderValue(SignSettings.SerialNo, Security.MD5Hash.Md5HashToHex(signBody));

        }



    }
}
