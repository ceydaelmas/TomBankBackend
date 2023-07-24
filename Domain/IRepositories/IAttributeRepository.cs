using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Attribute = Domain.Entities.Attribute;

namespace Domain.IRepositories
{
    public interface IAttributeRepository : IBaseRepository<Attribute>
    {
    }
}
