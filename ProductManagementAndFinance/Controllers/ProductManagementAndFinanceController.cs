using Microsoft.AspNetCore.Mvc;
using ProductManagementAndFinance.Application.Commands.Abstract;
using ProductManagementAndFinance.Application.Queries.Abstract;
using ProductManagementAndFinance.Models.Command.Product;
using ProductManagementAndFinance.Models.Query;

namespace ProductManagementAndFinance.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ProductManagementAndFinanceController : ControllerBase
    {
        private readonly IProductCommandBusiness _productCommandBusiness;
        private readonly IProductQuery _productQuery;
        private readonly ICategoryQuery _categoryQuery;

        public ProductManagementAndFinanceController(
            ICategoryQuery categoryQuery,
            IProductCommandBusiness productCommandBusiness,
            IProductQuery productQuery)
        {
            _productCommandBusiness = productCommandBusiness;
            _productQuery = productQuery;
            _categoryQuery = categoryQuery;
        }

        [HttpPost]
        public IActionResult AddProduct([FromQuery] AddProductModel model)
        {
            _productCommandBusiness.AddProduct(model);
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteProduct([FromQuery] DeleteProductInputModel model)
        {
            _productCommandBusiness.DeleteProduct(model);
            return Ok();
        }

        [HttpGet]
        public Task<ProductOutputModel> GetAllProducts()
        {
            return _productQuery.GetAllProducts();
        }

        [HttpGet]
        public Task<CategoryListOutputModel> GetAllCategories()
        {
            return _categoryQuery.GetAllCategories();
        }

        [HttpGet]
        public Task<ProductOutputModel> GetProductsByFilter([FromQuery] ProductSearchModel searchModel)
        {
            return _productQuery.GetProductsByFilter(searchModel);
        }
    }
}