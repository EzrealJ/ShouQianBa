using Ezreal.ShouQianBa.ApiClient.Attributes;
using Ezreal.ShouQianBa.ApiClient.Enums;
using Ezreal.ShouQianBa.ApiClient.ApiParameterModels.Generic;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Ezreal.ShouQianBa.ApiClient.Converters;

namespace Ezreal.ShouQianBa.ApiClient.ApiParameterModels.Request.Merchant
{
    /// <summary>
    /// 商户入网接口请求模型
    /// <para>
    /// https://doc.shouqianba.com/zh-cn/api/interface/merchantCreate.html
    /// </para>
    /// </summary>
    public class MerchantCreateRequestModel : RequestModel, Sign.IServiceSignable
    {
        /// <summary>
        /// 证件类型
        /// </summary>
        [ApiParameterName("id_type")]
        [JsonConverter(typeof(EnumValueStringConverter))]
        public CertificateTypeEnum CertificateType { get; set; }
        /// <summary>
        /// 扩展信息
        /// </summary>
        [ApiParameterName("extra")]
        public dynamic Extra { get; set; }
        /// <summary>
        /// 是否主动创建商户
        /// </summary>
        [ApiParameterName("create_account")]
        public bool ProactiveCreateAccount { get; set; } = true;
        /// <summary>
        /// 账户类型
        /// </summary>
        [ApiParameterName("account_type")]
        [JsonConverter(typeof(EnumValueStringConverter))]
        public AccountTypeEnum AccountType { get; set; }
        /// <summary>
        /// 外部商户号
        /// </summary>
        [ApiParameterName("client_sn")]
        public string ClientSerialNo { get; set; }
        /// <summary>
        /// 服务商AppID
        /// </summary>
        [ApiParameterName("vendor_app_id")]
        public string ServiceProviderAppID { get; set; }
        /// <summary>
        /// 服务商序列号
        /// </summary>
        [ApiParameterName("vendor_sn")]
        public string ServiceProviderSerialNo { get; set; }
        /// <summary>
        /// 商户组织ID
        /// </summary>
        [ApiParameterName("organization_id")]
        public string MerchantOrganizationID { get; set; }
        [ApiParameterName("user_id")]
        public string MerchantPromoterID { get; set; }
        [ApiParameterName("name")]
        public string Name { get; set; }
        [ApiParameterName("business_name")]
        public string BusinessName { get; set; }
        [ApiParameterName("contact_name")]
        public string ContactPerson { get; set; }
        [ApiParameterName("contact_cellphone")]
        public string ContactCellphone { get; set; }
        [ApiParameterName("industry")]
        public string Industry { get; set; }
        [ApiParameterName("area")]
        public string Area { get; set; }
        [ApiParameterName("street_address")]
        public string Address { get; set; }
        /// <summary>
        /// 门店照片
        /// </summary>
        [ApiParameterName("brand_photo")]
        public string BrandPhoto { get; set; }

        /// <summary>
        /// 室内照片
        /// </summary>
        [ApiParameterName("indoor_photo")]
        public string IndoorPhoto { get; set; }

        /// <summary>
        /// 室外照片
        /// </summary>
        [ApiParameterName("outdoor_photo")]
        public string OutdoorPhoto { get; set; }

        /// <summary>
        /// 其它照片
        /// </summary>
        [ApiParameterName("other_photos")]
        public string OtherPhotos { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [ApiParameterName("remark")]
        public string Remark { get; set; }

        /// <summary>
        /// 经度
        /// </summary>
        [ApiParameterName("longitude")]
        public string Longitude { get; set; }

        /// <summary>
        /// 纬度
        /// </summary>
        [ApiParameterName("latitude")]
        public string Latitude { get; set; }

        /// <summary>
        /// 自定义联系电话(文档显示为微信客服电话)
        /// </summary>
        [ApiParameterName("customer_phone")]
        public string CustomerPhone { get; set; }
        [ApiParameterName("bank_card")]
        public string BankCard { get; set; }
        /// <summary>
        /// 银行卡图片
        /// </summary>
        [ApiParameterName("bank_card_image")]
        public string BankCardImage { get; set; }

        /// <summary>
        /// 银行名称
        /// </summary>
        [ApiParameterName("bank_name")]
        public string BankName { get; set; }

        /// <summary>
        /// 银行所在地区编码
        /// </summary>
        [ApiParameterName("bank_area")]
        public string BankArea { get; set; }

        /// <summary>
        /// 支行名称
        /// </summary>

        [ApiParameterName("branch_name")]
        public string BranchName { get; set; }

        /// <summary>
        /// 银行预留手机号
        /// </summary>

        [ApiParameterName("bank_cellphone")]
        public string BankCellphone { get; set; }

        /// <summary>
        /// 持有人
        /// </summary>

        [ApiParameterName("holder")]
        public string Holder { get; set; }
        /// <summary>
        /// 法人姓名
        /// </summary>
        [ApiParameterName("legal_person_name")]
        public string LegalPersonName { get; set; }

        /// <summary>
        /// 营业执照图片地址
        /// </summary>
        [ApiParameterName("business_license_photo")]
        public string BusinessLicenseImage { get; set; }

        /// <summary>
        /// 工商注册号
        /// </summary>
        [ApiParameterName("tax_payer_id")]
        public string BusinessRegistrationNumber { get; set; }
        /// <summary>
        /// 身份证号
        /// </summary>
        [ApiParameterName("identity")]
        public string IdentityCardID { get; set; }

        /// <summary>
        /// 身份证正面照片
        /// </summary>
        [ApiParameterName("holder_id_front_photo")]
        public string IdentityCardFrontPhoto { get; set; }

        /// <summary>
        /// 身份证背面照片
        /// </summary>
        [ApiParameterName("holder_id_back_photo")]
        public string IdentityCardBackPhoto { get; set; }
    }
}
