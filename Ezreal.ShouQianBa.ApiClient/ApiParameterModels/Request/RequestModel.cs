using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Dynamic;
using System.Text;
using Newtonsoft.Json;

namespace Ezreal.ShouQianBa.ApiClient.ApiParameterModels.Request
{
    /// <summary>
    /// 约定请求参数的模型，它是一个抽象类
    /// <para>
    /// 收钱吧约定所有请求都通过HttpPost的Body发送,采用utf-8编码的application/json请求 
    /// </para>
    /// <para>
    /// 此外还约定了所有参数的值都是<see cref="String"/>类型传递
    /// </para>
    /// <para>
    /// 出于方便考虑没有完全遵照此约定来定义请求模型,差异之处使用<see cref="Newtonsoft.Json.JsonConverter"/>的不同实现进行转化
    /// </para>
    /// 
    /// </summary>
    public abstract class RequestModel : ApiParameterModelBase
    {

    }
}
