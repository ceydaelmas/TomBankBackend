using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Model
{
    public class ComponentModel
    {
        public int _id { get; set; }

        public string name { get; set; }

        public int pageId { get; set; }

        public List<AttributeModel> attributes { get; set; }
    }
}
