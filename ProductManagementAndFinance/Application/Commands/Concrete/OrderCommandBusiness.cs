using Entities.ConcreteEntity;
using ProductManagementAndFinanceApi.Application.Commands.Abstract;
using ProductManagementAndFinanceApi.Models.Command.Order;
using ProductManagementAndFinanceData.Repository.EntityRepository.Abstract;

namespace ProductManagementAndFinanceApi.Application.Commands.Concrete
{
    public class OrderCommandBusiness : IOrderCommandBusiness
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;

        public OrderCommandBusiness(IOrderRepository orderRepository, IProductRepository productRepository)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
        }

        public async Task<AddOrderOutputModel> AddOrder(AddOrderInputModel inputModel)
        {
            try
            {
                var order = new Order(inputModel.UserId, inputModel.Adress);

                foreach (var productId in inputModel.ProductIds)
                {
                    var product = await _productRepository.GetById(productId);
                    order.AddProductToOrder(product);
                }
                await _orderRepository.Add(order);
                return new AddOrderOutputModel
                {
                    IsSuccess = true,
                    Message = "Order has been added successfully"
                };
            }
            catch (Exception ex)
            {
                return new AddOrderOutputModel
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }

        public async Task<DeleteOrderOutputModel> DeleteOrder(DeleteOrderInputModel inputModel)
        {
            try
            {
                await _orderRepository.Delete(inputModel.Id);

                return new DeleteOrderOutputModel
                {
                    Message = "Order has been deleted successfully",
                    IsSuccess = true
                };
            }
            catch (Exception ex)
            {
                return new DeleteOrderOutputModel
                {
                    Message = ex.Message,
                    IsSuccess = false
                };
            }
        }

        public async Task<UpdateOrderOutputModel> UpdateOrder(UpdateOrderInputModel inputModel)
        {
            try
            {
                var orderToBeUpdated = await _orderRepository.GetById(inputModel.Id);
                orderToBeUpdated.UpdateOrder(inputModel.UserId, inputModel.TotalPrice, inputModel.Adress);
                await _orderRepository.Update(orderToBeUpdated);

                return new UpdateOrderOutputModel
                {
                    IsSuccess = true,
                    Message = "Order has been Updated Successfully"
                };
            }
            catch (Exception ex)
            {
                return new UpdateOrderOutputModel
                {
                    IsSuccess = true,
                    Message = ex.Message
                };
            }
        }
    }
}