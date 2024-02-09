using Entities.ConcreteEntity;
using Microsoft.EntityFrameworkCore;
using ProductManagementAndFinanceData.Repository.Contract;
using ProductManagementAndFinanceData.Repository.EntityRepository.Abstract;
using System.Linq.Expressions;

namespace ProductManagementAndFinanceData.Repository.EntityRepository
{
    public class FinanceRepository : GenericRepository<Finance>, IFinanceRepository
    {
        public FinanceRepository(ProductManagementAndFinanceContext context) : base(context)
        {
        }

        private DbSet<Finance> Context
        {
            get { return _context.Finances; }
        }

        public async Task<IQueryable<Finance>> GetFilteredFinancesWithUser(Expression<Func<Finance, bool>> predicate)
        {
            return Context.Include(a => a.User).Where(predicate);
        }

        public async Task<IQueryable<Finance>> GetAllFinancesWithUser()
        {
            return Context.Include(a => a.User);
        }
    }
}