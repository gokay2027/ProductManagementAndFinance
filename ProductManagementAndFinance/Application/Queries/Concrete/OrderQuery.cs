using Entities.ConcreteEntity;
using LinqKit;
using Microsoft.IdentityModel.Tokens;
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
                    List<string> products = new List<string>();
                    float totalprice = 0;

                    foreach (var pr in order.Products)
                    {
                        products.Add(pr.Name);
                        totalprice += pr.Price;
                    }

                    output.OutputList.Add(new OrderListItem
                    {
                        CustomerNameSurname = order.User.Name + " " + order.User.Surname,
                        Adress = order.Adress,
                        ProductNames = products,
                        TotalPrice = totalprice
                    });
                }
                output.IsSuccess = true;
                output.Message = "Orders queried successfully";
                output.ItemCount = output.OutputList.Count;

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
            var output = new OrderListOutputModel();
            var predicate = OrderFilterForQuery(searchModel);
            try
            {
                var filteredOrders = await _orderRepository.GetFilteredOrdersWithUserAndProducts(predicate);
                foreach (var order in filteredOrders)
                {
                    List<string> products = new List<string>();
                    float totalprice = 0;

                    foreach (var pr in order.Products)
                    {
                        products.Add(pr.Name);
                        totalprice += pr.Price;
                    }

                    output.OutputList.Add(new OrderListItem
                    {
                        CustomerNameSurname = order.User.Name + " " + order.User.Surname,
                        Adress = order.Adress,
                        ProductNames = products,
                        TotalPrice = totalprice
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

        private static ExpressionStarter<Order> OrderFilterForQuery(OrderSearchModel searchModel)
        {
            var predicate = PredicateBuilder.New<Order>();

            if (!searchModel.Adress.IsNullOrEmpty())
                predicate.And(a => a.Adress.Contains(searchModel.Adress));

            if (searchModel.UserId.HasValue)
                predicate.And(a => a.UserId.Equals(searchModel.UserId));

            if (searchModel.MaxTotalPrice.HasValue && searchModel.MinTotalPrice.HasValue
                && searchModel.MaxTotalPrice > searchModel.MinTotalPrice)
                predicate.And(a => a.TotalPrice <= searchModel.MaxTotalPrice && a.TotalPrice >= searchModel.MinTotalPrice);

            return predicate;
        }
    }
}