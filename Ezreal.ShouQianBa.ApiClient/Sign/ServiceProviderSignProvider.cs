
using System;
using System.Collections.Generic;
using System.Text;

namespace Ezreal.ShouQianBa.ApiClient.Sign
{
    /// <summary>
    /// 服务商签名提供者
    /// </summary>
    public class ServiceProviderSignProvider : SignProvider
    {

        public ServiceProviderSignSettings ServiceProviderSignSetting
        {
            get
            {
                return new ServiceProviderSignSettings() { ServiceProviderKey = this.Key, ServiceProviderSerialNo = this.SerialNo };
            }
            set
            {
                this.SerialNo = value.ServiceProviderSerialNo;
                this.Key = value.ServiceProviderKey;

            }
        }

        public ServiceProviderSignProvider(ServiceProviderSignSettings serviceProviderSignSetting)
        {
            ServiceProviderSignSetting = serviceProviderSignSetting;
        }



        public new Sign<ServiceProviderSignProvider, TRequestParameterModel> Sign<TRequestParameterModel>(TRequestParameterModel requestParameterModel) where TRequestParameterModel : IServiceSignable
        {
            if (requestParameterModel == null)
            {
                throw new ArgumentNullException(nameof(requestParameterModel));
            }
            return new Sign<ServiceProviderSignProvider, TRequestParameterModel>()
            {
                SerialNo = this.SerialNo,
                SignContent = this.GetSignContent(requestParameterModel),
                DataObject = requestParameterModel,
                SignProvider = this
            };
        }

        public Sign<ServiceProviderSignProvider, TRequestParameterModel> Sign<TRequestParameterModel>(TRequestParameterModel requestParameterModel, ServiceProviderSignSettings serviceProviderSignSetting) where TRequestParameterModel : IServiceSignable
        {
            this.ServiceProviderSignSetting = serviceProviderSignSetting;
            return this.Sign(requestParameterModel);

        }

        public Sign<ServiceProviderSignProvider, TRequestParameterModel> Sign<TRequestParameterModel>(TRequestParameterModel requestParameterModel, string serviceProviderSerialNo, string serviceProviderKey) where TRequestParameterModel : IServiceSignable
        {


            if (string.IsNullOrWhiteSpace(serviceProviderSerialNo))
            {
                throw new ArgumentException("message", nameof(serviceProviderSerialNo));
            }

            if (string.IsNullOrWhiteSpace(serviceProviderKey))
            {
                throw new ArgumentException("message", nameof(serviceProviderKey));
            }

            this.SerialNo = serviceProviderSerialNo;
            this.Key = serviceProviderKey;
            return this.Sign(requestParameterModel);
        }



        /// <summary>
        /// 使用收钱吧服务商配置来创建一个服务商签名提供程序
        /// </summary>
        /// <param name="serviceProviderSettings">给定此参数时，使用给定值来创建服务商签名提供程序，否则使用默认的收钱吧服务商配置</param>
        /// <returns></returns>
        public static ServiceProviderSignProvider CreateFromServiceProviderSettings(ServiceProviderSettings serviceProviderSettings = null)
        {
            serviceProviderSettings = serviceProviderSettings ?? ShouQianBaGlobal.GlobalConfig.DefaultShouQianBaServiceProviderSettings;
            return new ServiceProviderSignProvider(new ServiceProviderSignSettings()
            {
                ServiceProviderKey = serviceProviderSettings.ServiceProviderKey,
                ServiceProviderSerialNo = serviceProviderSettings.ServiceProviderSerialNo
            });
        }


    }
}
