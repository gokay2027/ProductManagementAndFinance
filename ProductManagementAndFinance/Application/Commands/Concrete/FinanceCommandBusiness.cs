using ClosedXML.Excel;
using ProductManagementAndFinanceApi.Application.Commands.Abstract;
using ProductManagementAndFinanceApi.Models.Command.Finance;
using ProductManagementAndFinanceData.Repository.EntityRepository.Abstract;
using System.Text;

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

            worksheet.Cell(1, 1).Value = "TotalDebt";
            worksheet.Cell(1, 2).Value = "Total Sales";
            worksheet.Cell(1, 3).Value = "Total Profit";

            SaveLocationForExcelReports(workbook, "FinanceReportForUser");

            return new CreateFinanceReportForUserOutputModel
            {
                IsSuccess = true,
                Message = "Report Saved"
            };
        }

        public CreateOrderReportForUserOutputModel CreateOrderReportForUser(CreateOrderReportForUserInputModel inputModel)
        {
            var workbook = new XLWorkbook();
            var worksheet = workbook.AddWorksheet("Sample Sheet");

            worksheet.Cell(1, 1).Value = "TotalDebt";
            worksheet.Cell(1, 2).Value = "Total Sales";
            worksheet.Cell(1, 3).Value = "Total Profit";

            SaveLocationForExcelReports(workbook, "OrderReportForUser");

            return new CreateOrderReportForUserOutputModel
            {
                IsSuccess = true,
                Message = "Report Saved"
            };
        }

        public CreateProductAndStorageReportForUserOutputModel CreateProductAndStorageReportForUser(CreateProductAndStorageReportForUserInputModel inputModel)
        {
            var workbook = new XLWorkbook();
            var worksheet = workbook.AddWorksheet("Sample Sheet");

            worksheet.Cell(1, 1).Value = "TotalDebt";
            worksheet.Cell(1, 2).Value = "Total Sales";
            worksheet.Cell(1, 3).Value = "Total Profit";

            SaveLocationForExcelReports(workbook, "ProductAndStorageReportForUser");

            return new CreateProductAndStorageReportForUserOutputModel
            {
                IsSuccess = true,
                Message = "Report Saved"
            };
        }

        private static void SaveLocationForExcelReports(XLWorkbook workbook, string reportName)
        {
            StringBuilder pathbuilder = new StringBuilder("");
            pathbuilder = pathbuilder.Append(Environment.GetFolderPath(Environment.SpecialFolder.Desktop));

            if (System.OperatingSystem.IsLinux())
            {
                pathbuilder = pathbuilder.Append($"/{reportName}.xlsx");
                workbook.SaveAs(pathbuilder.ToString());
            }

            if (System.OperatingSystem.IsWindows())
            {
                pathbuilder = pathbuilder.Append($"\\{reportName}.xlsx");
                workbook.SaveAs(pathbuilder.ToString());
            }
        }
    }
}