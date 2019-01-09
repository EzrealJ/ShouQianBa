using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Ezreal.SDK.ShouQianBa.Enums
{
    public enum ResponseResultCodeEnum
    {
        [Description("通讯成功")]
        OK=200,
        [Description("客户端错误")]
        ClientError = 400,
        [Description("客户端错误")]
        ServerError = 500,

    }
}
