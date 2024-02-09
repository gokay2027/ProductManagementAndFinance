using Microsoft.AspNetCore.Mvc;
using ProductManagementAndFinanceApi.Application.Queries.Abstract;
using ProductManagementAndFinanceApi.Models.Query.Finance;

namespace ProductManagementAndFinanceApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class FinanceController : ControllerBase
    {
        private readonly IFinanceQuery _financeQuery;

        public FinanceController(IFinanceQuery financeQuery)
        {
            _financeQuery = financeQuery;
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