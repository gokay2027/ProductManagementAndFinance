using Entities.ConcreteEntity;
using ProductManagementAndFinanceData.Repository.Abstract;
using System.Linq.Expressions;

namespace ProductManagementAndFinanceData.Repository.EntityRepository.Abstract
{
    public interface IStorageRepository : IGenericRepository<Storage>
    {
        Task<IQueryable<Storage>> GetAllStoragesWithUser();
        Task<IQueryable<Storage>> GetFilteredStoragesWithUser(Expression<Func<Storage, bool>> predicate);
        Task<IQueryable<Storage>> GetFilteredStoragesWithProduct(Expression<Func<Storage, bool>> predicate);
    }
}