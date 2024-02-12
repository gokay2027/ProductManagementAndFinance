using Entities.ConcreteEntity;
using Microsoft.EntityFrameworkCore;
using ProductManagementAndFinanceData.Repository.Contract;
using ProductManagementAndFinanceData.Repository.EntityRepository.Abstract;
using System.Linq.Expressions;

namespace ProductManagementAndFinanceData.Repository.EntityRepository
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(ProductManagementAndFinanceContext context) : base(context)
        {
        }

        private DbSet<Order> Context
        {
            get { return _context.Orders; }
        }

        public async Task<IQueryable<Order>> GetAllOrdersWithUserAndProducts()
        {
            return Context
                .Include(a => a.User)
                .Include(a => a.Products);
        }

        public async Task<IQueryable<Order>> GetFilteredOrdersWithUserAndProducts(Expression<Func<Order, bool>> predicate)
        {
            return Context
                .Include(a => a.User)
                .Include(a => a.Products)
                .Where(predicate);
        }
    }
}