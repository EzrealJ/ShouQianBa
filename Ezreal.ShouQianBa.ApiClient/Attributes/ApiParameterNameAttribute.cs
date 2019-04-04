using System;
using WebApiClient.DataAnnotations;

namespace Ezreal.ShouQianBa.ApiClient.Attributes
{
    /// <summary>
    /// 在请求中使用的参数名
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class ApiParameterNameAttribute : AliasAsAttribute
    {
        /// <summary>
        /// 定义真实发起请求的参数名
        /// </summary>
        /// <param name="name">接口真实的参数名</param>
        public ApiParameterNameAttribute(string name) : base(name)
        {
            //预留，暂不做任何处理
        }
    }
}