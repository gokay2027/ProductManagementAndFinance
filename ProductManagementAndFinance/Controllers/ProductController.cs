using Microsoft.AspNetCore.Mvc;
using ProductManagementAndFinance.Application.Commands.Abstract;
using ProductManagementAndFinance.Application.Queries.Abstract;
using ProductManagementAndFinance.Models.Command.Product;
using ProductManagementAndFinanceApi.Models.Query.Product;

namespace ProductManagementAndFinance.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductCommandBusiness _productCommandBusiness;
        private readonly IProductQuery _productQuery;

        public ProductController(
            IProductCommandBusiness productCommandBusiness,
            IProductQuery productQuery)
        {
            _productCommandBusiness = productCommandBusiness;
            _productQuery = productQuery;
        }

        [HttpPost]
        public IActionResult AddProduct([FromBody] AddProductModel model)
        {
            _productCommandBusiness.AddProduct(model);
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteProduct([FromBody] DeleteProductInputModel model)
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
        public Task<ProductOutputModel> GetProductsByFilter([FromQuery] ProductSearchModel searchModel)
        {
            return _productQuery.GetProductsByFilter(searchModel);
        }

        [HttpPut]
        public Task<UpdateProductOutputModel> UpdateProduct([FromBody] UpdateProductModel inputModel)
        {
            return _productCommandBusiness.UpdateProduct(inputModel);
        }

        [HttpGet]
        public Task<ProductOutputModel> GetProductsByStorage([FromQuery] ProductByStorageSearchModel searchModel)
        {
            return _productQuery.GetProductsByStorage(searchModel);
        }

        [HttpGet]
        public Task<ProductOutputModel> GetProductsByCategory([FromQuery] ProductByCategorySearchModel searchModel)
        {
            return _productQuery.GetProductsByCategory(searchModel);
        }
    }
}