using Microsoft.AspNetCore.Mvc;
using ProductManagementAndFinanceApi.Application.Commands.Abstract;
using ProductManagementAndFinanceApi.Application.Queries.Abstract;
using ProductManagementAndFinanceApi.Models.Command.Order;
using ProductManagementAndFinanceApi.Models.Query.Order;

namespace ProductManagementAndFinanceApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderCommandBusiness _orderCommandBusiness;
        private readonly IOrderQuery _orderQuery;

        public OrderController(IOrderCommandBusiness orderCommandBusiness, IOrderQuery orderQuery)
        {
            _orderCommandBusiness = orderCommandBusiness;
            _orderQuery = orderQuery;
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

        [HttpGet]
        public Task<OrderListOutputModel> GetAllOrders()
        {
            return _orderQuery.GetAllOrders();
        }

        [HttpGet]
        public Task<OrderListOutputModel> GetOrdersByFilter([FromQuery] OrderSearchModel searchModel)
        {
            return _orderQuery.GetOrdersByFilter(searchModel);
        }

        [HttpPut]
        public Task<UpdateOrderOutputModel> UpdateOrder([FromBody] UpdateOrderInputModel inputModel)
        {
            return _orderCommandBusiness.UpdateOrder(inputModel);
        }
    }
}