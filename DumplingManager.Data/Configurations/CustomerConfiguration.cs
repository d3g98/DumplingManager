using DumplingManager.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DumplingManager.Data.Configurations
{
    internal class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("tblCustomer");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired(true);
        }
    }
}