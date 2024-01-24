using Entities.ConcreteEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProductManagementAndFinanceData.Configurations
{
    public class FinanceConfiguration : IEntityTypeConfiguration<Finance>
    {
        public void Configure(EntityTypeBuilder<Finance> builder)
        {
            builder.HasKey(e => e.Id);
            builder.HasOne(f => f.User).WithOne(u => u.Finance).HasForeignKey<Finance>(a=>a.UserId);
        }
    }
}