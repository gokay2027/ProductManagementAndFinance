using Entities.ConcreteEntity;
using LinqKit;
using ProductManagementAndFinanceApi.Application.Queries.Abstract;
using ProductManagementAndFinanceApi.Models.Query.Finance;
using ProductManagementAndFinanceData.Repository.EntityRepository.Abstract;

namespace ProductManagementAndFinanceApi.Application.Queries.Concrete
{
    public class FinanceQuery : IFinanceQuery
    {
        private readonly IFinanceRepository _financeRepository;

        public FinanceQuery(IFinanceRepository financeRepository)
        {
            _financeRepository = financeRepository;
        }

        public async Task<FinanceListOutputModel> GetAllFinances()
        {
            var output = new FinanceListOutputModel();
            try
            {
                var allFinancesList = await _financeRepository.GetAllFinancesWithUser();
                foreach (var finance in allFinancesList)
                {
                    output.OutputList.Add(new FinanceListItemModel
                    {
                        TotalDeby = finance.TotalDeby,
                        TotalProfit = finance.TotalProfit,
                        TotalSales = finance.TotalSales,
                        UserId = finance.UserId,
                        NameOfUser = finance.User.Name,
                        SurnameOfUser = finance.User.Surname,
                        UsernameOfUser = finance.User.UserName
                    });
                }
                output.Message = "Finances Queried successfully";
                output.IsSuccess = true;
                return output;
            }
            catch (Exception ex)
            {
                output.Message = ex.Message;
                output.IsSuccess = false;
                return output;
            }
        }

        public async Task<FinanceListOutputModel> GetFinancesByFilter(FinanceSearchModel searchModel)
        {
            var output = new FinanceListOutputModel();
            try
            {
                var filterBuilderForFinances = FilterBuilderForFinances(searchModel);
                var allFinancesList = await _financeRepository.GetFilteredFinancesWithUser(filterBuilderForFinances);
                foreach (var finance in allFinancesList)
                {
                    output.OutputList.Add(new FinanceListItemModel
                    {
                        TotalDeby = finance.TotalDeby,
                        TotalProfit = finance.TotalProfit,
                        TotalSales = finance.TotalSales,
                        UserId = finance.UserId,
                        NameOfUser = finance.User.Name,
                        SurnameOfUser = finance.User.Surname,
                        UsernameOfUser = finance.User.UserName
                    });
                }
                output.Message = "Finances Queried successfully";
                output.IsSuccess = true;
                return output;
            }
            catch (Exception ex)
            {
                output.Message = ex.Message;
                output.IsSuccess = false;
                return output;
            }
        }

        private static ExpressionStarter<Finance> FilterBuilderForFinances(FinanceSearchModel searchModel)
        {
            var predicate = PredicateBuilder.New<Finance>();

            if (searchModel.MinTotalProfit.HasValue && searchModel.MaxTotalProfit.HasValue)
                predicate.And(a => a.TotalProfit >= searchModel.MinTotalProfit && a.TotalProfit <= searchModel.MaxTotalProfit);

            if (searchModel.UserId.HasValue)
                predicate.And(a => a.UserId.Equals(searchModel.UserId));

            if (searchModel.MinTotalSales.HasValue && searchModel.MaxTotalSales.HasValue)
                predicate.And(a => a.TotalSales >= searchModel.MinTotalSales && a.TotalSales >= searchModel.MaxTotalSales);

            if (searchModel.MinTotalDeby.HasValue && searchModel.MaxTotalDeby.HasValue)
                predicate.And(a => a.TotalDeby >= searchModel.MinTotalDeby && a.TotalDeby <= searchModel.MaxTotalDeby);

            return predicate;
        }
    }
}