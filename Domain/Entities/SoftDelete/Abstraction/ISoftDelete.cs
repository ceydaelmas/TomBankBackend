
namespace Domain.Entities.SoftDelete.Abstraction
{
    public interface ISoftDelete
    {
        public bool IsDeleted { get; set; }
        public DateTimeOffset? DeletedAt { get; set; }
  
    }
}
