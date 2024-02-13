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

        //public BaseCommandOutputModel CreateOrderReportForUser(CreateOrderReportForUserInputModel inputModel)
        //{
        //    throw new NotImplementedException();
        //}

        //public BaseCommandOutputModel CreateProductAndStorageReportForUser(CreateProductAndStorageReportForUserInputModel inputModel)
        //{
        //    throw new NotImplementedException();
        //}

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