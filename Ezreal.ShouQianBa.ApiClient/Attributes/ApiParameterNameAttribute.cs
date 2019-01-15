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
        public ApiParameterNameAttribute(string name) : base(name)
        {
        }
    }
}