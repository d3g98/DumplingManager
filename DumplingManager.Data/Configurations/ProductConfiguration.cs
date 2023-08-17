using DumplingManager.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DumplingManager.Data.Configurations
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("tblProduct");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired(true);
            builder.Property(x => x.Price).IsRequired(true);
            builder.Property(x => x.Image).IsRequired(true);
        }
    }
}