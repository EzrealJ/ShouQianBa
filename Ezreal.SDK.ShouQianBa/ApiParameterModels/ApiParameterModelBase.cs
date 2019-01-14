using Newtonsoft.Json;
using System;
using WebApiClient;

namespace Ezreal.SDK.ShouQianBa.ApiParameterModels
{

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