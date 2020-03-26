using EONET.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EONET.EntityFrameworkCore.EntityFrameworkCore.Configurations
{
    internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.id);

            builder.Property(x => x.id).ValueGeneratedNever();
        }
    }
}