using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Ezreal.ShouQianBa.ApiClient.Enums
{
    public enum AccountTypeEnum
    {
        /// <summary>
        /// 个人账户
        /// </summary>
        [Description("个人账户")]
        Personal = 1,
        /// <summary>
        /// 企业账户
        /// </summary>
        [Description("企业账户")]
        Enterprise = 2
    }
}
