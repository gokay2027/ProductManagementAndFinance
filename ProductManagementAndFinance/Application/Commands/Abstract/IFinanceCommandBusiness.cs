using ProductManagementAndFinance.Models.AbstractOutputModel.Command;
using ProductManagementAndFinanceApi.Models.Command.Finance;

namespace ProductManagementAndFinanceApi.Application.Commands.Abstract
{
    public interface IFinanceCommandBusiness
    {
        /// <summary>
        /// Creates (as excel export) order reports and sum of money bill for user
        /// </summary>
        /// <param name="inputModel"></param>
        /// <returns></returns>
        BaseCommandOutputModel CreateOrderReportForUser(CreateOrderReportForUserInputModel inputModel);

        /// <summary>
        /// Creates (as excel export) finance reports (total debt, total sales and total profit) for user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        BaseCommandOutputModel CreateFinanceReportForUser(CreateFinanceReportForUserInputModel inputModel);

        /// <summary>
        /// Creates (as excel export) product and storage report (product count and sold) for user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        BaseCommandOutputModel CreateProductAndStorageReportForUser(CreateProductAndStorageReportForUserInputModel inputModel);
    }
}