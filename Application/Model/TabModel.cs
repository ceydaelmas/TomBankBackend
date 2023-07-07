using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Model
{

        public class TabModel
        {
            public int _id { get; set; }

            public int parentId { get; set; }

            public string path { get; set; }

            public string name { get; set; }

            public string fullPath { get; set; }

        }
    }