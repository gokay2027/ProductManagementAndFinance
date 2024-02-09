namespace ProductManagementAndFinanceApi.Models.Query.Finance
{
    public class FinanceSearchModel
    {
        public int? MinTotalSales { get; set; }
        public int? MaxTotalSales { get; set; }

        public float? MinTotalDeby { get; set; }
        public float? MaxTotalDeby { get; set; }

        public float? MinTotalProfit { get; set; }
        public float? MaxTotalProfit { get; set; }
        public Guid? UserId { get; set; }
    }
}