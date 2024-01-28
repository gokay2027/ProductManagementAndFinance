using Entities.AbstractEntity.AbstractEntityRule;

namespace Entities.AbstractEntity
{
    public abstract class BaseEntity : IBaseEntity
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime UpdateDate { get; set; } = DateTime.Now;
        public bool IsActive { get; set; } = true;

        public void SetUpdateDate()
        {
            UpdateDate = DateTime.Now;
        }
        public void Delete()
        {
            IsActive = false;
        }
    }
}