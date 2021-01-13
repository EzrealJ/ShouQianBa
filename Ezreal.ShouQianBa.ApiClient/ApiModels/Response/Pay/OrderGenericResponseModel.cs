using Ezreal.ShouQianBa.ApiClient.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ezreal.ShouQianBa.ApiClient.ApiModels.Response.Pay
{
    /// <summary>
    /// 通用的支付响应模型
    /// <para>
    /// 通常情况下，除预创建订单外，支付相关接口返回的结果都能满足此模型
    /// </para>
    /// </summary>
    public class OrderGenericResponseModel : IBusinessResponseModel
    {
        /// <summary>
        /// 状态码
        /// </summary>
        [ApiParameterName("result_code")]
        public string ResultCode { get; set; }
        /// <summary>
        /// 错误码
        /// </summary>

        [ApiParameterName("error_code")]
        public string ErrorCode { get; set; }
        /// <summary>
        /// 错误信息
        /// </summary>

        [ApiParameterName("error_message")]
        public string ErrorMessage { get; set; }
        /// <summary>
        /// 收钱吧订单
        /// </summary>
        [ApiParameterName("data")]
        public Generic.ShouQianBaOrder Order { get; set; }
        /// <summary>
        /// 订单是否有效
        /// <para>
        /// 等效于Order!=null
        /// </para>
        /// </summary>
        public bool IsEffectiveOrder { get => this.Order != null; }
    }
}
