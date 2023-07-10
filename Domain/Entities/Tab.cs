using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Tab :BaseEntity
    {
        public int? parentId { get; set; }

        public string path { get; set; }

        public string name { get; set; }

        public string fullPath { get; set; }
    }
}
