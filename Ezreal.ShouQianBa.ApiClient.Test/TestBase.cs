using System;
using System.Collections.Generic;
using System.Text;

namespace Ezreal.ShouQianBa.ApiClient.Test
{
    public class TestBase
    {
        static TestBase()
        {
            Global.InitializeDefaultConfig(config =>
            {

                config.DefaultShouQianBaServiceProviderSettings = new ServiceProviderSettings()
                {
                    ServiceProviderSerialNo = "@vendor_sn",
                    ServiceProviderKey = "@vendor_key",
                };
                config.UseSandbox = true;
            });
        }
    }




}
