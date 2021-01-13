using Ezreal.ShouQianBa.ApiClient.Attributes;
using Ezreal.ShouQianBa.ApiClient.Enums;
using Ezreal.ShouQianBa.ApiClient.ApiModels.Generic;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Ezreal.ShouQianBa.ApiClient.Converters;

namespace Ezreal.ShouQianBa.ApiClient.ApiModels.Request.Merchant
{
    /// <summary>
    /// 商户入网接口请求模型
    /// <para>
    /// https://doc.shouqianba.com/zh-cn/api/interface/merchantCreate.html
    /// </para>
    /// </summary>
    public class MerchantCreateRequestModel : RequestModel
    {
        /// <summary>
        /// *证件类型
        /// </summary>
        [ApiParameterName("id_type")]
        [JsonConverter(typeof(EnumValueStringConverter))]
        public CertificateTypeEnum CertificateType { get; set; }
        /// <summary>
        /// 扩展信息
        /// <para>json格式存储的其他字段</para>
        /// <para>[**此处传递对象即可,发起请求时会序列化为json]</para>
        /// </summary>
        [ApiParameterName("extra")]
        public dynamic Extra { get; set; }
        /// <summary>
        /// 是否主动创建商户
        /// <para>默认(true)创建商户账号，传false则不创建账号</para>
        /// </summary>
        [ApiParameterName("create_account")]
        public bool ProactiveCreateAccount { get; set; } = true;
        /// <summary>
        /// *账户类型
        /// </summary>
        [ApiParameterName("account_type")]
        [JsonConverter(typeof(EnumValueStringConverter))]
        public AccountTypeEnum AccountType { get; set; }
        /// <summary>
        /// 外部商户号
        /// <para>外部商户号，可以根据此商户号查询商户信息</para>
        /// </summary>
        [ApiParameterName("client_sn")]
        public string ClientSerialNo { get; set; }
        /// <summary>
        /// *服务商AppID
        /// <para>收钱吧提供的服务商appid</para>
        /// </summary>
        [ApiParameterName("vendor_app_id")]
        public string ServiceProviderAppID { get; set; }
        /// <summary>
        /// *服务商序列号
        /// <para>收钱吧提供的服务商sn</para>
        /// </summary>
        [ApiParameterName("vendor_sn")]
        public string ServiceProviderSerialNo { get; set; }
        /// <summary>
        /// 组织
        /// <para>收钱吧提供的商户所属组织id</para>
        /// </summary>
        [ApiParameterName("organization_id")]
        public string MerchantOrganizationID { get; set; }
        /// <summary>
        /// 推广者
        /// <para>收钱吧提供的商户推广人id</para>
        /// </summary>
        [ApiParameterName("user_id")]
        public string MerchantPromoterID { get; set; }
        /// <summary>
        /// *商户名
        /// <para>至少有一个汉字</para>
        /// </summary>
        [ApiParameterName("name")]
        public string Name { get; set; }
        /// <summary>
        /// 商户经营名称
        /// <para>非必须 至少有一个汉字，商家实际在经营场所使用的名称，默认和商户名一样</para>
        /// </summary>
        [ApiParameterName("business_name")]
        public string BusinessName { get; set; }
        /// <summary>
        /// *联系人
        /// </summary>
        [ApiParameterName("contact_name")]
        public string ContactPerson { get; set; }
        /// <summary>
        /// *联系电话
        /// </summary>
        [ApiParameterName("contact_cellphone")]
        public string ContactCellphone { get; set; }
        /// <summary>
        /// 行业
        /// </summary>
        [ApiParameterName("industry")]
        public string Industry { get; set; }
        /// <summary>
        /// *地区
        /// </summary>
        [ApiParameterName("area")]
        public string Area { get; set; }
        /// <summary>
        /// *详细地址
        /// </summary>
        [ApiParameterName("street_address")]
        public string Address { get; set; }
        /// <summary>
        /// *门头照片
        /// </summary>
        [ApiParameterName("brand_photo")]
        public string BrandPhoto { get; set; }

        /// <summary>
        /// *室内照片
        /// </summary>
        [ApiParameterName("indoor_photo")]
        public string IndoorPhoto { get; set; }

        /// <summary>
        /// *室外照片
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
        /// 自定义联系电话
        /// <para>为空则取联系电话</para>
        /// </summary>
        [ApiParameterName("customer_phone")]
        public string CustomerPhone { get; set; }
        /// <summary>
        /// *银行卡号
        /// </summary>
        [ApiParameterName("bank_card")]
        public string BankCard { get; set; }
        /// <summary>
        /// *银行卡图片
        /// <para>必须传真实的银行卡照片，需要跟银行卡号匹配</para>
        /// </summary>
        [ApiParameterName("bank_card_image")]
        public string BankCardImage { get; set; }

        /// <summary>
        /// *开户银行
        /// </summary>
        [ApiParameterName("bank_name")]
        public string BankName { get; set; }

        /// <summary>
        /// *开户银行所在地区编码
        /// </summary>
        [ApiParameterName("bank_area")]
        public string BankArea { get; set; }

        /// <summary>
        /// *开户支行名称
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
        /// <para>个人账户为开户人，企业账户为开户公司名</para>
        /// </summary>

        [ApiParameterName("holder")]
        public string Holder { get; set; }
        /// <summary>
        /// 法人姓名
        /// <para>企业账户必须</para>
        /// </summary>
        [ApiParameterName("legal_person_name")]
        public string LegalPersonName { get; set; }

        /// <summary>
        /// 营业执照图片地址
        /// <para>企业账户必须</para>
        /// </summary>
        [ApiParameterName("business_license_photo")]
        public string BusinessLicenseImage { get; set; }

        /// <summary>
        /// 工商注册号
        /// <para>企业账户必须</para>
        /// </summary>
        [ApiParameterName("tax_payer_id")]
        public string BusinessRegistrationNumber { get; set; }
        /// <summary>
        /// *身份证号
        /// </summary>
        [ApiParameterName("identity")]
        public string IdentityCardID { get; set; }

        /// <summary>
        /// *身份证正面照片
        /// <para>必须传真实的身份证照片，且身份证信息需要和开户姓名和身份证号匹配</para>
        /// <para>[***此处接口定义存在问题,根据相关法律法规,中国居民身份证的正面是指国徽面，为了成功调用接口，仍要上传人像面]</para>
        /// </summary>
        [ApiParameterName("holder_id_front_photo")]
        public string IdentityCardFrontPhoto { get; set; }

        /// <summary>
        /// *身份证背面照片
        /// <para>必须传真实的身份证照片，且身份证有效期限不能过期</para>
        /// <para>[***此处接口定义存在问题,根据相关法律法规,中国居民身份证的反面是指人像面，为了成功调用接口，仍要上传国徽面]</para>
        /// </summary>
        [ApiParameterName("holder_id_back_photo")]
        public string IdentityCardBackPhoto { get; set; }
    }
}
