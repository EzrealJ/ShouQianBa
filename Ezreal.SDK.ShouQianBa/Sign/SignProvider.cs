
using Ezreal.SDK.ShouQianBa.ApiParameterModels.Request;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using WebApiClient;

namespace Ezreal.SDK.ShouQianBa.Sign
{
    public abstract class SignProvider
    { 
        protected SignProvider()
        {
        }

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
        public virtual string SerialNo { get; set; }
        public virtual string SignContent { get; protected set; }
        protected virtual void Sign(RequestModel requestParameterModel, string key)
        {
            IJsonFormatter formatter = HttpApiConfig.DefaultJsonFormatter;
            string json = formatter.Serialize(requestParameterModel, null);
            string signBody = $"{json}{key}";
            SignContent = Security.MD5Hash.Md5HashToHex(signBody);

        }


    }
}
