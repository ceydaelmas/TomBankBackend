using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepositories
{
    public interface IPropertyRepository : IBaseRepository<Property>
    {
        Task<Property> GetByNameAsync(string name);
    }
}
