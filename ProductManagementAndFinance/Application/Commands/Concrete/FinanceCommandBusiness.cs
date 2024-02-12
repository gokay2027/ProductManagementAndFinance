using ProductManagementAndFinance.Models.AbstractOutputModel.Command;
using ProductManagementAndFinanceApi.Application.Commands.Abstract;
using ProductManagementAndFinanceApi.Models.Command.Finance;
using ProductManagementAndFinanceData.Repository.EntityRepository.Abstract;

namespace ProductManagementAndFinanceApi.Application.Commands.Concrete
{
    /// <summary>
    /// Finance is a order and price billing class
    /// in this area functionality of the bill management will be implemented
    /// </summary>
    public class FinanceCommandBusiness : IFinanceCommandBusiness
    {
        private readonly IFinanceRepository _financeRepository;
        private readonly IOrderRepository _orderRepository;

        public FinanceCommandBusiness(IFinanceRepository financeRepository, IOrderRepository orderRepository)
        {
            _financeRepository = financeRepository;
            _orderRepository = orderRepository;
        }

        public BaseCommandOutputModel CreateFinanceReportForUser(CreateFinanceReportForUserInputModel inputModel)
        {
            throw new NotImplementedException();
        }

        public BaseCommandOutputModel CreateOrderReportForUser(CreateOrderReportForUserInputModel inputModel)
        {
            throw new NotImplementedException();
        }

        public BaseCommandOutputModel CreateProductAndStorageReportForUser(CreateProductAndStorageReportForUserInputModel inputModel)
        {
            throw new NotImplementedException();
        }
    }
}