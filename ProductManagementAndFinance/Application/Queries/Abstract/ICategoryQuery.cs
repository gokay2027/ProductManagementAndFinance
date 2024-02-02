using ProductManagementAndFinanceApi.Models.Query.Category;

namespace ProductManagementAndFinance.Application.Queries.Abstract
{
    public interface ICategoryQuery
    {
        /// <summary>
        /// Gets All Categories
        /// </summary>
        /// <returns></returns>
        Task<CategoryListOutputModel> GetAllCategories();
    }
}