using DumplingManager.Data.Configurations;
using DumplingManager.Data.Entities;
using DumplingManager.Data.Extentions;
using Microsoft.EntityFrameworkCore;

namespace DumplingManager.Data.EF
{
    public class DumplingDbContext : DbContext
    {
        public DumplingDbContext(DbContextOptions<DumplingDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlServer("Data Source=.\\sqlserver;Initial Catalog=dumplingmanager;User ID=sa;Password=sa@123;TrustServerCertificate=True;");
                optionsBuilder.UseSqlServer("Data Source=localhost,1433;Initial Catalog=dumplingmanager;User ID=sa;Password=duong*12345678;TrustServerCertificate=True;");
            }
        }

        public override int SaveChanges()
        {
            beforeSave();
            return base.SaveChanges();
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            beforeSave();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            beforeSave();
            return base.SaveChangesAsync(cancellationToken);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            beforeSave();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void beforeSave()
        {
            ChangeTracker.DetectChanges();
            var entities = ChangeTracker.Entries().Where(x => x.State == EntityState.Added || x.State == EntityState.Modified).ToArray();
            if (entities != null)
            {
                foreach (var entity in entities)
                {
                    if (entity.Entity is BaseEntity)
                    {
                        var tmp = entity.Entity as BaseEntity;
                        if (tmp != null)
                        {
                            if (entity.State == EntityState.Added)
                            {
                                tmp.Id = Guid.NewGuid();
                                tmp.Status = 30;
                                tmp.TimeCreated = DateTime.Now;
                                tmp.UserCreatedId = Guid.NewGuid();
                            }
                            else
                            {
                                tmp.TimeModified = DateTime.Now;
                                tmp.UserModifiedId = Guid.NewGuid();
                            }
                        }
                    }
                }
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

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}