using Domain.Entities;

namespace Domain.IRepositories
{
    public interface IPropertyRepository : IBaseRepository<Property>
    {
        Task<Property> GetByNameAsync(string name);
    }
}
