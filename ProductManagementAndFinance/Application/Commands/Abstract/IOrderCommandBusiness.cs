using ProductManagementAndFinanceApi.Models.Command.Order;

namespace ProductManagementAndFinanceApi.Application.Commands.Abstract
{
    public interface IOrderCommandBusiness
    {
        /// <summary>
        /// Adds Order
        /// </summary>
        /// <param name="inputModel"></param>
        /// <returns></returns>
        Task<AddOrderOutputModel> AddOrder(AddOrderInputModel inputModel);

        /// <summary>
        /// Deletes Order
        /// </summary>
        /// <param name="inputModel"></param>
        /// <returns></returns>
        Task<DeleteOrderOutputModel> DeleteOrder(DeleteOrderInputModel inputModel);

        /// <summary>
        /// Updates Order
        /// </summary>
        /// <param name="inputModel"></param>
        /// <returns></returns>
        Task<UpdateOrderOutputModel> UpdateOrder(UpdateOrderInputModel inputModel);
    }
}