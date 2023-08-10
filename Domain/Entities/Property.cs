using Domain.Entities.SoftDelete.Abstraction;

namespace Domain.Entities
{
    public class Property : BaseEntity, ISoftDelete
    {
        public string name { get; set; }

        public bool IsDeleted { get; set; }

        public DateTimeOffset? DeletedAt { get; set; }
    }
}
