using Entities.ConcreteEntity;
using ProductManagementAndFinanceData.Repository.Abstract;
using System.Linq.Expressions;

namespace ProductManagementAndFinanceData.Repository.EntityRepository.Abstract
{
    public interface IFinanceRepository : IGenericRepository<Finance>
    {
        Task<IQueryable<Finance>> GetFilteredFinancesWithUser(Expression<Func<Finance, bool>> predicate);
        Task<IQueryable<Finance>> GetAllFinancesWithUser();
    }
}