using Entities.ConcreteEntity;
using ProductManagementAndFinanceData.Repository.Contract;
using ProductManagementAndFinanceData.Repository.EntityRepository.Abstract;

namespace ProductManagementAndFinanceData.Repository.EntityRepository
{
    public class OrderRepository : GenericRepository<Order>,IOrderRepository
    {
        public OrderRepository(ProductManagementAndFinanceContext context) : base(context)
        {
        }
    }
}