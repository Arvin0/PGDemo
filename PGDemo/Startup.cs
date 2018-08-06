using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PGDemo.ApiCore.Extensions;
using Swashbuckle.AspNetCore.Swagger;

namespace PGDemo
{
    internal class Startup
    {
        public Startup(IHostingEnvironment evn)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(evn.ContentRootPath)
                .AddJsonFile("appsettings.json", false, true)
                .AddJsonFile($"appsettings.{evn.EnvironmentName}.json", true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(options => {
                options.SwaggerDoc("v1", new Info()
                {
                    Version = "v1",
                    Title = "PGDemo API文档"
                });
            });

            services.SetConfiguration(Configuration);
            services.RegisterServices("PGDemo.*.dll");

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
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
                app.UseHsts();
            }
            
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "PGDemo API Doc V1");
                c.DocExpansion(DocExpansion.None);
            });

            app.UseExceptionHandle();

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
