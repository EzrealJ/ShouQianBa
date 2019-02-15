using Ezreal.ShouQianBa.ApiClient.ApiParameterModels.Request.Merchant;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Ezreal.ShouQianBa.ApiClient.Test
{
    public class ApiJsonFormatterTest
    {
        [Fact]
        public void Serialize_RequestModel_ReturnsIgnoreNullValueJsonString()
        {
            BankBranchesRequestModel requestModel = new BankBranchesRequestModel() { BankArea = "123456" };
            ApiJsonFormatter apiJsonFormatter = new ApiJsonFormatter();
            string str = apiJsonFormatter.Serialize(requestModel, null);
            Assert.DoesNotContain("\"bank_name\"", str);
            Assert.Contains("\"bank_area\"", str);
        }

    }
}
