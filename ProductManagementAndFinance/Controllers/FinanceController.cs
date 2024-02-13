using Microsoft.AspNetCore.Mvc;
using ProductManagementAndFinance.Models.AbstractOutputModel.Command;
using ProductManagementAndFinanceApi.Application.Commands.Abstract;
using ProductManagementAndFinanceApi.Application.Queries.Abstract;
using ProductManagementAndFinanceApi.Models.Command.Finance;
using ProductManagementAndFinanceApi.Models.Query.Finance;

namespace ProductManagementAndFinanceApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class FinanceController : ControllerBase
    {
        private readonly IFinanceQuery _financeQuery;
        private readonly IFinanceCommandBusiness _financeCommandBusiness;

        public FinanceController(IFinanceQuery financeQuery, IFinanceCommandBusiness financeCommandBusiness)
        {
            _financeQuery = financeQuery;
            _financeCommandBusiness = financeCommandBusiness;
        }

        [HttpPost]
        public BaseCommandOutputModel CreateFinanceReportForUser([FromBody] CreateFinanceReportForUserInputModel inputModel)
        {
            return _financeCommandBusiness.CreateFinanceReportForUser(inputModel);
        }

        [HttpPost]
        public CreateOrderReportForUserOutputModel CreateOrderReportForUser([FromBody] CreateOrderReportForUserInputModel inputModel)
        {
            return _financeCommandBusiness.CreateOrderReportForUser(inputModel);
        }

        [HttpPost]
        public CreateProductAndStorageReportForUserOutputModel CreateProductAndStorageReportForUser([FromBody] CreateProductAndStorageReportForUserInputModel inputModel)
        {
            return _financeCommandBusiness.CreateProductAndStorageReportForUser(inputModel);
        }

        [HttpGet]
        public Task<FinanceListOutputModel> GetAllFinances()
        {
            return _financeQuery.GetAllFinances();
        }

        [HttpGet]
        public Task<FinanceListOutputModel> GetFinancesByFilter([FromQuery] FinanceSearchModel searchModel)
        {
            return _financeQuery.GetFinancesByFilter(searchModel);
        }
    }
}