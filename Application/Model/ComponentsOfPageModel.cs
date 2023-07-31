using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Model
{
    public class ComponentsOfPageModel
    {
        public int _id { get; set; }

        public string componentName { get; set; }

        public string name { get; set; }

        public List<Value> values { get; set; }
    }
}
