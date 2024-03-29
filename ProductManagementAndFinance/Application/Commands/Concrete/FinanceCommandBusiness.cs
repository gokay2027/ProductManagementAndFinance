﻿using ClosedXML.Excel;
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

            try
            {
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

                var finance = new Finance(totalProductSales, totalDebt, sumOfEndorsement, inputModel.UserId);

                await _financeRepository.Add(finance);

                return new CreateFinanceReportForUserOutputModel
                {
                    IsSuccess = true,
                    Message = "Report Saved"
                };
            }
            catch (Exception ex)
            {
                return new CreateFinanceReportForUserOutputModel
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }

        public async Task<CreateOrderReportForUserOutputModel> CreateOrderReportForUser(CreateOrderReportForUserInputModel inputModel)
        {
            var workbook = new XLWorkbook();
            var worksheet = workbook.AddWorksheet("Order Report");

            try
            {
                var ordersOfUser = await _orderRepository.GetByFilter(a => a.UserId == inputModel.UserId
                && a.CreatedDate <= inputModel.MaxDate
                && a.CreatedDate >= inputModel.MinDate);

                worksheet.Cell(1, (int)OrderReportColumn.adressColumn).Value = "Adress";
                worksheet.Cell(1, (int)OrderReportColumn.totalPriceColumn).Value = "Total Price";
                worksheet.Cell(1, (int)OrderReportColumn.productColumn).Value = "Products";
                worksheet.Cell(1, (int)OrderReportColumn.productNameColumn).Value = "Product Name";
                worksheet.Cell(1, (int)OrderReportColumn.productDescriptionColumn).Value = "Product Description";
                worksheet.Cell(1, (int)OrderReportColumn.productPriceColumn).Value = "Product Price";
                worksheet.Cell(1, (int)OrderReportColumn.productPriceCurrencyColumn).Value = "Product Currency";

                var startBottomRow = 2;

                ordersOfUser.ForEach(order =>
                {
                    worksheet.Cell(startBottomRow, (int)OrderReportColumn.adressColumn).Value = order.Adress;
                    worksheet.Cell(startBottomRow, (int)OrderReportColumn.totalPriceColumn).Value = order.TotalPrice;
                    order.Products.ForEach(product =>
                    {
                        worksheet.Cell(startBottomRow, (int)OrderReportColumn.productNameColumn).Value = product.Name;
                        worksheet.Cell(startBottomRow, (int)OrderReportColumn.productDescriptionColumn).Value = product.Description;
                        worksheet.Cell(startBottomRow, (int)OrderReportColumn.productPriceColumn).Value = product.Price;
                        worksheet.Cell(startBottomRow, (int)OrderReportColumn.productPriceCurrencyColumn).Value = product.PriceCurrency;
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
            catch (Exception ex)
            {
                return new CreateOrderReportForUserOutputModel
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }

        public async Task<CreateProductAndStorageReportForUserOutputModel> CreateProductAndStorageReportForUser(CreateProductAndStorageReportForUserInputModel inputModel)
        {
            var workbook = new XLWorkbook();
            var worksheet = workbook.AddWorksheet("Product and Storage Report");
            try
            {
                var predicate = CreateProductAndStorageReportFilterBuilder(inputModel);

                var storageList = await _storaRepository.GetFilteredStoragesWithProductAndUser(predicate);

                var storage = storageList.First();

                worksheet.Cell(1, (int)ProductAndStorageColumn.storageNameColumn).Value = "Storage Name";
                worksheet.Cell(1, (int)ProductAndStorageColumn.storageAdressColumn).Value = "Storage Adress";
                worksheet.Cell(1, (int)ProductAndStorageColumn.storageOwnerColumn).Value = "Storage Owner";
                worksheet.Cell(1, (int)ProductAndStorageColumn.productsColumn).Value = "Products";
                worksheet.Cell(1, (int)ProductAndStorageColumn.productNameColumn).Value = "Product Name";
                worksheet.Cell(1, (int)ProductAndStorageColumn.productDescriptionColumn).Value = "Product Description";
                worksheet.Cell(1, (int)ProductAndStorageColumn.productPriceColumn).Value = "Product Price";
                worksheet.Cell(1, (int)ProductAndStorageColumn.productCurrencyColumn).Value = "Product Currency";
                worksheet.Cell(1, (int)ProductAndStorageColumn.productTotalValueColumn).Value = "Product Total Value";

                var startBottomRow = 2;

                worksheet.Cell(startBottomRow, (int)ProductAndStorageColumn.storageNameColumn).Value = storage.Name;
                worksheet.Cell(startBottomRow, (int)ProductAndStorageColumn.storageAdressColumn).Value = storage.Adress;
                worksheet.Cell(startBottomRow, (int)ProductAndStorageColumn.storageOwnerColumn).Value = storage.User.Name + " " + storage.User.Surname;

                storage.Products.ForEach(product =>
                {
                    worksheet.Cell(startBottomRow, (int)ProductAndStorageColumn.productNameColumn).Value = product.Name;
                    worksheet.Cell(startBottomRow, (int)ProductAndStorageColumn.productDescriptionColumn).Value = product.Description;
                    worksheet.Cell(startBottomRow, (int)ProductAndStorageColumn.productPriceColumn).Value = product.Price;
                    worksheet.Cell(startBottomRow, (int)ProductAndStorageColumn.productCurrencyColumn).Value = product.PriceCurrency;
                    worksheet.Cell(2, (int)ProductAndStorageColumn.productTotalValueColumn).Value = storage.Products.Sum(a => a.Price);

                    startBottomRow++;
                });

                SaveLocationForExcelReports(workbook, "ProductAndStorageReportForUser");

                return new CreateProductAndStorageReportForUserOutputModel
                {
                    IsSuccess = true,
                    Message = "Report Saved"
                };
            }
            catch (Exception ex)
            {
                return new CreateProductAndStorageReportForUserOutputModel
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
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