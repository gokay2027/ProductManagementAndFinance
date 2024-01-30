using Entities.AbstractEntity.AbstractEntityRule;
using System.Data.Entity;
using System.Linq.Expressions;

namespace ProductManagementAndFinanceData.Repository.Abstract
{
    public interface IGenericRepository<TEntity> where TEntity : IBaseEntity
    {
        Task<List<TEntity>> GetAll();

        Task<TEntity> GetById(Guid? id);

        Task<TEntity> Add(TEntity entity);

        Task<TEntity> Update(TEntity entity);

        Task<TEntity> Delete(Guid id);

        Task<List<TEntity>> GetByFilter(Expression<Func<TEntity, bool>> predicate);
    }
}