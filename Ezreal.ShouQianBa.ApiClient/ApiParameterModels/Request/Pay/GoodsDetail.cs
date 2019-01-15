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

        [ApiParameterName("goods_id")]
        public string ID { get; set; }

        [ApiParameterName("goods_name")]
        public string Name { get; set; }


        [ApiParameterName("quantity")]
        public string Quantity { get; set; }

        [ApiParameterName("price")]
        public string Price { get; set; }


        [ApiParameterName("promotion_type")]
        public string PromotionType { get; set; }


    }
}
