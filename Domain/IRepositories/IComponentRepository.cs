using Domain.Entities;

namespace Domain.IRepositories
{
    public interface IComponentRepository : IBaseRepository<Component>
    {
        Task<Component> GetByNameAsync(string name);
    }
}
