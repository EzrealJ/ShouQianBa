
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
    public  class SignProvider
    {
        public SignProvider()
        {
        }

        protected virtual string SerialNo { get; set; }
        protected virtual string Key { get; set; }
        protected virtual string GetSignContent<TData>(TData data)
        {
            if (string.IsNullOrWhiteSpace(this.Key))
            {
                throw new ArgumentNullException(nameof(Key));
            }
            IJsonFormatter formatter = HttpApiConfig.DefaultJsonFormatter;
            string json = formatter.Serialize(data, null);
            string signBody = $"{json}{Key}";
            return Security.MD5Hash.Md5HashToHex(signBody);
        }
        public virtual Sign<SignProvider, TData> Sign<TData>(TData data) 
        {
            return new Sign<SignProvider, TData>()
            {
                SerialNo = this.SerialNo,
                SignContent =this.GetSignContent(data) ,
                DataObject = data,
                SignProvider = this
            };
        }



    }
}
