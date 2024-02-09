using Entities.ConcreteEntity;
using ProductManagementAndFinanceApi.Models.Query.Finance;
using System.Linq.Expressions;

namespace ProductManagementAndFinanceApi.Application.Queries.Abstract
{
    public interface IFinanceQuery
    {
        /// <summary>
        /// Gets all Finances
        /// </summary>
        /// <returns></returns>
        Task<FinanceListOutputModel> GetAllFinances();

        /// <summary>
        /// Gets finances by filter
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<FinanceListOutputModel> GetFinancesByFilter(FinanceSearchModel searchModel);
    }
}