# 因精力有限，停止维护此repo 【2023-08-07】

#  <img src="https://raw.githubusercontent.com/EzrealJ/ShouQianBa/master/Ezreal.ShouQianBa.ApiClient/WoSaipay.ico" height="25"/>Ezreal.ShouQianBa[![GitHub license](https://img.shields.io/badge/license-MIT-blue.svg)](https://github.com/EzrealJ/ShouQianBa/blob/master/LICENSE)  

* Ezreal.ShouQianBa.ApiClient是一个.NET实现的收钱吧WebApi连接库，旨在让您编写简单且可读性强代码快速接入收钱吧的WebApi
* 同时支持 .NET Framework 4.5/.NET Standard 2.0+
* 您可以直接通过nuget引用项目

## NuGet 依赖项目
#### 所有平台都必须的依赖项

* [WebApiClient.AOT【1.1.4】](https://github.com/dotnetcore/WebApiClient/tree/WebApiClient.JITAOT)
[![GitHub license](https://img.shields.io/badge/license-MIT-blue.svg)](https://github.com/dotnetcore/WebApiClient/blob/master/LICENSE)  
* [Newtonsoft.Json【12.0.1】](https://www.newtonsoft.com/json)
[![GitHub license](https://img.shields.io/badge/license-MIT-blue.svg)](https://licenses.nuget.org/MIT)  

#### 仅.NET Standard需要的依赖项

* [System.Drawing.Common【v4.5.1】](https://www.nuget.org/packages/System.Drawing.Common/)
[![GitHub license](https://img.shields.io/badge/license-MIT-blue.svg)](https://github.com/dotnet/corefx/blob/master/LICENSE.TXT) 

#### 版本状态:

<table>
<tr>
<th>Date</th>
<th>Version</th>
<th>Status</th>
</tr>
<tr>
<td>2019-01-10</td>
<td>0.1.0-preview</td>
<td>release</td>
</tr>
<tr>
<td>2019-01-14</td>
<td>0.1.1-preview</td>
<td>nuget only</td>
</tr>
<tr>
<td>2019-02-15</td>
<td>0.2.1-α</td>
<td>release</td>
</tr>
<tr>
<td>2019-03-27</td>
<td>0.2.1-β</td>
<td>cancel</td>
</tr>
<tr>
<td>2019-04-05</td>
<td>0.2.1</td>
<td>release</td>
</tr>
<tr>
<td>2019-05-15</td>
<td>0.3.0</td>
<td>release</td>
</tr>
<tr>
<td>2020-08-11</td>
<td>0.3.2</td>
<td>release</td>
</tr>
</table>


# 当前仓库代码版本 0.3.2

## 使用前

* 如果您觉得项目对您有帮助，请务必star支持一下
* 项目曾经名为Ezreal.SDK.ShouQianBa,因项目不符合SDK的定位更名为Ezreal.ShouQianBa.ApiClient
* 作者不是收钱吧的开发者,因此有问题请Issues.
* 项目是作者在接入收钱吧WebApi时创建的,.NET下没有相应的库,因此在此贡献出来给大家使用.
* 代码使用MIT协议，您可以按照MIT协议处置代码
* 若您在使用中发现收钱吧方面接口发生变动,请务必在百忙之中联系我。

## 使用-仅针对当前仓库

* 配置

```C#

    ShouQianBaGlobal.InitializeDefaultConfig(config =>
    {
        //若您不是服务商而是从服务商获取了信息来调用支付相关接口，则无需进行此配置
        config.DefaultShouQianBaServiceProviderSettings = new ServiceProviderSettings()
        {
            ServiceProviderSerialNo = @vendor_sn,
            ServiceProviderKey = @vendor_key,
        };
        //不使用沙箱无需配置此项目
        //config.UseSandbox = true;
        //默认配置了收钱吧提供的生产环境Url，如果您的网络环境下请求不可直达该Url,请用代理地址覆盖此项,沙箱环境同理。
        //config.ProductionEnvironmentApiUri = "生产环境Url";
        //若您希望记录日志请开启此项并配置LoggerFactory
        //config.UseLog = true;
    }/*, new LoggerFactory().AddConsole()*/);
```

### 以下演示简单使用,依赖注入请参照Demo项目适当更改代码

* 开始使用

```C#
   BankRequestModel requestModel = new BankRequestModel() { BankCard = bankCardNo };
   var apiInstense = Global.Create<IMerchantContract>();
   var sign = ServiceProviderSignProvider.CreateFromServiceProviderSettings().Sign(requestModel);          
   Response<BankResponseModel> result = await apiInstense.Banks(sign, requestModel);
```

* 当面付示例

```C#
        public static async void PayDemo()
        {

             TerminalSignSettings terminalSignSettings = new TerminalSignSettings()
            {
                TerminalKey = "设备Key(通过设备激活接口获得,或者通过设备签到接口刷新)",
                TerminalSerialNo = "设备序列号(通过设备激活接口获得)"
            };

            //当面付示例
            OrderCreateRequestModel orderCreateRequestModel = new OrderCreateRequestModel();
            orderCreateRequestModel.TerminalSerialNo = terminalSignSettings.TerminalSerialNo;
            orderCreateRequestModel.DeviceID = "设备的唯一编码";
            orderCreateRequestModel.ClientSerialNo = "调用方的订单号";
            orderCreateRequestModel.Operator = "调用方业务关联的操作员";
            orderCreateRequestModel.PayCertificate = "支付凭证,条码支付场景下为条码内容";
            orderCreateRequestModel.Summary = $"扣款{0.01}元";
            orderCreateRequestModel.TotalAmount = 0.01m;
            Response<OrderGenericResponseModel> result = null;
            ShouQianBaOrder shouQianBaOrder = null;
            try
            {
                result = await _wosaipayClient.Pay(orderCreateRequestModel, terminalSignSettings, TimeSpan.FromSeconds(5))
                .Retry(3, TimeSpan.FromSeconds(5))
                .WhenCatch<HttpStatusFailureException>(ex => ex.StatusCode == System.Net.HttpStatusCode.RequestTimeout);
            }
            //与支付宝/微信等支付服务直接提供商相比，此接口的流程存在差异，收钱吧方面这个请求是同步且持续阻塞的
            //当用户未支付时会一直pending，并不会返回等待支付的状态，因此Pay接口的预定义超时时间是50ms
            //一般而言是等待可以直接得到最终的正确结果,但不建议使用此方式，示例仍设定5s超时时间，在其超时后通过轮询的方式轮询最终态来确定结果
            catch (HttpStatusFailureException ex)
            {
                _logger.LogError($"收钱吧服务商支付发起刷卡支付交易在指定时间内返回了Http协议的失败或错误 {ex}");
            }
            catch (HttpApiException ex)
            {
                if (ex.InnerException is TaskCanceledException)
                {
                    //此处消除 主动超时 异常使业务继续
                    _logger.LogInformation($"收钱吧服务商支付发起刷卡支付交易在指定时间没有返回结果，主动取消等待转入轮询");
                }

            }
            catch (Exception ex)
            {
                _logger.LogError($"收钱吧服务商支付发起刷卡支付交易发生了错误 {ex}");
            }
            if (result != null
                && result.ExistsBusinessResponseContent
                && result.BusinessResponseContent.IsEffectiveOrder
                && result.BusinessResponseContent.Order.OrderStatus == OrderStatusEnum.PAID)
            {
                _logger.LogInformation("收钱吧支付成功");
                shouQianBaOrder = result.BusinessResponseContent.Order;
                //直接认为支付成功
            }
            else
            {
                OrderTokenRequestModel orderTokenRequestModel = new OrderTokenRequestModel()
                {
                    TerminalSerialNo = orderCreateRequestModel.TerminalSerialNo,
                    ClientSerialNo = orderCreateRequestModel.ClientSerialNo,
                    //由于Pay接口调用时无法确定拿到结果,因此收钱吧方面的订单号是不确定的,因此不建议使用此值。
                    SerialNo = null
                };
                using (CancellationTokenSource queryTaskCancelTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(120)))
                {
                    try
                    {
                        result = await _wosaipayClient.Query(orderTokenRequestModel, terminalSignSettings, TimeSpan.FromSeconds(5), queryTaskCancelTokenSource.Token)
                        .Retry(60, TimeSpan.FromSeconds(2))//设定轮询等待为2s，轮询不超过30次
                        .WhenCatch<HttpStatusFailureException>(ex => ex.StatusCode == System.Net.HttpStatusCode.RequestTimeout)
                        .WhenResult(response =>
                        {
                            if (!response.ExistsBusinessResponseContent)
                            {
                                return false;//请求异常中止重试
                            }
                            if (!response.BusinessResponseContent.IsEffectiveOrder)
                            {
                                return false;//业务异常中止重试
                            }

                            if (!response.BusinessResponseContent.Order.IsFinalOrderStatus)
                            {
                                return true;
                            }
                            return false;//订单到达最终态中止重试
                        }
                        );
                    }
                    catch (HttpStatusFailureException ex)
                    {
                        _logger.LogError($"收钱吧服务商刷卡支付查询在指定时间内返回了Http协议的失败或错误 {ex}");
                    }
                    catch (HttpApiException ex)
                    {
                        if (ex.InnerException is TaskCanceledException)
                        {
                            //此处消除 主动超时 异常使业务继续
                            _logger.LogInformation($"收钱吧服务商刷卡支付查询在指定时间没有返回结果，主动取消等待转入轮询");
                        }

                    }
                    catch (Exception ex)
                    {
                        _logger.LogError($"收钱吧服务商刷卡支付查询发生了错误 {ex}");
                    }
                    finally
                    {
                        queryTaskCancelTokenSource.Cancel();
                    }
                }


                if (result != null
                    && result.ExistsBusinessResponseContent
                    && result.BusinessResponseContent.IsEffectiveOrder
                    && result.BusinessResponseContent.Order.IsFinalOrderStatus)
                {
                    shouQianBaOrder = result.BusinessResponseContent.Order;
                    if (result.BusinessResponseContent.Order.OrderStatus == OrderStatusEnum.PAID)
                    {
                        _logger.LogInformation("收钱吧轮询到成功");
                        //直接认为支付成功

                    }
                    else
                    {
                        //符合此条件认为轮询到支付失败
                        _logger.LogError("收钱吧订单轮询到失败{0}@{1}-{2}", result.BusinessResponseContent.ResultCode, result.BusinessResponseContent.ErrorCode, result.BusinessResponseContent.ErrorMessage);
                    }

                }
                else
                {
                    //类似查询任务,轮询查询无法得到最终态结果时，需要调用撤单接口

                    using (CancellationTokenSource cancelTaskCancelTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(50)))
                    {

                        try
                        {
                            result = await _wosaipayClient.Cancel(orderTokenRequestModel, terminalSignSettings, TimeSpan.FromSeconds(5), cancelTaskCancelTokenSource.Token)
                            .Retry(30, TimeSpan.FromSeconds(2))//设定轮询等待为2s，轮询不超过30次
                            .WhenCatch<HttpStatusFailureException>(ex => ex.StatusCode == System.Net.HttpStatusCode.RequestTimeout)
                            .WhenResult(response =>
                            {
                                if (!response.ExistsBusinessResponseContent)
                                {
                                    return false;//请求异常中止重试
                                }
                                if (!response.BusinessResponseContent.IsEffectiveOrder)
                                {
                                    return false;//业务异常中止重试
                                }

                                if (!response.BusinessResponseContent.Order.IsFinalOrderStatus)
                                {
                                    //未达最终态继续重试

                                    return true;
                                }
                                return false;//订单到达最终态中止重试
                            }
                            );
                        }

                        catch (HttpStatusFailureException ex)
                        {
                            _logger.LogError($"收钱吧服务商刷卡支付撤单在指定时间内返回了Http协议的失败或错误 {ex}");
                        }
                        catch (HttpApiException ex)
                        {
                            if (ex.InnerException is TaskCanceledException)
                            {
                                //此处消除 主动超时 异常使业务继续
                                _logger.LogInformation($"收钱吧服务商刷卡支付撤单在指定时间没有返回结果，主动取消等待转入轮询");
                            }

                        }
                        catch (Exception ex)
                        {
                            _logger.LogError($"收钱吧服务商支付刷卡支付撤单发生了错误 {ex}");
                        }
                        finally
                        {
                            cancelTaskCancelTokenSource.Cancel();
                        }
                    }
                    //判断撤单结果
                    if (result != null
                    && result.ExistsBusinessResponseContent
                    && result.BusinessResponseContent.IsEffectiveOrder)
                    {
                        _logger.LogInformation("轮询到{0}", result.BusinessResponseContent.Order.OrderStatus);

                    }
                    else
                    {
                        _logger.LogInformation("未轮询到有效内容");
                    }
                }
            }
```

* 更多使用方式尽情期待


# 捐赠

### 如果觉得这个项目不错，请支持Ezreal。Ezreal希望你也参与到.NET开源生态建设中来

# 联系

QQ:997229225
