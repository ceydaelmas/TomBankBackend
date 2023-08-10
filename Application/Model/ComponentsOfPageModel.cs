using Domain.Entities;

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
