using Entities.AbstractEntity.AbstractEntityRule;

namespace Entities.AbstractEntity
{
    public abstract class BaseEntity : IAbstractEntityRule
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime UpdateDate { get; set; } = DateTime.Now;

        public void SetUpdateDate()
        {
            UpdateDate = DateTime.Now;
        }
    }
}