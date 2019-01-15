using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ezreal.ShouQianBa.ApiClient.Enums
{

    public enum PaywayEnum
    {
        AliPayLocal = 1,
        AliPay = 2,
        WxPay = 3,
        BaiduPay = 4,
        JDPay = 5,
        QQPay = 6,
        NFCPay = 7,
        LakalaPay = 8,
        CMPay = 9,
        LakalaPayWx = 15,
        ChinaMerchantsBank = 16,
        UnionQRPay = 17,
        BestPay = 18,
        WeixinLocal = 19,
        DepositPay = 100
    }
}
