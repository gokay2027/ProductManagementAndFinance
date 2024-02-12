using Entities.ConcreteEntity;
using ProductManagementAndFinanceData.Repository.Abstract;
using System.Linq.Expressions;

namespace ProductManagementAndFinanceData.Repository.EntityRepository.Abstract
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        Task<IQueryable<Order>> GetAllOrdersWithUserAndProducts();

        Task<IQueryable<Order>> GetFilteredOrdersWithUserAndProducts(Expression<Func<Order, bool>> predicate);
    }
}