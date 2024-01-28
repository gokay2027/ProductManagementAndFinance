using Microsoft.AspNetCore.Mvc;
using ProductManagementAndFinance.Application.Commands.Abstract;
using ProductManagementAndFinance.Models.Command.Product;

namespace ProductManagementAndFinance.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ProductManagementAndFinanceController : ControllerBase
    {
        private readonly IProductCommandBusiness _productCommandBusiness;

        public ProductManagementAndFinanceController(IProductCommandBusiness productCommandBusiness)
        {
            _productCommandBusiness = productCommandBusiness;
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
    }
}