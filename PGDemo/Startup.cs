using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PGDemo.AOP;
using PGDemo.ApiCore.Extensions;
using PGDemo.ApiCore.Extensions.RoutePrefix;
using PGDemo.Log.SeriLog;
using Swashbuckle.AspNetCore.Swagger;
using System;

namespace PGDemo
{
    internal class Startup
    {
        public Startup(IHostingEnvironment evn)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(evn.ContentRootPath)
                .AddJsonFile("appsettings.json", false, true)
                .AddJsonFile($"appsettings.{evn.EnvironmentName}.json", false, true)
                .AddSerilog()
                .AddEnvironmentVariables();
            
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            // 设置Swagger
            services.AddSwaggerGen(options => {
                options.SwaggerDoc("v1", new Info()
                {
                    Version = "v1",
                    Title = "PGDemo API文档"
                });
            });

            // 设置配置信息
            services.SetConfiguration(Configuration);

            var searchPattern = "PGDemo.*.dll";

            // 注册项目中的服务,使用自带IOC框架
            //services.RegisterServices(searchPattern);

            // 跨域设置
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllCors", policy =>
                {
                    policy.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials();
                });
            });

            services.AddMvc(
                options =>
                {
                    options.UseCentralRoutePrefix(new RouteAttribute("api"));
                }).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // 使用Autofac接管自带IOC容器，并注册项目中的服务
            return services.GetAutofacServiceProvider(searchPattern);
        }
        
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseExceptionHandle();

            // log
            app.RegisterSerilog(loggerFactory, Configuration);

            // swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "PGDemo API Doc V1");
                c.DocExpansion(DocExpansion.None);
            });

            // 跨域
            app.UseCors("AllowAllCors");

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
