using Ezreal.ShouQianBa.ApiClient.ApiParameterModels.Request.Merchant;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Ezreal.ShouQianBa.ApiClient.Test.Models
{
    public class ModelTest
    {
        [Fact]
        public void ToApiParameterObject()
        {

            MerchantCreateRequestModel createMerchantRequestModel = new MerchantCreateRequestModel();
            createMerchantRequestModel.CertificateType = Enums.CertificateTypeEnum.IDCard;
            dynamic targetObject = createMerchantRequestModel.ToApiParameterObject();
            Assert.True(targetObject.id_type == 1);

        }

        [Fact]
        public void ToApiParameterJsonString()
        {

            MerchantCreateRequestModel createMerchantRequestModel = new MerchantCreateRequestModel();
            createMerchantRequestModel.CertificateType = Enums.CertificateTypeEnum.IDCard;
            string str = createMerchantRequestModel.ToApiParameterJsonString();
            Assert.NotEmpty(str);

        }

        [Fact]
        public void FormApiParameterJsonString()
        {
            MerchantCreateRequestModel createMerchantRequestModel = new MerchantCreateRequestModel();
            createMerchantRequestModel.CertificateType = Enums.CertificateTypeEnum.IDCard;
            string str = createMerchantRequestModel.ToApiParameterJsonString();
            MerchantCreateRequestModel targetObject = MerchantCreateRequestModel.FormApiParameterJsonString<MerchantCreateRequestModel>(str);
            Assert.True(targetObject.CertificateType == Enums.CertificateTypeEnum.IDCard);

        }

        [Fact]
        public void FromApiParameterObject()
        {
            MerchantCreateRequestModel createMerchantRequestModel = new MerchantCreateRequestModel();
            createMerchantRequestModel.CertificateType = Enums.CertificateTypeEnum.IDCard;
            dynamic obj = createMerchantRequestModel.ToApiParameterObject();

            MerchantCreateRequestModel targetObject = MerchantCreateRequestModel.FromApiParameterObject<MerchantCreateRequestModel>(obj);
            Assert.True(targetObject.CertificateType == Enums.CertificateTypeEnum.IDCard);

        }
    }
}
