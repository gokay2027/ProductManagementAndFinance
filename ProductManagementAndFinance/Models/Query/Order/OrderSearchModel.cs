namespace ProductManagementAndFinanceApi.Models.Query.Order
{
    public class OrderSearchModel
    {
        public float? MinTotalPrice { get;  set; }
        public float? MaxTotalPrice { get; set; }

        public string? Adress { get;  set; }
        public Guid? UserId { get;  set; }
    }
}
