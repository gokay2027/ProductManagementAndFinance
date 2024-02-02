using ProductManagementAndFinanceApi.Models.Query.Category;

namespace ProductManagementAndFinance.Application.Queries.Abstract
{
    public interface ICategoryQuery
    {
        Task<CategoryListOutputModel> GetAllCategories();
    }
}