using DumplingManager.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DumplingManager.Data.Configurations
{
    internal class StaffConfiguration : IEntityTypeConfiguration<Staff>
    {
        public void Configure(EntityTypeBuilder<Staff> builder)
        {
            builder.ToTable("tblStaff");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired(true);
        }
    }
}