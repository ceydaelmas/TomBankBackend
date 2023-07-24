using Domain.Entities.SoftDelete.Abstraction;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Attribute : BaseEntity, ISoftDelete
    {
        public string name { get; set; }

        public string valueName { get; set; }

        public int componentId { get; set; }

        public bool IsDeleted { get; set; }

        public DateTimeOffset? DeletedAt { get; set; }
    }
}
