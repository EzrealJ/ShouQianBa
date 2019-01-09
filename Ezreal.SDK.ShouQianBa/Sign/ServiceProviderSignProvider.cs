using System;
using System.Collections.Generic;
using System.Text;

namespace Ezreal.SDK.ShouQianBa.Sign
{
    public class ServiceProviderSignProvider<TRequestParameterModel> : SignProvider where TRequestParameterModel : ApiParameterModels.Request.RequestModel
    {
        public ServiceProviderSignProvider()
        {
        }

        public ServiceProviderSignProvider(TRequestParameterModel requestParameterModel)
        {
            if (requestParameterModel == null)
            {
                throw new ArgumentNullException(nameof(requestParameterModel));
            }
            this.SerialNo = Global.GlobalConfig.DefaultShouQianBaServiceProviderSettings.ServiceProviderSerialNo;
            this.Sign(requestParameterModel, Global.GlobalConfig.DefaultShouQianBaServiceProviderSettings.ServiceProviderKey);
        }

        public ServiceProviderSignProvider(TRequestParameterModel requestParameterModel, ServiceProviderSettings serviceProviderSettings)
        {
            if (requestParameterModel == null)
            {
                throw new ArgumentNullException(nameof(requestParameterModel));
            }

            if (serviceProviderSettings == null)
            {
                throw new ArgumentNullException(nameof(serviceProviderSettings));
            }
            this.SerialNo = serviceProviderSettings.ServiceProviderSerialNo;
            this.Sign(requestParameterModel, serviceProviderSettings.ServiceProviderKey);
        }

        public ServiceProviderSignProvider(TRequestParameterModel requestParameterModel, string serviceProviderSerialNo, string serviceProviderKey)
        {
            if (requestParameterModel == null)
            {
                throw new ArgumentNullException(nameof(requestParameterModel));
            }

            if (string.IsNullOrWhiteSpace(serviceProviderSerialNo))
            {
                throw new ArgumentException("message", nameof(serviceProviderSerialNo));
            }

            if (string.IsNullOrWhiteSpace(serviceProviderKey))
            {
                throw new ArgumentException("message", nameof(serviceProviderKey));
            }
            this.SerialNo = serviceProviderSerialNo;
            this.Sign(requestParameterModel, serviceProviderKey);
        }


    }
}
