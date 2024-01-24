using Entities.ConcreteEntity;
using ProductManagementAndFinanceData.Repository.Contract;

namespace ProductManagementAndFinanceData.Repository.EntityRepository
{
    public class FinanceRepository : EfCoreRepository<Finance>
    {
        public FinanceRepository(ProductManagementAndFinanceContext context) : base(context)
        {
        }
    }
}