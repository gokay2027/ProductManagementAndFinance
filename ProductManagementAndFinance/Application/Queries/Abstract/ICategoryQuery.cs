using ProductManagementAndFinance.Models.Query;

namespace ProductManagementAndFinance.Application.Queries.Abstract
{
    public interface ICategoryQuery
    {
        Task<CategoryListOutputModel> GetAllCategories();
    }
}