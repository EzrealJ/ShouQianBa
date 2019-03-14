using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Ezreal.ShouQianBa.ApiClient.Enums
{
    /// <summary>
    /// 证件类型
    /// </summary>
    public enum CertificateTypeEnum
    {
        /// <summary>
        /// 身份证
        /// </summary>
        [Description("身份证")]
        IDCard = 1,
        /// <summary>
        /// 护照
        /// </summary>
        [Description("护照")]
        Passport = 2,
        /// <summary>
        /// 台胞证
        /// </summary>
        [Description("台胞证")]
        TaiwaneseCard = 3,
        /// <summary>
        /// 港澳通行证
        /// </summary>
        [Description("港澳通行证")]
        HongKongMacauPass = 4
    }
}
