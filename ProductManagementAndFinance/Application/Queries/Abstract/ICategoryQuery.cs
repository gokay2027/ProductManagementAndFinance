using Entities.ConcreteEntity;
using ProductManagementAndFinanceApi.Models.Query.Category;
using System.Linq.Expressions;

namespace ProductManagementAndFinance.Application.Queries.Abstract
{
    public interface ICategoryQuery
    {
        /// <summary>
        /// Gets All Categories
        /// </summary>
        /// <returns></returns>
        Task<CategoryListOutputModel> GetAllCategories();

        /// <summary>
        /// Gets categories by Filterin
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<CategoryListOutputModel> GetCategoriesByFilter(CategorySearchModel searchModel);
    }
}