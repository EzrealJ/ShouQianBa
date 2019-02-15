using System;
using System.Collections.Generic;
using System.Text;

namespace Ezreal.ShouQianBa.ApiClient.Test
{
    public class TestBase
    {
        static TestBase()
        {
            ShouQianBaGlobal.InitializeDefaultConfig(config =>
            {

                config.DefaultShouQianBaServiceProviderSettings = new ServiceProviderSettings()
                {
                    ServiceProviderSerialNo = string.Empty,
                    ServiceProviderKey = string.Empty,
                };
                config.UseSandbox = true;
            });
        }
    }




}
