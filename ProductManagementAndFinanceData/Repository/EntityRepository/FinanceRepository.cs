using Entities.ConcreteEntity;
using Microsoft.EntityFrameworkCore;
using ProductManagementAndFinanceData.Repository.Contract;
using ProductManagementAndFinanceData.Repository.EntityRepository.Abstract;

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
    }
}