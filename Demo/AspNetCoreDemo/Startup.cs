﻿using System;
using System.IO;
using Ezreal.ShouQianBa.ApiClient.Sign;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Swagger;
using Ezreal.ShouQianBa.ApiClient.Extension;
using Ezreal.ShouQianBa.ApiClient;

namespace AspNetCoreDemo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            ApplicationPath = Path.GetDirectoryName(typeof(Program).Assembly.Location);//获取应用程序所在目录（绝对，不受工作目录影响，建议采用此方法获取路径）
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        /// <summary>
        /// 应用程序所在目录
        /// </summary>
        static public string ApplicationPath { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddShouqianbaApiClient();
            services.AddTransient(serviceProvider =>
            {
                string path = Path.Combine(ApplicationPath, "TerminalSignSettings.json");
                if (File.Exists(path))
                {
                    return JsonConvert.DeserializeObject<TerminalSignSettings>(File.ReadAllText(path));
                }
                return new TerminalSignSettings();
            });
            //注册Swagger生成器，定义一个和多个Swagger 文档
            services.AddSwaggerGen(option =>
            {

                option.SwaggerDoc("Ezreal", new Info
                {
                    Version = "v1",
                    Title = "Ezreal.ShouQianBa.ApiClient Webapi Demo",
                    Description = "Ezreal.ShouQianBa.ApiClient Webapi Demo",
                    Contact = new Contact
                    {
                        Name = "Ezreal",
                        Email = string.Empty,
                    }
                });
                // 为 Swagger JSON and UI设置xml文档注释路径

                string xmlPath = Path.Combine(ApplicationPath, $"{AppDomain.CurrentDomain.FriendlyName}.xml");
                option.IncludeXmlComments(xmlPath);

            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            //启用中间件服务生成Swagger作为JSON终结点
            app.UseSwagger();
            //启用中间件服务对swagger-ui，指定Swagger JSON终结点
            app.UseSwaggerUI(option =>
            {
                option.SwaggerEndpoint("/swagger/Ezreal/swagger.json", "Ezreal");
            });

            var shouqianbaGlobalConfig = app.ApplicationServices.GetRequiredService<ShouQianBaGlobalConfig>();
            shouqianbaGlobalConfig.UseLog = true;
            shouqianbaGlobalConfig.DefaultShouQianBaServiceProviderSettings = new ServiceProviderSettings()
            {
                //由于收钱吧封闭了代理商Api开户，事实上现在服务商参数只有在激活设备的时候需要用到了,激活设备的接口可以显式传入，因此无需提前配置
                //非要配置目前也还能用,后续会删除这个
            };
        }
    }
}
