namespace Ezreal.ShouQianBa.ApiClient
{
    /// <summary>
    /// 服务商设置
    /// </summary>
    public class ServiceProviderSettings
    {

        /// <summary>
        /// 服务商序列号
        /// </summary>
        public string ServiceProviderSerialNo { get; set; }

        /// <summary>
        /// 服务商Key
        /// </summary>
        public string ServiceProviderKey { get; set; }

        public Sign.ServiceProviderSignSettings CreateServiceProviderSignSettings() => new Sign.ServiceProviderSignSettings()
        {
            ServiceProviderKey = ServiceProviderKey,
            ServiceProviderSerialNo = ServiceProviderSerialNo
        };
    }
}