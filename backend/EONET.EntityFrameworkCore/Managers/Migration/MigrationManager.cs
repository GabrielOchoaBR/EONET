using EONET.Domain.Entities;
using EONET.EntityFrameworkCore.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace EONET.Managers.Migration
{
    public static class MigrationManager
    {
        public static IHost MigrateDatabase(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                using (var appContext = scope.ServiceProvider.GetRequiredService<EONETDbContext>())
                {
                    try
                    {
                        appContext.Database.Migrate();
                        
                        appContext.SaveChanges();
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }

            return host;
        }
    }
}
