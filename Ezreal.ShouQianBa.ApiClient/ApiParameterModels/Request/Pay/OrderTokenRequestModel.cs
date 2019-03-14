using Ezreal.ShouQianBa.ApiClient.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ezreal.ShouQianBa.ApiClient.ApiParameterModels.Request.Pay
{
    /// <summary>
    /// 已有订单访问凭证请求模型
    /// <para>
    /// 可用于查询，撤单,手工扯单操作
    /// </para>
    /// </summary>
    public class OrderTokenRequestModel : RequestModel, Sign.ITerminalSignable
    {
        /// <summary>
        /// *收钱吧终端ID
        /// </summary>
        [ApiParameterName("terminal_sn")]
        public string TerminalSerialNo { get; set; }

        /// <summary>
        ///【可选必须】收钱吧订单号
        /// </summary>

        [ApiParameterName("sn")]
        public string SerialNo { get; set; }
        /// <summary>
        ///【可选必须】调用方订单号
        /// </summary>

        [ApiParameterName("client_sn")]
        public string ClientSerialNo { get; set; }
    }
}
