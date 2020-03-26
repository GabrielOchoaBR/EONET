using EONET.EntityFrameworkCore.EntityFrameworkCore;
using EONET.Managers.Migration.Seed;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;

namespace EONET.Managers.Migration
{
    public static class DatabaseSeedManager
    {
        public static IHost Seed(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;

                try
                {
                    Task.Run(async () =>
                    {
                        using (var appContext = scope.ServiceProvider.GetRequiredService<EONETDbContext>())
                        {
                            var dataseed = new DataInitializer(appContext);

                            await dataseed.InitializeDataAsync();
                        }

                    }).Wait();

                }
                catch (Exception)
                {
                    throw;
                }
            }
            return host;
        }
    }
}
