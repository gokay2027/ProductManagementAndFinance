using ProductManagementAndFinanceApi.Application.Queries.Abstract;
using ProductManagementAndFinanceApi.Models.Query.Order;
using ProductManagementAndFinanceData.Repository.EntityRepository.Abstract;

namespace ProductManagementAndFinanceApi.Application.Queries.Concrete
{
    public class OrderQuery : IOrderQuery
    {
        private readonly IOrderRepository _orderRepository;

        public OrderQuery(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<OrderListOutputModel> GetAllOrders()
        {
            var output = new OrderListOutputModel();
            try
            {
                var allOrders = await _orderRepository.GetAllOrdersWithUserAndProducts();
                foreach (var order in allOrders)
                {
                    output.OutputList.Add(new OrderListItem
                    {
                        User = order.User,
                        UserId = order.User.Id,
                        Adress = order.Adress,
                        Products = order.Products,
                        TotalPrice = order.TotalPrice,
                    });
                }
                output.IsSuccess = true;
                output.Message = "Orders queried successfully";
                return output;
            }
            catch (Exception ex)
            {
                output.IsSuccess = false;
                output.Message = ex.Message;
                return output;
            }
        }

        public async Task<OrderListOutputModel> GetOrdersByFilter(OrderSearchModel searchModel)
        {
            throw new NotImplementedException();
        }
    }
}