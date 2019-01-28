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
        public virtual string ToApiParameterJsonString()
        {
            IJsonFormatter formatter = HttpApiConfig.DefaultJsonFormatter;
            return formatter.Serialize(this, null);
        }

        public static TTargetType FormApiParameterJsonString<TTargetType>(string jsonString) where TTargetType : ApiParameterModelBase
        {
            IJsonFormatter formatter = HttpApiConfig.DefaultJsonFormatter;
            return formatter.Deserialize(jsonString, typeof(TTargetType)) as TTargetType;
        }

        public virtual dynamic ToApiParameterObject()
        {
            return JsonConvert.DeserializeObject<dynamic>(this.ToApiParameterJsonString());
        }

        public static TTargetType FromApiParameterObject<TTargetType>(object obj) where TTargetType : ApiParameterModelBase
        {
            IJsonFormatter formatter = HttpApiConfig.DefaultJsonFormatter;
            return formatter.Deserialize(JsonConvert.SerializeObject(obj), typeof(TTargetType)) as TTargetType;
        }

    }
}