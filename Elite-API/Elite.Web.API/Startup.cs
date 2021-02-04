using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Elite.Web.API.Database.Providers;
using Elite.Web.API.Database.Repositories;
using Elite.Web.API.Database.Repositories.Interfaces;
using Elite.Web.API.Business.Managers;

namespace Elite.Web.API
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
            services.AddControllers();

            // Register database provider
            services.Add(new ServiceDescriptor(typeof(IDbProvider),
                Elite.Web.API.Database.Providers.DbProviderFactory.GetProvider(DbProviderTypes.MsSql, Configuration.GetConnectionString("Elite"))));

            // Register Managers
            services.AddScoped<AccountManager>();
            services.AddScoped<InsuranceManager>();
            services.AddScoped<BaseManager>();

            // Register Repositories
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<IInsuranceRepository, InsuranceRepository>();
            services.AddScoped<IMakeRepository, MakeRepository>();
            services.AddScoped<IModelRepository, ModelRepository>();
            services.AddScoped<IRegionRepository, RegionRepository>();

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("Elite", new OpenApiInfo
                {
                    Title = "Elite Insurance",
                    Version = "v1.1.0",
                    Contact = new OpenApiContact { Email = "", Name = "Elite Insurance" }
                });
            });

            // Auto Mapper Configurations
            var config = new MapperConfiguration(mp =>
            {
                mp.AddProfile(new Elite.Web.API.Others.Mappers.AutoMapper());
            });
            services.AddSingleton(config.CreateMapper());

            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/Elite/swagger.json", "Elite");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            // enable cors
            app.UseCors(
                option => option
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                );

            //api routing
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action}");
            });
        }
    }
}
