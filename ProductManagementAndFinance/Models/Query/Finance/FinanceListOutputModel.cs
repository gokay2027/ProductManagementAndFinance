using ProductManagementAndFinance.Models.AbstractOutputModel.Query;

namespace ProductManagementAndFinanceApi.Models.Query.Finance
{
    public class FinanceListOutputModel : BaseQueryOutputModel
    {
        public List<FinanceListItemModel> OutputList { get; set; } = new List<FinanceListItemModel>();
    }

    public class FinanceListItemModel
    {
        public int TotalSales { get; set; }
        public float TotalDeby { get; set; }
        public float TotalProfit { get; set; }
        public Guid UserId { get; set; }

        public string? NameOfUser { get; set; }
        public string? SurnameOfUser { get; set; }
        public string? UsernameOfUser { get; set; }


    }
}