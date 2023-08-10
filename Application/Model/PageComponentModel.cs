using Domain.Entities;


namespace Application.Model
{
    public class PageComponentModel
    {
        public int _id { get; set; }

        public string componentName { get; set; }

        public string name { get; set; }

        public string pageName { get; set; }

        public List<Value> values { get; set; }

    }
}
