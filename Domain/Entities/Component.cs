using Domain.Entities.SoftDelete.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
