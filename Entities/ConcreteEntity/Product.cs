using Entities.AbstractEntity;

namespace Entities.ConcreteEntity
{
    public class Product : BaseEntity
    {
        public string? Name { get; private set; }
        public string? Description { get; private set; }
        public float? Price { get; private set; }
        public string? PriceCurrency { get; private set; }

        //Owned
        public Guid? CategoryId { get; private set; }

        public Category Category { get; private set; }

        public Guid? StorageId { get; private set; }
        public Storage? Storage { get; private set; }

        //Has
        public Guid? OrderId { get; private set; }

        public Order? Order { get; private set; }

        public Product()
        { }

        public Product(string name, string description, float price, string priceCurrency)
        {
            Name = name;
            Description = description;
            Price = price;
            PriceCurrency = priceCurrency;
        }

        public Product(string name, string description, float price, string priceCurrency, Guid categoryId, Guid storageId)
        {
            Name = name;
            Description = description;
            Price = price;
            PriceCurrency = priceCurrency;
            StorageId = storageId;
            CategoryId = categoryId;
        }

        public void SetProduct(string name, string description, float price, string priceCurrency, Guid categoryId, Guid storageId)
        {
            Name = name;
            Description = description;
            Price = price;
            PriceCurrency = priceCurrency;
            StorageId = storageId;
            CategoryId = categoryId;
            SetUpdateDate();
        }
    }
}