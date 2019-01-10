# Ezreal.SDK.ShouQianBa
[![GitHub license](https://img.shields.io/badge/license-MIT-blue.svg)](https://github.com/EzrealJ/ShouQianBa/blob/master/LICENSE)  
This project is a simple library for ShouQianBa (WosaiPay) WebApi which based cross platform framework for .NET Standard and .NET Framework 4.5.  

## NuGet Dependencies
#### All platform framework required
* [WebApiClient.AOT【0.3.0】](https://github.com/dotnetcore/WebApiClient)
[![GitHub license](https://img.shields.io/badge/license-MIT-blue.svg)](https://github.com/dotnetcore/WebApiClient/blob/master/LICENSE)  
* [Newtonsoft.Json【12.0.1】](https://www.newtonsoft.com/json)
[![GitHub license](https://img.shields.io/badge/license-MIT-blue.svg)](https://licenses.nuget.org/MIT)  
#### .NET Standard only
* [System.Drawing.Common【v4.5.1】](https://www.newtonsoft.com/json)
[![GitHub license](https://img.shields.io/badge/license-MIT-blue.svg)](https://licenses.nuget.org/MIT) 


#### Package Manager
```shell
Install-Package Ezreal.SDK.ShouQianBa -Version 0.1.0-preview
```
#### .NET CLI
```bash
dotnet add package Ezreal.SDK.ShouQianBa --version 0.1.0-preview
```

## Use:
* Add initialized code before use
```C#
Global.AddDefaultConfig(config =>
{
    config.DefaultShouQianBaServiceProviderSettings = new ServiceProviderSettings()
    {
        ServiceProviderSerialNo = "@vendor_sn",
        ServiceProviderKey = "@vendor_key",
    };
    config.UseSandbox = true;
});

```
* Next (You can refer to the [WebApiClient](https://github.com/dotnetcore/WebApiClient))
```C#
 var apiInstense = Global.Create<IMerchantContract>();
 BankRequestModel bankRequestModel = new BankRequestModel() { BankCard = "@bankCardID" };
 ServiceProviderSignProvider<BankRequestModel> serviceProviderSigner = new ServiceProviderSignProvider<BankRequestModel>(bankRequestModel);
 Response<BankResponseModel> result = null;
 Task.Run(async () =>
 {
     try
     {
         result = await apiInstense.Banks(serviceProviderSigner, bankRequestModel);
     }
     catch (HttpStatusFailureException ex)
     {

     }
     catch (System.Net.Http.HttpRequestException ex)
     {
         throw ex;
     }
 });


``` 

