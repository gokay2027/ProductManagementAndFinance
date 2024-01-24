using Entities.ConcreteEntity;
using ProductManagementAndFinanceData.Repository.Contract;

namespace ProductManagementAndFinanceData.Repository.EntityRepository
{
    public class StorageRepository : EfCoreRepository<Storage>
    {
        public StorageRepository(ProductManagementAndFinanceContext context) : base(context)
        {
        }
    }
}