namespace ProductManagementAndFinanceApi.Models.Query.Finance
{
    public class FinanceSearchModel
    {
        public int? MinTotalSales { get; set; }
        public int? MaxTotalSales { get; set; }

        public float? MinTotalDebt { get; set; }
        public float? MaxTotalDebt { get; set; }

        public float? MinTotalProfit { get; set; }
        public float? MaxTotalProfit { get; set; }
        public Guid? UserId { get; set; }
    }
}