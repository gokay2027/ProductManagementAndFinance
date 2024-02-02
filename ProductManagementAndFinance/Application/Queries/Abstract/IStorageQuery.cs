using Entities.ConcreteEntity;
using ProductManagementAndFinanceApi.Models.Query.Storage;
using System.Linq.Expressions;

namespace ProductManagementAndFinanceApi.Application.Queries.Abstract
{
    public interface IStorageQuery
    {
        /// <summary>
        /// Gets All storages
        /// </summary>
        /// <returns></returns>
        Task<StorageOutputModel> GetAllStorages();

        /// <summary>
        /// Gets Storages by filter
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<StorageOutputModel> GetStoragesByFilter(Expression<Func<Storage, bool>> predicate);
    }
}