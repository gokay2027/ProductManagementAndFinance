using Entities.ConcreteEntity;
using ProductManagementAndFinanceApi.Models.Query.Product;
using System.Linq.Expressions;

namespace ProductManagementAndFinance.Application.Queries.Abstract
{
    public interface IProductQuery
    {
        /// <summary>
        /// Gets All products
        /// </summary>
        /// <returns></returns>
        Task<ProductOutputModel> GetAllProducts();
        
        /// <summary>
        /// Gets products by search model
        /// </summary>
        /// <param name="searchModel"></param>
        /// <returns></returns>
        Task<ProductOutputModel> GetProductsByFilter(ProductSearchModel searchModel);

        /// <summary>
        /// Gets products by storage Id 
        /// </summary>
        /// <param name="searchModel"></param>
        /// <returns></returns>
        Task<ProductOutputModel> GetProductsByStorage(ProductByStorageSearchModel searchModel);

        /// <summary>
        /// Gets Products by category
        /// </summary>
        /// <param name="searchModel"></param>
        /// <returns></returns>
        Task<ProductOutputModel> GetProductsByCategory(ProductByCategorySearchModel searchModel);

    }
}