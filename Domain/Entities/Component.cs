using Domain.Entities.SoftDelete.Abstraction;

namespace Domain.Entities
{
    public class Component : BaseEntity, ISoftDelete
    {

        public string name { get; set; }

        public List<Property> properties { get; set; }

        public bool IsDeleted { get; set; }

        public DateTimeOffset? DeletedAt { get; set; }
    }
}
