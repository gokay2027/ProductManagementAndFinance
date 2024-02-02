using ProductManagementAndFinanceApi.Models.Query.Storage;

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
        Task<StorageOutputModel> GetStoragesByFilter(StorageSearchModel searchModel);
    }
}