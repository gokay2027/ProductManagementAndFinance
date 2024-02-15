using ClosedXML.Excel;
using LinqKit;
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

        //Finance reposistory will save and update last finance condition of the domain to the database

        public async Task<CreateFinanceReportForUserOutputModel> CreateFinanceReportForUser(CreateFinanceReportForUserInputModel inputModel)
        {
            var workbook = new XLWorkbook();
            var worksheet = workbook.AddWorksheet("Finance Report");

            //Dates required and max min date check will be done in validation

            var ordersOfUser = await _orderRepository.GetFilteredOrdersWithUserAndProducts(a => a.UserId == inputModel.UserId
            && a.CreatedDate <= inputModel.MaxDate
            && a.CreatedDate >= inputModel.MinDate);

            float sumOfEndorsement = 0;
            var totalProductSales = 0;

            //Product buy price column will be added to domain
            var totalDebt = 0;

            foreach (var order in ordersOfUser)
            {
                var orderProductList = order.Products;
                totalProductSales += orderProductList.Count;

                var productPrices = orderProductList.Select(a => a.Price);
                var orderTotalEndorsement = productPrices.Sum();

                sumOfEndorsement += orderTotalEndorsement;
            }

            worksheet.Cell(1, 1).Value = "TotalDebt";
            worksheet.Cell(1, 2).Value = "Total Product Sales";
            worksheet.Cell(1, 3).Value = "Total Profit";

            worksheet.Cell(2, 1).Value = totalDebt;
            worksheet.Cell(2, 2).Value = totalProductSales;
            worksheet.Cell(2, 3).Value = sumOfEndorsement;

            SaveLocationForExcelReports(workbook, "FinanceReportForUser");

            return new CreateFinanceReportForUserOutputModel
            {
                IsSuccess = true,
                Message = "Report Saved"
            };
        }

        public async Task<CreateOrderReportForUserOutputModel> CreateOrderReportForUser(CreateOrderReportForUserInputModel inputModel)
        {
            var workbook = new XLWorkbook();
            var worksheet = workbook.AddWorksheet("Order Report");

            var ordersOfUser = await _orderRepository.GetByFilter(a => a.UserId == inputModel.UserId
            && a.CreatedDate <= inputModel.MaxDate
            && a.CreatedDate >= inputModel.MinDate);

            //They will be enumed
            //BURADA KALDIN
            var adressColumn = 1;
            var totalPriceColumn = 2;
            var productColumn = 3;
            var productNameColumn = 4;
            var productPriceColumn = 5;
            var productDescrptionColumn = 6;
            var productPriceCurrencyColumn = 7;

            worksheet.Cell(1, adressColumn).Value = "Adress";
            worksheet.Cell(1, totalPriceColumn).Value = "Total Price";
            worksheet.Cell(1, productColumn).Value = "Products";
            worksheet.Cell(1, productNameColumn).Value = "Product Name";
            worksheet.Cell(1, productPriceColumn).Value = "Product Description";
            worksheet.Cell(1, productDescrptionColumn).Value = "Product Price";
            worksheet.Cell(1, productPriceCurrencyColumn).Value = "Product Currency";

            var startBottomRow = 2;

            ordersOfUser.ForEach(order =>
            {
                worksheet.Cell(startBottomRow, adressColumn).Value = order.Adress;
                worksheet.Cell(startBottomRow, totalPriceColumn).Value = order.TotalPrice;
                order.Products.ForEach(product =>
                {
                });
            });

            SaveLocationForExcelReports(workbook, "OrderReportForUser");

            return new CreateOrderReportForUserOutputModel
            {
                IsSuccess = true,
                Message = "Report Saved"
            };
        }

        public async Task<CreateProductAndStorageReportForUserOutputModel> CreateProductAndStorageReportForUser(CreateProductAndStorageReportForUserInputModel inputModel)
        {
            var workbook = new XLWorkbook();
            var worksheet = workbook.AddWorksheet("Product and Storage Report");

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