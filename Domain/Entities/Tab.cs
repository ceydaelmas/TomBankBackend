﻿using Domain.Entities.SoftDelete.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Tab :BaseEntity, ISoftDelete
    {
        public int? parentId { get; set; }

        public string path { get; set; }

        public string name { get; set; }

        public string fullPath { get; set; }

        public bool IsDeleted { get ; set; }

        public DateTimeOffset? DeletedAt { get; set; }
    }
}
