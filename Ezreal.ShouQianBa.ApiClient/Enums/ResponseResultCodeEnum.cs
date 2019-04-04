using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Ezreal.ShouQianBa.ApiClient.Enums
{
    /// <summary>
    /// 响应结果
    /// </summary>
    public enum ResponseResultCodeEnum
    {
        /// <summary>
        /// 成功
        /// </summary>
        [Description("通讯成功")]
        OK=200,
        /// <summary>
        /// 客户端错误
        /// </summary>
        [Description("客户端错误")]
        ClientError = 400,
        /// <summary>
        /// 服务端错误
        /// </summary>
        [Description("服务端错误")]
        ServerError = 500,

    }
}
