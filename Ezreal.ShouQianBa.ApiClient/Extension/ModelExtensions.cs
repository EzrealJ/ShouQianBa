using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Text;
using Ezreal.ShouQianBa.ApiClient.Attributes;
using System.Reflection;
using System.Diagnostics;
using Ezreal.ShouQianBa.ApiClient.Sign;

namespace Ezreal.ShouQianBa.ApiClient.Extension
{
    /// <summary>
    /// 模型扩展方法
    /// </summary>
    static public class ModelExtensions
    {
        /// <summary>
        /// 获取属性在接口交互时对应的参数名
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="source"></param>
        /// <param name="keySelector"></param>
        /// <returns></returns>
        public static string NameOfApiParameter<TSource, TKey>(this TSource source, Expression<Func<TSource, TKey>> keySelector) where TSource : ApiModels.ApiModelBase
        {
            MemberInfo memberInfo = (keySelector.Body as MemberExpression).Member;
            return memberInfo.GetApiParameterName();
        }

        private static string GetApiParameterName(this MemberInfo memberInfo)
        {

            CustomAttributeData apiParameterAttribute = memberInfo.CustomAttributes.FirstOrDefault(attr => attr.AttributeType == typeof(ApiParameterNameAttribute));
            Type[] interfaceTypes = memberInfo.ReflectedType.GetInterfaces();
            if (apiParameterAttribute == null)
            {
                if (memberInfo.MemberType == MemberTypes.Field)
                {
                    apiParameterAttribute = interfaceTypes.FirstOrDefault(i => i.GetFields().Count(f => f.Name.Equals(memberInfo.Name)) > 0)?.GetField(memberInfo.Name).CustomAttributes.FirstOrDefault(attr => attr.AttributeType == typeof(ApiParameterNameAttribute));
                }
                if (memberInfo.MemberType == MemberTypes.Property)
                {
                    apiParameterAttribute = interfaceTypes.FirstOrDefault(i => i.GetProperties().Count(p => p.Name.Equals(memberInfo.Name)) > 0)?.GetProperty(memberInfo.Name).CustomAttributes.FirstOrDefault(attr => attr.AttributeType == typeof(ApiParameterNameAttribute));
                }
                if (memberInfo.MemberType == MemberTypes.Method)
                {
                    apiParameterAttribute = interfaceTypes.FirstOrDefault(i => i.GetMethods().Count(m => m.Name.Equals(memberInfo.Name)) > 0)?.GetMethod(memberInfo.Name).CustomAttributes.FirstOrDefault(attr => attr.AttributeType == typeof(ApiParameterNameAttribute));
                }
            }
            string targetApiParameterName = apiParameterAttribute?.ConstructorArguments.FirstOrDefault().Value?.ToString();
            if (string.IsNullOrWhiteSpace(targetApiParameterName))
            {
                targetApiParameterName = memberInfo.Name;
            }
            return targetApiParameterName;
        }

        /// <summary>
        /// 获取double类型金额以分计的字符串形式
        /// <para>
        /// 收钱吧接口参数全部定义为string,使用此扩展获取double类型金额以分计的字符串形式
        /// </para>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToCentString(this double value)
        {
            return ((int)(Math.Round(value, 2) * 100)).ToString();
        }
        /// <summary>
        /// 获取decimal类型金额以分计的字符串形式
        /// <para>
        /// 收钱吧接口参数全部定义为string,使用此扩展获取decimal类型金额以分计的字符串形式
        /// </para>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToCentString(this decimal value)
        {
            return ((int)(Math.Round(value, 2) * 100)).ToString();
        }

        /// <summary>
        /// 获取枚举的基类型值的字符串形式
        /// <para>
        /// 收钱吧接口参数全部定义为string,使用此扩展获取枚举的基类型值的字符串形式
        /// </para>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetStringValue(this Enum value)
        {
            Type type = Enum.GetUnderlyingType(value.GetType());
            return Convert.ChangeType((value as ValueType), type).ToString();
        }

    }
}
