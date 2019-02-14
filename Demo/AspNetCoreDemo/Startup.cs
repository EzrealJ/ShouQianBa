using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ezreal.ShouQianBa.ApiClient.DependencyInjection;
using Ezreal.ShouQianBa.ApiClient;
using Swashbuckle.AspNetCore.Swagger;
using System.IO;
using Microsoft.Extensions.Logging;
using Ezreal.ShouQianBa.ApiClient.Sign;
using Newtonsoft.Json;

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
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    p => p.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials()
                    .SetPreflightMaxAge(TimeSpan.FromSeconds(60))
                    );
            });
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddShouQianBaApiClient(config =>
            {
                //config.DefaultShouQianBaServiceProviderSettings = new ServiceProviderSettings()
                //{
                //    ServiceProviderSerialNo = "@vendor_sn",
                //    ServiceProviderKey = "@vendor_key",
                //};
                //config.UseSandbox = true;


            }, new LoggerFactory().AddConsole());
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
            app.UseCors("AllowAll");
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
        }
    }
}
