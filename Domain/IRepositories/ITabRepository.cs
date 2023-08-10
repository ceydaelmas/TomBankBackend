using Domain.Entities;
namespace Domain.IRepositories
{
    public interface ITabRepository : IBaseRepository<Tab>
    {
        Task<Tab> GetByNameAsync(string name);
        Task<int> GetIdByNameAsync(string tabName);
        Task<bool> ExistsAsync(string tabName);
        Task<List<Tab>> GetSelectableParentTabs(int id);
        
    }
}
