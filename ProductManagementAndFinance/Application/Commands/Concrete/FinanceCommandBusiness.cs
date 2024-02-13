using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
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

        public CreateFinanceReportForUserOutputModel CreateFinanceReportForUser(CreateFinanceReportForUserInputModel inputModel)
        {
            var workbook = new XLWorkbook();
            var worksheet = workbook.AddWorksheet("Sample Sheet");
            worksheet.Cell("A1").Value = "Hello World!";
            worksheet.Cell("A2").FormulaA1 = "MID(A1, 7, 5)";
            workbook.SaveAs("C:\\Users\\gokay\\Desktop\\HelloWorld.xlsx");

            return new CreateFinanceReportForUserOutputModel
            {
                IsSuccess = true,
                Message = "aaa"
            };
        }

        public CreateOrderReportForUserOutputModel CreateOrderReportForUser(CreateOrderReportForUserInputModel inputModel)
        {
            throw new NotImplementedException();
        }

        public CreateProductAndStorageReportForUserOutputModel CreateProductAndStorageReportForUser(CreateProductAndStorageReportForUserInputModel inputModel)
        {
            throw new NotImplementedException();
        }
    }
}