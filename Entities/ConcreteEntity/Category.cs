using Entities.AbstractEntity;

namespace Entities.ConcreteEntity
{
    public class Category : BaseEntity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }

        //Has
        public List<Product> Products { get; set; } = new List<Product>();

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