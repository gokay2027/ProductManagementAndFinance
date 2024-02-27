using ProductManagementAndFinance.Models.AbstractOutputModel.Query;

namespace ProductManagementAndFinanceApi.Models.Query.Order
{
    public class OrderListOutputModel : BaseQueryOutputModel
    {
        public List<OrderListItem> OutputList { get; set; } = new List<OrderListItem>();
    }

    public class OrderListItem
    {
        public string CustomerNameSurname { get; set; }
        public float TotalPrice { get; set; }
        public string Adress { get; set; }
        public List<string> ProductNames { get; set; } = new List<string>();
    }
}