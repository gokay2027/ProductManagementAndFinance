using Entities.ConcreteEntity;
using Microsoft.EntityFrameworkCore;
using ProductManagementAndFinanceData.Configurations;

namespace ProductManagementAndFinanceData
{
    public class ProductManagementAndFinanceContext : DbContext
    {
        public ProductManagementAndFinanceContext()
        {
        }

        public ProductManagementAndFinanceContext(DbContextOptions<ProductManagementAndFinanceContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Finance> Finances { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Storage> Storages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ProductManagementAndFinance;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // add your own configuration here
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new StorageConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new FinanceConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
        }
    }
}