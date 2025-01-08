using Core.Models.Bugs;

namespace Core.Utilities
{
    public class FilterFactory : IFilterFactory
    {
        public List<Filter> Create(SearchViewModel searchView)
        {
            var filters = new List<Filter>
            {
                new Filter(nameof(searchView.Id), searchView.Id == 0 ? string.Empty : searchView.Id.ToString()!),
                new Filter(nameof(searchView.Title), searchView.Title ?? string.Empty),
                new Filter(nameof(searchView.Priority), searchView.Priority.ToString() ?? string.Empty),
                new Filter(nameof(searchView.Status), searchView.Status.ToString() ?? string.Empty),
                new Filter(nameof(searchView.AssignedTo), searchView.AssignedTo ?? string.Empty)
            };

            return filters;
        }

        private void Process() { }
    }
}
