using Entities.ConcreteEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProductManagementAndFinanceData.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(e => e.Id);
            builder.HasMany(o => o.Products).WithOne(o => o.Order).HasForeignKey(o => o.OrderId);
            builder.HasOne(a => a.User).WithMany(u => u.Orders).HasForeignKey(o => o.UserId);
        }
    }
}