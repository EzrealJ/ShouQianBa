
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




        public static ServiceProviderSignProvider CreateFromServiceProviderSettings(ServiceProviderSettings serviceProviderSettings = null)
        {
            serviceProviderSettings = serviceProviderSettings ?? Global.GlobalConfig.DefaultShouQianBaServiceProviderSettings;
            return new ServiceProviderSignProvider(new ServiceProviderSignSettings()
            {
                ServiceProviderKey = serviceProviderSettings.ServiceProviderKey,
                ServiceProviderSerialNo = serviceProviderSettings.ServiceProviderSerialNo
            });
        }


    }
}
