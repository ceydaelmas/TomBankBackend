using Domain.Entities;

namespace Domain.IRepositories
{
    public interface IPageComponentRepository : IBaseRepository<PageComponent>
    {
        Task<PageComponent> GetByNameAsync(string name);
        Task<IEnumerable<PageComponent>> GetComponentsByPageNameAsync(int pageId);

    }
}
