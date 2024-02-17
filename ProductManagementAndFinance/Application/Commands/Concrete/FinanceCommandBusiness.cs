using ClosedXML.Excel;
using Entities.ConcreteEntity;
using LinqKit;
using ProductManagementAndFinanceApi.Application.Commands.Abstract;
using ProductManagementAndFinanceApi.Application.Commands.Enums;
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
        private readonly IStorageRepository _storaRepository;

        public FinanceCommandBusiness(IFinanceRepository financeRepository, IOrderRepository orderRepository, IStorageRepository storaRepository)
        {
            _financeRepository = financeRepository;
            _orderRepository = orderRepository;
            _storaRepository = storaRepository;
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

            worksheet.Cell(1, (int)OrderReportColumnEnum.adressColumn).Value = "Adress";
            worksheet.Cell(1, (int)OrderReportColumnEnum.totalPriceColumn).Value = "Total Price";
            worksheet.Cell(1, (int)OrderReportColumnEnum.productColumn).Value = "Products";
            worksheet.Cell(1, (int)OrderReportColumnEnum.productNameColumn).Value = "Product Name";
            worksheet.Cell(1, (int)OrderReportColumnEnum.productDescriptionColumn).Value = "Product Description";
            worksheet.Cell(1, (int)OrderReportColumnEnum.productPriceColumn).Value = "Product Price";
            worksheet.Cell(1, (int)OrderReportColumnEnum.productPriceCurrencyColumn).Value = "Product Currency";

            var startBottomRow = 2;

            ordersOfUser.ForEach(order =>
            {
                worksheet.Cell(startBottomRow, (int)OrderReportColumnEnum.adressColumn).Value = order.Adress;
                worksheet.Cell(startBottomRow, (int)OrderReportColumnEnum.totalPriceColumn).Value = order.TotalPrice;
                order.Products.ForEach(product =>
                {
                    worksheet.Cell(startBottomRow, (int)OrderReportColumnEnum.productNameColumn).Value = product.Name;
                    worksheet.Cell(startBottomRow, (int)OrderReportColumnEnum.productDescriptionColumn).Value = product.Description;
                    worksheet.Cell(startBottomRow, (int)OrderReportColumnEnum.productPriceColumn).Value = product.Price;
                    worksheet.Cell(startBottomRow, (int)OrderReportColumnEnum.productPriceCurrencyColumn).Value = product.PriceCurrency;
                    startBottomRow++;
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

            var predicate = CreateProductAndStorageReportFilterBuilder(inputModel);

            var storage = await _storaRepository.GetFilteredStoragesWithProductAndUser(predicate);

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


        private static ExpressionStarter<Storage> CreateProductAndStorageReportFilterBuilder(CreateProductAndStorageReportForUserInputModel inputModel)
        {
            var predicate = PredicateBuilder.New<Storage>();

            predicate.And(a => a.Id.Equals(inputModel.StorageId));
            predicate.And(a => a.UserId.Equals(inputModel.UserId));
            
            return predicate;
        }
    }
}