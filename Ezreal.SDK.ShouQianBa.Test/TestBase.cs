using System;
using System.Collections.Generic;
using System.Text;

namespace Ezreal.SDK.ShouQianBa.Test
{
    public class TestBase
    {
        static TestBase()
        {
            Global.AddDefaultConfig(config =>
            {
                config.DefaultShouQianBaServiceProviderSettings = new ServiceProviderSettings()
                {

                    ServiceProviderSerialNo = "91800129",
                    ServiceProviderKey = "bf6a1021f1e788e8c9affd1f4ae0e982",
                };
                config.UseSandbox = true;
            });
        }
    }




}
