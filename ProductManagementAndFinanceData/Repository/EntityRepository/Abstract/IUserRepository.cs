using Entities.ConcreteEntity;
using ProductManagementAndFinanceData.Repository.Abstract;
using System.Linq.Expressions;

namespace ProductManagementAndFinanceData.Repository.EntityRepository.Abstract
{
    public interface IUserRepository : IGenericRepository<User>
    {
        IQueryable<User> GetUserWithStorageOrdersAndFinance(Expression<Func<User, bool>> predicate);
    }
}