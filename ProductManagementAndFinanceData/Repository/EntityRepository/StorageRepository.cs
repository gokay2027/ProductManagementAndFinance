using Entities.ConcreteEntity;
using Microsoft.EntityFrameworkCore;
using ProductManagementAndFinanceData.Repository.Contract;
using ProductManagementAndFinanceData.Repository.EntityRepository.Abstract;

namespace ProductManagementAndFinanceData.Repository.EntityRepository
{
    public class StorageRepository : GenericRepository<Storage>,IStorageRepository
    {
        public StorageRepository(ProductManagementAndFinanceContext context) : base(context)
        {
        }
        private DbSet<Storage> Context
        {
            get { return _context.Storages; }
        }
    }
}