# Ezreal.ShouqianBa
* Ezreal.ShouqianBa.ApiClient是一个.NET实现的收钱吧WebApi连接库，旨在让您编写简单且可读性强代码快速接入收钱吧的WebApi
* 同时支持 .NET Framework 4.5/.NET Standard 2.0+

## 使用前
* 项目曾经名为Ezreal.SDK.ShouQianBa,因项目不符合SDK的定位更名为Ezreal.ShouqianBa.ApiClient
* 作者不是收钱吧的开发者,因此有问题请Issues.
* 项目是作者在接入收钱吧WebApi时创建的,.NET下没有相应的库,因此在此贡献出来给大家使用.
* 代码使用MIT协议，您可以按照MIT协议处置代码
* 若您在使用中发现收钱吧方面接口发生变动,请务必在百忙之中联系我。

## 使用-仅针对当前仓库
* 目前暂未添加DI的支持,当前使用简单的方式开始使用

* 配置
```C#
    //这是收钱吧方面提供的测试环境的信息，但使用范围是有限的 大多数接口都需要在生产环境调试
    Global.InitializeDefaultConfig(config =>
    {
        config.DefaultShouQianBaServiceProviderSettings = new ServiceProviderSettings()
        {
            ServiceProviderSerialNo = "@vendor_sn",
            ServiceProviderKey = "@vendor_key",
        };
        config.UseSandbox = true;
    });
```
* 开始使用
```C#
   BankRequestModel requestModel = new BankRequestModel() { BankCard = bankCardNo };
   var apiInstense = Global.Create<IMerchantContract>();
   var sign = ServiceProviderSignProvider.CreateFromServiceProviderSettings().Sign(requestModel);          
   Response<BankResponseModel> result = await apiInstense.Banks(sign, requestModel);
```
* 更多使用方式尽情期待
## 下一步计划:添加DI支持