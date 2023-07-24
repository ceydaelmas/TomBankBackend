using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Component
{
    public static class ComponentPropertiesConfig
    {
        public static readonly Dictionary<string, List<string>> ComponentProperties = new Dictionary<string, List<string>>
        {
            { "Input", new List<string> { "color", "placeholder", "size" } },
            { "Checkbox", new List<string> { "color", "isChecked" } },
        };
    }
}