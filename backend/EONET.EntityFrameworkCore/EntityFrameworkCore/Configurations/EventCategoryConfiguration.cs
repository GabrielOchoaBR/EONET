using EONET.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EONET.EntityFrameworkCore.EntityFrameworkCore.Configurations
{
    internal class EventCategoryConfiguration : IEntityTypeConfiguration<EventCategory>
    {
        public void Configure(EntityTypeBuilder<EventCategory> builder)
        {
            builder.HasKey(e => new { e.EventId, e.CategoryId });

            builder
                .HasOne(pt => pt.Event)
                .WithMany(p => p.categories)
                .HasForeignKey(pt => pt.EventId);

            builder
                .HasOne(pt => pt.Category)
                .WithMany(t => t.Events)
                .HasForeignKey(pt => pt.CategoryId);
        }
    }
}