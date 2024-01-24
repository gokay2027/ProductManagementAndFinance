using Entities.AbstractEntity.AbstractEntityRule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagementAndFinanceData.Repository.Abstract
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAll();

        Task<T> Get(int id);

        Task<T> Add(T entity);

        Task<T> Update(T entity);

        Task<T> Delete(int id);
    }
}