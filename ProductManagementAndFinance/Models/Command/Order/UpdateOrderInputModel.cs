using Entities.ConcreteEntity;

namespace ProductManagementAndFinanceApi.Models.Command.Order
{
    public class UpdateOrderInputModel
    {
        public Guid Id { get; set; }
        public float TotalPrice { get; set; }
        public string Adress { get; set; }
        public Guid UserId { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();
    }
}