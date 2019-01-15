
using Ezreal.ShouQianBa.ApiClient.ApiParameterModels.Request;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using WebApiClient;

namespace Ezreal.ShouQianBa.ApiClient.Sign
{
    /// <summary>
    /// 签名提供对象
    /// </summary>
    public abstract class SignProvider
    {
        protected SignProvider()
        {
        }
        /// <summary>
        /// 签名对外暴露的属性
        /// </summary>
        public virtual string Authorization
        {
            get
            {
                if (string.IsNullOrWhiteSpace(SerialNo))
                {
                    throw new ArgumentNullException(nameof(SerialNo));
                }

                if (string.IsNullOrWhiteSpace(SignContent))
                {
                    throw new ArgumentNullException(nameof(SignContent));
                }
                return $"{SerialNo} {SignContent}";
            }
        }
        protected virtual string SerialNo { get; set; }
        protected virtual string Key { get; set; }
        protected virtual string SignContent { get; set; }
        protected virtual SignProvider Sign(RequestModel requestParameterModel)
        {

            if (string.IsNullOrWhiteSpace(this.Key))
            {
                throw new ArgumentNullException(nameof(Key));
            }
            IJsonFormatter formatter = HttpApiConfig.DefaultJsonFormatter;
            string json = formatter.Serialize(requestParameterModel, null);
            string signBody = $"{json}{Key}";
            SignContent = Security.MD5Hash.Md5HashToHex(signBody);
            return this;
        }



    }
}
