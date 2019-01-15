using Ezreal.ShouQianBa.ApiClient.ApiParameterModels.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ezreal.ShouQianBa.ApiClient.Sign
{
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



        public ServiceProviderSignProvider Sign<TRequestParameterModel>(TRequestParameterModel requestParameterModel) where TRequestParameterModel : RequestModel
        {
            if (requestParameterModel == null)
            {
                throw new ArgumentNullException(nameof(requestParameterModel));
            }
            base.Sign(requestParameterModel);
            return this;
        }

        public ServiceProviderSignProvider Sign<TRequestParameterModel>(TRequestParameterModel requestParameterModel, ServiceProviderSignSettings serviceProviderSignSetting) where TRequestParameterModel : RequestModel
        {
            this.ServiceProviderSignSetting = serviceProviderSignSetting;
            this.Sign(requestParameterModel);
            return this;
        }

        public ServiceProviderSignProvider Sign<TRequestParameterModel>(TRequestParameterModel requestParameterModel, string serviceProviderSerialNo, string serviceProviderKey) where TRequestParameterModel : RequestModel
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
            this.Sign(requestParameterModel);
            return this;
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
