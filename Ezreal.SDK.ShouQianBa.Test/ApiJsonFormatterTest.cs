using Ezreal.SDK.ShouQianBa.ApiParameterModels.Request.Merchant;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Ezreal.SDK.ShouQianBa.Test
{
    public class ApiJsonFormatterTest
    {
        [Fact]
        public void IgnoreNullValue()
        {
            BankBranchesRequestModel requestModel = new BankBranchesRequestModel() { BankArea = "123456" };
            ApiJsonFormatter apiJsonFormatter = new ApiJsonFormatter();
            string str = apiJsonFormatter.Serialize(requestModel, null);
            Assert.DoesNotContain("\"bank_name\"", str);
            Assert.Contains("\"bank_area\"", str);
        }

    }
}
