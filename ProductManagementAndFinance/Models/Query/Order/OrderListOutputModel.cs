using ProductManagementAndFinance.Models.AbstractOutputModel.Query;

namespace ProductManagementAndFinanceApi.Models.Query.Order
{
    public class OrderListOutputModel : BaseQueryOutputModel
    {
        public List<OrderListItem> OutputList = new List<OrderListItem>();
    }

    public class OrderListItem
    {
        public List<Entities.ConcreteEntity.Product> Products { get; set; }
        public float TotalPrice { get; set; }
        public string Adress { get; set; }
        public Guid UserId { get; set; }
        public Entities.ConcreteEntity.User User { get; set; }
    }
}