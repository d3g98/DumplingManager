using DumplingManager.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DumplingManager.Data.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("tblOrder");
            builder.AddBaseProperties();
            builder.Property(x => x.Date).IsRequired(true);
            builder.Property(x => x.Name).IsRequired(true);
            builder.Property(x => x.CustomerId).IsRequired(true);

            builder.HasOne(x => x.Staff).WithMany(x => x.Orders).HasForeignKey(x => x.StaffId);
            builder.HasOne(x => x.Customer).WithMany(x => x.Orders).HasForeignKey(x => x.CustomerId);
        }
    }
}