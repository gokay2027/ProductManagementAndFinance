using Entities.ConcreteEntity;
using ProductManagementAndFinanceData.Repository.Contract;

namespace ProductManagementAndFinanceData.Repository.EntityRepository
{
    public class FinanceRepository : GenericRepository<Finance>
    {
        public FinanceRepository(ProductManagementAndFinanceContext context) : base(context)
        {
        }
    }
}