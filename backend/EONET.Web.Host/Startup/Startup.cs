using EONET.EntityFrameworkCore.EntityFrameworkCore;
using EONET.Web.Core.ServiceExtensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EONET.Web.Host
{
    public class Startup
    {
        private const string _defaultCorsPolicyName = "localhost";

        public Startup(IWebHostEnvironment env)
        { }

        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureMvc();

            services.ConfigureSwagger();

            services.ConfigureAutoMapper();

            services.ConfigureDependencyInjectionScope();

            services.ConfigureCors();

            //for migration purposes only
            var configuration = services.BuildServiceProvider().GetRequiredService<IConfiguration>();
            var connectionString = configuration.GetConnectionString("default");
            services.AddDbContext<EONETDbContext>(options => options.UseSqlServer(connectionString));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseCors();

            app.UseStaticFiles();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "EONET API V1"); //Development
                c.RoutePrefix = string.Empty;
            });

            app.UseRouting();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "api/{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
