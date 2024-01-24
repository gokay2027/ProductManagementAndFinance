using Entities.AbstractEntity;

namespace Entities.ConcreteEntity
{
    public class Order : BaseEntity
    {
        public List<Product>? Products { get; private set; } = new List<Product>();
        public float? TotalPrice { get; private set; }
        public string? Adress { get; private set; }

        public Guid? UserId { get; private set; }
        public User? User { get; private set; }

        public Order()
        {
        }

        public Order(User user, float totalPrice, string adress)
        {
            User = user;
            TotalPrice = totalPrice;
            Adress = adress;
        }

        public void UpdateOrder(User user, float totalPrice, string adress)
        {
            User = user;
            TotalPrice = totalPrice;
            Adress = adress;
            SetUpdateDate();
        }

        public void SetTotalPrice(float price)
        {
            TotalPrice = price;
        }

        public void AddProductToOrder(Product product)
        {
            Products.Add(product);
        }
    }
}