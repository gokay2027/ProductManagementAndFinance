using Entities.AbstractEntity.AbstractEntityRule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagementAndFinanceData.Repository.Abstract
{
    public interface IGenericRepository<TEntity> where TEntity : IBaseEntity
    {
        Task<List<TEntity>> GetAll();

        Task<TEntity> GetById(int id);

        Task<TEntity> Add(TEntity entity);

        Task<TEntity> Update(TEntity entity);

        Task<TEntity> Delete(int id);
    }
}