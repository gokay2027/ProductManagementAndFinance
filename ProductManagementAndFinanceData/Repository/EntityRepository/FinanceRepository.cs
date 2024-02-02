using Entities.ConcreteEntity;
using ProductManagementAndFinanceData.Repository.Contract;
using ProductManagementAndFinanceData.Repository.EntityRepository.Abstract;

namespace ProductManagementAndFinanceData.Repository.EntityRepository
{
    public class FinanceRepository : GenericRepository<Finance>, IFinanceRepository
    {
        public FinanceRepository(ProductManagementAndFinanceContext context) : base(context)
        {
        }
        private ProductManagementAndFinanceContext ProductManagementContext
        {
            get { return _context; }
        }
    }
}