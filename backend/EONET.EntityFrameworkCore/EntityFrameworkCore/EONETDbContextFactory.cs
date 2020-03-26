using EONET.EntityFrameworkCore.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;
using System.IO;

namespace EONET.EntityFrameworkCore
{
    public class EONETDbContextFactory : IDesignTimeDbContextFactory<EONETDbContext>
    {

        //TODO:REVIEW HERE.
        public EONETDbContext CreateDbContext(string[] args)
        {
            // Build config
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../EONET.Web.Host"))
                .AddJsonFile("appsettings.json")
                .Build();

            // Get connection string
            var optionsBuilder = new DbContextOptionsBuilder<EONETDbContext>();
            var connectionString = config.GetConnectionString("default");
            
            optionsBuilder.UseSqlServer(connectionString, b => b.MigrationsAssembly("EONET.EntityFrameworkCore"));
         
            return new EONETDbContext(optionsBuilder.Options);
        }
    }
}