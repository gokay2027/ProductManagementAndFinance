using Microsoft.AspNetCore.Mvc;
using ProductManagementAndFinance.Application.Queries.Abstract;
using ProductManagementAndFinanceApi.Models.Query.Category;

namespace ProductManagementAndFinanceApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryQuery _categoryQuery;

        public CategoryController(ICategoryQuery categoryQuery)
        {
            _categoryQuery = categoryQuery;
        }

        [HttpGet]
        public async Task<CategoryListOutputModel> GetAllCategories()
        {
            return await _categoryQuery.GetAllCategories();
        }
    }
}