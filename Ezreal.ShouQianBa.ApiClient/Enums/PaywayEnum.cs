using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ezreal.ShouQianBa.ApiClient.Enums
{
    /// <summary>
    /// 支付方式
    /// </summary>
    public enum PaywayEnum
    {
        /// <summary>
        /// 境外支付宝本地钱包收款
        /// </summary>
        AliPayLocal = 1,
        /// <summary>
        /// 支付宝
        /// </summary>
        AliPay = 2,
        /// <summary>
        /// 微信
        /// </summary>
        WxPay = 3,
        /// <summary>
        /// 百度钱包
        /// </summary>
        BaiduPay = 4,
        /// <summary>
        /// 京东钱包
        /// </summary>
        JDPay = 5,
        /// <summary>
        /// QQ钱包
        /// </summary>
        QQPay = 6,
        /// <summary>
        /// NFC支付
        /// </summary>
        NFCPay = 7,
        /// <summary>
        /// 拉卡拉前辈
        /// </summary>
        LakalaPay = 8,
        /// <summary>
        /// 移动和包支付
        /// </summary>
        CMPay = 9,
        /// <summary>
        /// 拉卡拉微信
        /// </summary>
        LakalaPayWx = 15,
        /// <summary>
        /// 招商银行
        /// </summary>
        ChinaMerchantsBank = 16,
        /// <summary>
        /// 银联二维码
        /// </summary>
        UnionQRPay = 17,
        /// <summary>
        /// 翼支付
        /// </summary>
        BestPay = 18,
        /// <summary>
        /// 境外微信本地钱包收款
        /// </summary>
        WeixinLocal = 19,
        /// <summary>
        /// 储值支付
        /// </summary>
        DepositPay = 100
    }
}
