using Domain.Entities.SoftDelete.Abstraction;

namespace Domain.Entities
{
    public class PageComponent: BaseEntity, ISoftDelete
    {
        public int componentId { get; set; }

        public string name { get; set; }

        public int pageId { get; set; }

        public List<Value>? values { get; set; }

        public bool IsDeleted { get; set; }

        public DateTimeOffset? DeletedAt { get; set; }
    }
}
