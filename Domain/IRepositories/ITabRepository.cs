using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepositories
{
    public interface ITabRepository : IBaseRepository<Tab>
    {
        Task<Tab> GetByNameAsync(string name);
        Task<int> GetIdByNameAsync(string tabName);
        Task<bool> ExistsAsync(string tabName);
        string GetNameById(int? id);
        Task<List<Tab>> GetSelectableParentTabs(int id);
        Task<List<Tab>> GetByParentIdAsync(int id);
    }
}
