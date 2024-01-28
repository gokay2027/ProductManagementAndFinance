using Entities.ConcreteEntity;
using ProductManagementAndFinanceData.Repository.Contract;

namespace ProductManagementAndFinanceData.Repository.EntityRepository
{
    public class OrderRepository : GenericRepository<Order>
    {
        public OrderRepository(ProductManagementAndFinanceContext context) : base(context)
        {
        }
    }
}