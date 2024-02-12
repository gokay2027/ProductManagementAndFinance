using Microsoft.AspNetCore.Mvc;
using ProductManagementAndFinanceApi.Application.Commands.Abstract;
using ProductManagementAndFinanceApi.Models.Command.Order;

namespace ProductManagementAndFinanceApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderCommandBusiness _orderCommandBusiness;

        public OrderController(IOrderCommandBusiness orderCommandBusiness)
        {
            _orderCommandBusiness = orderCommandBusiness;
        }

        [HttpPost]
        public Task<AddOrderOutputModel> AddOrder([FromBody] AddOrderInputModel inputModel)
        {
            return _orderCommandBusiness.AddOrder(inputModel);
        }

        [HttpDelete]
        public Task<DeleteOrderOutputModel> DeleteOrder([FromBody] DeleteOrderInputModel inputModel)
        {
            return _orderCommandBusiness.DeleteOrder(inputModel);
        }

        [HttpPut]
        public Task<UpdateOrderOutputModel> UpdateOrder([FromBody] UpdateOrderInputModel inputModel)
        {
            return _orderCommandBusiness.UpdateOrder(inputModel);
        }
    }
}