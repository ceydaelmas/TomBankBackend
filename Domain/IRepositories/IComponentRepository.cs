using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepositories
{
    public interface IComponentRepository : IBaseRepository<Component>
    {
        Task<Component> GetByNameAsync(string name);
    }
}
