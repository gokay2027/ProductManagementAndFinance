using Entities.AbstractEntity;

namespace Entities.ConcreteEntity
{
    public class Storage : BaseEntity
    {
        public string Adress { get; private set; }
        public string Name { get; private set; }
        public List<Product> Products { get; private set; } = new List<Product>();

        public Guid? UserId { get; private set; }
        public User User { get; private set; }

        public Storage()
        { }

        public Storage(string adress, string name, Guid userId)
        {
            Adress = adress;
            Name = name;
            UserId = userId;
        }

        public void UpdateStorage(string adress, string name, Guid userId)
        {
            Adress = adress;
            Name = name;
            UserId = userId;
            SetUpdateDate();
        }

        public void AddProductToStorage(Product product)
        {
            Products.Add(product);
        }
    }
}