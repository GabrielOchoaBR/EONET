using EONET.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EONET.EntityFrameworkCore.EntityFrameworkCore.Configurations
{
    internal class GeometryConfiguration : IEntityTypeConfiguration<Geometry>
    {
        public void Configure(EntityTypeBuilder<Geometry> builder)
        {
            builder.HasKey(x => x.id);

            builder.HasOne(x => x.Event)
                .WithMany(x => x.geometries)
                .HasForeignKey(x => x.EventId);
        }
    }
}