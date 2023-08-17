using DumplingManager.Data.Configurations;
using DumplingManager.Data.Entities;
using DumplingManager.Data.Extentions;
using Microsoft.EntityFrameworkCore;

namespace DumplingManager.Data.EF
{
    public class DumplingDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlServer("Data Source=.\\sqlserver;Initial Catalog=dumplingmanager;Trusted_Connection=True;TrustServerCertificate=True;");
                optionsBuilder.UseSqlServer("Data Source=localhost,1433;Initial Catalog=dumplingmanager;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new StaffConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new OrderDetailConfiguration());
            modelBuilder.Seed();
        }

        public DbSet<Customer> Customers { get; set;}
        public DbSet<Staff> Staffs { get; set;}
        public DbSet<Product> Products { get; set;}
        public DbSet<Order> Orders { get; set;}
        public DbSet<OrderDetail> OrderDetails { get; set;}
    }
}