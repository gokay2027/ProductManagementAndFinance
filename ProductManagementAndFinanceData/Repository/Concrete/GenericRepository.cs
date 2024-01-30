using Entities.AbstractEntity;
using ProductManagementAndFinanceData.Repository.Abstract;
using System.Linq.Expressions;

namespace ProductManagementAndFinanceData.Repository.Contract
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly ProductManagementAndFinanceContext _context;

        protected GenericRepository(ProductManagementAndFinanceContext context)
        {
            _context = context;
        }

        public async Task<TEntity> Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();

            return entity;
        }

        public async Task<TEntity> Delete(Guid id)
        {
            var entity = _context.Set<TEntity>().FirstOrDefault(a => a.Id.Equals(id));
            entity.Delete();
            _context.Set<TEntity>().Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> GetById(Guid? id)
        {
            return _context.Set<TEntity>().FirstOrDefault(a => a.Id.Equals(id));
        }

        public async Task<List<TEntity>> GetAll()
        {
            return  _context.Set<TEntity>().ToList();
        }

        public async Task<List<TEntity>> GetByFilter(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().Where(predicate).ToList();
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}