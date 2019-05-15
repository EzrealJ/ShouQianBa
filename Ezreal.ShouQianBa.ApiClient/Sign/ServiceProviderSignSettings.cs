using WebApiClient.DataAnnotations;

namespace Ezreal.ShouQianBa.ApiClient.Sign
{
    /// <summary>
    /// 服务商签名配置
    /// </summary>
    public class ServiceProviderSignSettings : ISignSettings
    {
        /// <summary>
        /// 服务商序列号
        /// </summary>
        [IgnoreSerialized] public string ServiceProviderSerialNo { get; set; }

        /// <summary>
        /// 服务商Key
        /// </summary>
        [IgnoreSerialized] public string ServiceProviderKey { get; set; }
        string ISignSettings.SerialNo => this.ServiceProviderSerialNo;
        string ISignSettings.Key => this.ServiceProviderKey;
    }
}