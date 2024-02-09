using Microsoft.AspNetCore.Mvc;
using ProductManagementAndFinance.Application.Queries.Abstract;
using ProductManagementAndFinanceApi.Application.Commands.Abstract;
using ProductManagementAndFinanceApi.Models.Command.Category;
using ProductManagementAndFinanceApi.Models.Query.Category;

namespace ProductManagementAndFinanceApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryQuery _categoryQuery;
        private readonly ICategoryCommandBusiness _categoryCommandBusiness;

        public CategoryController(ICategoryQuery categoryQuery, ICategoryCommandBusiness categoryCommandBusiness)
        {
            _categoryQuery = categoryQuery;
            _categoryCommandBusiness = categoryCommandBusiness;
        }

        [HttpGet]
        public async Task<CategoryListOutputModel> GetAllCategories()
        {
            return await _categoryQuery.GetAllCategories();
        }

        [HttpPut]
        public async Task<UpdateCategoryOutputModel> UpdateCategory([FromBody] UpdateCategoryModel model)
        {
            return await _categoryCommandBusiness.UpdateCategory(model);
        }

        [HttpPost]
        public async Task<AddCategoryCommandOutputModel> AddCategory([FromBody] AddCategoryModel model)
        {
            return await _categoryCommandBusiness.AddCategory(model);
        }

        [HttpDelete]
        public async Task<DeleteCategoryCommandOutputModel> DeleteCategory([FromBody] DeleteCategoryModel model)
        {
            return await _categoryCommandBusiness.DeleteCategory(model);
        }
    }
}