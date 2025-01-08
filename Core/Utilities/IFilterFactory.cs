using Core.Models.Bugs;

namespace Core.Utilities
{
    public interface IFilterFactory
    {
        List<Filter> Create(SearchViewModel searchView);
    }
}
