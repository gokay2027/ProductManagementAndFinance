using Entities.ConcreteEntity;
using ProductManagementAndFinance.Models.Query;
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
    }
}