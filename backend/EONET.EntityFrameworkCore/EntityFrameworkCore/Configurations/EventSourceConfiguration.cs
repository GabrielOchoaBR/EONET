using EONET.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EONET.EntityFrameworkCore.EntityFrameworkCore.Configurations
{
    internal class EventSourceConfiguration : IEntityTypeConfiguration<EventSource>
    {
        public void Configure(EntityTypeBuilder<EventSource> builder)
        {
            builder.HasKey(e => new { e.EventId, e.SourceId });

            builder
                .HasOne(pt => pt.Event)
                .WithMany(p => p.sources)
                .HasForeignKey(pt => pt.EventId);

            builder
                .HasOne(pt => pt.Source)
                .WithMany(t => t.Events)
                .HasForeignKey(pt => pt.SourceId);
        }
    }
}