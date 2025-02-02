using Core.Models.Bugs;

namespace Core.Utilities
{
    public class FilterFactory : IFilterFactory
    {
        public List<Filter> Create(SearchViewModel searchView)
        {
            var filters = new List<Filter>();
            var props = searchView.GetType().GetProperties();

            foreach (var prop in props)
            {
                var value = prop.GetValue(searchView);

                if (value != null)
                {
                    filters.Add(new Filter(prop.Name, value.ToString()!));
                }
            }

            return filters;
        }

        private void Process() { }
    }
}
