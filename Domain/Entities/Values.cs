using Domain.Entities.SoftDelete.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Values : BaseEntity, ISoftDelete
    {
        public string name { get; set; }

        public int attributeId { get; set; }

        public bool IsDeleted { get; set; }

        public DateTimeOffset? DeletedAt { get; set; }
    }
}
