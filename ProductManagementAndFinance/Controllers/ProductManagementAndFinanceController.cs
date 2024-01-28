using Microsoft.AspNetCore.Mvc;
using ProductManagementAndFinance.Application.Commands.Abstract;
using ProductManagementAndFinance.Application.Commands.Concrete;
using ProductManagementAndFinance.Models.Command.Product;

namespace ProductManagementAndFinance.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ProductManagementAndFinanceController : ControllerBase
    {
        private readonly IProductCommandBusiness _productRepository;

        public ProductManagementAndFinanceController(IProductCommandBusiness productCommandBusiness)
        {
            _productRepository = productCommandBusiness;
        }

        [HttpPost]
        public IActionResult AddProduct([FromQuery] AddProductModel model)
        {
            _productRepository.AddProduct(model);
            return Ok();
        }
    }
}