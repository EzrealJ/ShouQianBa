using Ezreal.ShouQianBa.ApiClient.ApiParameterModels.Request.Merchant;
using Ezreal.ShouQianBa.ApiClient.ApiParameterModels.Response;
using Ezreal.ShouQianBa.ApiClient.ApiParameterModels.Response.Merchant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiClient;
using Ezreal.ShouQianBa.ApiClient.Sign;
using System.Threading;
using Ezreal.ShouQianBa.ApiClient.ApiContract;
using Ezreal.ShouQianBa.ApiClient.Extension;

namespace Ezreal.ShouQianBa.ApiClient.Api
{
    public class MerchantClient
    {
        public MerchantClient(IMerchantContract merchantContract)
        {
            MerchantContract = merchantContract ?? HttpApiFactory.Create<IMerchantContract>();
        }

        public IMerchantContract MerchantContract { get; }

        public ITask<Response<MerchantCreateResponseModel>> Create(MerchantCreateRequestModel requestModel, ServiceProviderSignSettings serviceProviderSignSettings = null, TimeSpan? timeout = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return MerchantContract.Create(requestModel.SignByServiceProviderSignProvider(serviceProviderSignSettings), requestModel, timeout==null?null:new WebApiClient.Parameterables.Timeout(timeout.Value), cancellationToken);
        }
        public ITask<Response<MerchantInfoResponseModel>> Info(MerchantInfoRequestModel requestModel, ServiceProviderSignSettings serviceProviderSignSettings = null, TimeSpan? timeout = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return MerchantContract.Info(requestModel.SignByServiceProviderSignProvider(serviceProviderSignSettings), requestModel, timeout==null?null:new WebApiClient.Parameterables.Timeout(timeout.Value), cancellationToken);
        }
        public ITask<Response<MerchantCloseResponseModel>> Close(MerchantCloseRequestModel requestModel, ServiceProviderSignSettings serviceProviderSignSettings = null, TimeSpan? timeout = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return MerchantContract.Close(requestModel.SignByServiceProviderSignProvider(serviceProviderSignSettings), requestModel, timeout==null?null:new WebApiClient.Parameterables.Timeout(timeout.Value), cancellationToken);
        }
        public ITask<Response<BankResponseModel>> Banks(BankRequestModel requestModel, ServiceProviderSignSettings serviceProviderSignSettings = null, TimeSpan? timeout = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return MerchantContract.Banks(requestModel.SignByServiceProviderSignProvider(serviceProviderSignSettings), requestModel, timeout==null?null:new WebApiClient.Parameterables.Timeout(timeout.Value), cancellationToken);
        }
        public ITask<Response<BankBranchesResponseModel>> BankBranches(BankBranchesRequestModel requestModel, ServiceProviderSignSettings serviceProviderSignSettings = null, TimeSpan? timeout = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return MerchantContract.BankBranches(requestModel.SignByServiceProviderSignProvider(serviceProviderSignSettings), requestModel, timeout==null?null:new WebApiClient.Parameterables.Timeout(timeout.Value), cancellationToken);
        }
        public ITask<Response<PubBankResponseModel>> PubBank(PubBankRequestModel requestModel, ServiceProviderSignSettings serviceProviderSignSettings = null, TimeSpan? timeout = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return MerchantContract.PubBank(requestModel.SignByServiceProviderSignProvider(serviceProviderSignSettings), requestModel, timeout==null?null:new WebApiClient.Parameterables.Timeout(timeout.Value), cancellationToken);
        }
        public ITask<Response<ImageUploadResponseModel>> ImageUpload(ImageUploadRequestModel requestModel, ServiceProviderSignSettings serviceProviderSignSettings = null, TimeSpan? timeout = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return MerchantContract.ImageUpload(requestModel.SignByServiceProviderSignProvider(serviceProviderSignSettings), requestModel, timeout==null?null:new WebApiClient.Parameterables.Timeout(timeout.Value), cancellationToken);
        }




    }
}
