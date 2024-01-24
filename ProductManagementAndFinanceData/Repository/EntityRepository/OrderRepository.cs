using Entities.ConcreteEntity;
using ProductManagementAndFinanceData.Repository.Contract;

namespace ProductManagementAndFinanceData.Repository.EntityRepository
{
    public class OrderRepository : EfCoreRepository<Order>
    {
        public OrderRepository(ProductManagementAndFinanceContext context) : base(context)
        {
        }
    }
}