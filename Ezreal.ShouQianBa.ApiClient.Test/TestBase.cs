using System;
using System.Collections.Generic;
using System.Text;

namespace Ezreal.ShouQianBa.ApiClient.Test
{
    public class TestBase
    {
        static TestBase()
        {
            //这是收钱吧方面提供的测试环境的信息，但使用范围是有限的 大多数接口都需要在生产环境调试
            Global.InitializeDefaultConfig(config =>
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
