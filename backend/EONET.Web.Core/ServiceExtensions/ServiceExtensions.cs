using AutoMapper;
using EONET.Application.Events;
using EONET.Domain.Entities;
using EONET.Managers.Base;
using EONET.Managers.Events;
using EONET.Web.Core.AutoMapper;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace EONET.Web.Core.ServiceExtensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "EONET - SAMPLE",
                    Description = "Earth Observatory Natural Events Tracker - SAMPLE"
                });
            });
        }

        public static void ConfigureMvc(this IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Latest);
        }

        public static void ConfigureAutoMapper(this IServiceCollection services)
        {
            // Auto Mapper Configurations
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();

            services.AddSingleton(mapper);
        }

        public static void ConfigureDependencyInjectionScope(this IServiceCollection services)
        {
            services.AddScoped<IEventAppService, EventAppService>();

            services.AddScoped<IEventManager, EventManager>();
            services.AddScoped<IManagerBase<Event, string>, EventManager>();
        }
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(opt =>
            {
                var policyBuilder = new CorsPolicyBuilder(new string[] { });
                var openPolicy = policyBuilder.AllowAnyOrigin()
                                            .AllowAnyHeader()
                                            .AllowAnyMethod()
                                            .WithExposedHeaders("Content-Disposition")
                                            .Build();

                opt.AddDefaultPolicy(openPolicy);
            });
        }

    }
}
