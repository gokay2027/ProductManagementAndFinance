using Entities.ConcreteEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProductManagementAndFinanceData.Configurations
{
    public class StorageConfiguration : IEntityTypeConfiguration<Storage>
    {
        public void Configure(EntityTypeBuilder<Storage> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasMany(s => s.Products).WithOne(a => a.Storage).HasForeignKey(a => a.StorageId);
            builder.HasOne(s => s.User).WithMany(u => u.Storages).HasForeignKey(u => u.UserId);
        }
    }
}