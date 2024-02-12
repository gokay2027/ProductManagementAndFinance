using ProductManagementAndFinanceApi.Models.Query.Order;

namespace ProductManagementAndFinanceApi.Application.Queries.Abstract
{
    public interface IOrderQuery
    {
        /// <summary>
        /// Gets All orders
        /// </summary>
        /// <returns></returns>
        Task<OrderListOutputModel> GetAllOrders();

        /// <summary>
        /// Gets orders by filter
        /// </summary>
        /// <param name="searchModel"></param>
        /// <returns></returns>
        Task<OrderListOutputModel> GetOrdersByFilter(OrderSearchModel searchModel);
    }
}