using EONET.Domain.Entities;
using EONET.EntityFrameworkCore.EntityFrameworkCore.Configurations;
using Microsoft.EntityFrameworkCore;

namespace EONET.EntityFrameworkCore.EntityFrameworkCore
{
    public class EONETDbContext : DbContext
    {
        public EONETDbContext(DbContextOptions options) : base(options)
        { }

        DbSet<Category> Category { get; set; }
        DbSet<Event> Event { get; set; }
        DbSet<Geometry> Geometry { get; set; }
        DbSet<Source> Source { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.EnableSensitiveDataLogging().UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new EventConfiguration());
            builder.ApplyConfiguration(new EventCategoryConfiguration());
            builder.ApplyConfiguration(new EventSourceConfiguration());

            builder.ApplyConfiguration(new CategoryConfiguration());
            builder.ApplyConfiguration(new SourceConfiguration());

            builder.ApplyConfiguration(new GeometryConfiguration());
        }
    }
}
