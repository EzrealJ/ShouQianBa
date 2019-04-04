using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ezreal.ShouQianBa.ApiClient.Enums
{
    /// <summary>
    /// 二级支付方式
    /// </summary>
    public enum SubPaywayEnum
    {
        /// <summary>
        /// 条码
        /// </summary>
        BarCode = 1,
        /// <summary>
        /// 二维码
        /// </summary>
        QrCode = 2,
        /// <summary>
        /// WAP支付
        /// </summary>
        WAP = 3,
        /// <summary>
        /// 小程序
        /// </summary>
        Applet = 4,
        /// <summary>
        /// APP
        /// </summary>
        App = 5,
        /// <summary>
        /// H5
        /// </summary>
        H5 = 6
    }
}
