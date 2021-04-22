using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxApp.Interfaces;
using TaxApp.Services;

namespace TaxApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddHttpContextAccessor();
            services.AddHttpClient();
            services.AddSingleton<IAPILibrary,APILibrary>();
            services.AddSingleton<DataLib.Interface.IDataBaseInterface, DataLib.Processor.Logic>();
            services
                .AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("1.0.0", new Microsoft.OpenApi.Models.OpenApiInfo
                    {
                        Version = "1.0.0",
                        Title = "TaxApp API implementation",
                        Description = "TaxApp API implementation",
                        Contact = new Microsoft.OpenApi.Models.OpenApiContact()
                        {
                            Name = "TaxApp API Support",
                            Url = new Uri("http://www.SomeGreateTaxApp.co.za"),
                            Email = "servicedesk@SomeGreateTaxApp.co.za"
                        },
                    });
                    
                    //c.CustomSchemaIds(type => type.FullName);
                    //c.IncludeXmlComments($"{AppContext.BaseDirectory}{Path.DirectorySeparatorChar}{_hostingEnv.ApplicationName}.xml");
                    //c.OperationFilter<GeneratePathParamsValidationFilter>();
                    //c.OperationFilter<Filters.SecurityRequirementsOperationFilter>();
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger(c =>
                { c.SerializeAsV2 = true; });
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("1.0.0/swagger.json", "taxApp API implementation");
                    c.EnableFilter();
                });
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
               // endpoints.MapControllers();
            });
        }
    }
}
