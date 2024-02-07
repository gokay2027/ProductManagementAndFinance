using Entities.AbstractEntity;

namespace Entities.ConcreteEntity
{
    public class Category : BaseEntity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }

        //Has
        public List<Product> Products { get; private set; } = new List<Product>();

        public Category()
        { }

        public Category(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public void UpdateCategory(string name, string description)
        {
            Name = name;
            Description = description;
            SetUpdateDate();
        }
    }
}