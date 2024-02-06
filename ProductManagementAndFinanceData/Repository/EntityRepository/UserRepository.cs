using Entities.ConcreteEntity;
using Microsoft.EntityFrameworkCore;
using ProductManagementAndFinanceData.Repository.Contract;
using ProductManagementAndFinanceData.Repository.EntityRepository.Abstract;
using System.Linq.Expressions;

namespace ProductManagementAndFinanceData.Repository.EntityRepository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(ProductManagementAndFinanceContext context) : base(context)
        {
        }

        private DbSet<User> Context
        {
            get { return _context.Users; }
        }

        public IQueryable<User> GetUserWithStorageOrdersAndFinance(Expression<Func<User,bool>> predicate)
        {
            return Context.Include(u => u.Storages).Include(u => u.Orders).Where(predicate);
        }

    }
}