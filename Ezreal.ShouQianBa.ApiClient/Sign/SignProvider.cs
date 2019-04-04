
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
#pragma warning disable CS1591 // 缺少对公共可见类型或成员的 XML 注释
        public SignProvider()
#pragma warning restore CS1591 // 缺少对公共可见类型或成员的 XML 注释
        {
        }
        /// <summary>
        /// 序列号
        /// </summary>
        protected virtual string SerialNo { get; set; }
        /// <summary>
        /// Key
        /// </summary>
        protected virtual string Key { get; set; }
        /// <summary>
        /// 获取签名内容
        /// </summary>
        /// <typeparam name="TData"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
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
        /// <summary>
        /// 签名
        /// </summary>
        /// <typeparam name="TData"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
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
