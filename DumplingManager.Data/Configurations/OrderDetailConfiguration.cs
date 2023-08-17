using DumplingManager.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DumplingManager.Data.Configurations
{
    internal class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.ToTable("tblOrderDetail");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.OrderId).IsRequired(true);
            builder.Property(x => x.ProductId).IsRequired(true);
            builder.Property(x => x.Quantity).IsRequired(true);

            builder.HasOne(x => x.Order).WithMany(x => x.OrderDetails).HasForeignKey(x => x.OrderId);
            builder.HasOne(x => x.Product).WithMany(x => x.OrderDetails).HasForeignKey(x => x.ProductId);
        }
    }
}