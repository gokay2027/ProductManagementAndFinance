using Microsoft.EntityFrameworkCore;
using ProductManagementAndFinanceData.Repository.Abstract;

namespace ProductManagementAndFinanceData.Repository.Contract
{
    public abstract class EfCoreRepository<T> : IRepository<T> where T : class

    {
        private readonly ProductManagementAndFinanceContext context;

        public EfCoreRepository(ProductManagementAndFinanceContext context)
        {
            this.context = context;
        }

        public async Task<T> Add(T entity)
        {
            context.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> Delete(int id)
        {
            var entity = await context.Set<T>().FindAsync(id);
            if (entity == null)
            {
                return entity;
            }

            context.Set<T>().Remove(entity);
            await context.SaveChangesAsync();

            return entity;
        }

        public async Task<T> Get(int id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        public async Task<List<T>> GetAll()
        {
            return await context.Set<T>().ToListAsync();
        }

        public async Task<T> Update(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return entity;
        }
    }
}