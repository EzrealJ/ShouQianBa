using Newtonsoft.Json;
using System;
using WebApiClient;

namespace Ezreal.ShouQianBa.ApiClient.ApiParameterModels
{
    /// <summary>
    /// 约定Api交互参数模型的基类
    /// <para>
    /// 与收钱吧进行交互的参数都直接或者间接继承此类
    /// </para>
    /// </summary>
    public class ApiParameterModelBase
    {
        /// <summary>
        /// 将Api参数模型转化成Json字符串
        /// </summary>
        /// <returns></returns>
        public virtual string ToApiParameterJsonString()
        {
            IJsonFormatter formatter = HttpApiConfig.DefaultJsonFormatter;
            return formatter.Serialize(this, null);
        }
        /// <summary>
        /// 从已有Json字符串解析Api参数模型
        /// </summary>
        /// <typeparam name="TTargetType"></typeparam>
        /// <param name="jsonString"></param>
        /// <returns></returns>
        public static TTargetType FormApiParameterJsonString<TTargetType>(string jsonString) where TTargetType : ApiParameterModelBase
        {
            IJsonFormatter formatter = HttpApiConfig.DefaultJsonFormatter;
            return formatter.Deserialize(jsonString, typeof(TTargetType)) as TTargetType;
        }

        /// <summary>
        /// 将模型转化成使用真实接口参数名作成员名的动态对象
        /// </summary>
        /// <returns></returns>
        public virtual dynamic ToApiParameterObject()
        {
            return JsonConvert.DeserializeObject<dynamic>(this.ToApiParameterJsonString());
        }
        /// <summary>
        /// 从使用真实接口参数名作成员名的动态对象中解析出参数模型
        /// </summary>
        /// <typeparam name="TTargetType"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static TTargetType FromApiParameterObject<TTargetType>(object obj) where TTargetType : ApiParameterModelBase
        {
            IJsonFormatter formatter = HttpApiConfig.DefaultJsonFormatter;
            return formatter.Deserialize(JsonConvert.SerializeObject(obj), typeof(TTargetType)) as TTargetType;
        }

    }
}