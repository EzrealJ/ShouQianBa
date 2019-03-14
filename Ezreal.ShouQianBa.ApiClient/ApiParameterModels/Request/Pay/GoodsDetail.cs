using Ezreal.ShouQianBa.ApiClient.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ezreal.ShouQianBa.ApiClient.ApiParameterModels.Request.Pay
{
    public class GoodsDetail
    {
        /// <summary>
        /// 商品编号
        /// </summary>
        [ApiParameterName("goods_id")]
        public string ID { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>
        [ApiParameterName("goods_name")]
        public string Name { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        [ApiParameterName("quantity")]
        public string Quantity { get; set; }
        /// <summary>
        /// 单价
        /// </summary>
        [ApiParameterName("price")]
        public string Price { get; set; }

        /// <summary>
        /// 优惠类型
        /// <para>优惠类型，0:没有优惠 1: 支付机构优惠，为1会把相关信息送到支付机构</para>
        /// </summary>
        [ApiParameterName("promotion_type")]
        public string PromotionType { get; set; }


    }
}
