using DumplingManager.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DumplingManager.Data.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("tblCustomer");
            builder.AddBaseProperties();
            builder.Property(x => x.Phone).IsRequired(false);
            builder.Property(x => x.Email).IsRequired(false);
            builder.Property(x => x.Address).IsRequired(false);
        }
    }
}