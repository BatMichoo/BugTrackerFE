using System.Text;

namespace Core.Utilities
{
    public class FilterService
    {
        private const string _keyWord = "filter";
        private const string _keyValueDel = ":";
        private const string _filterDel = ";";

        public string JoinFiltersForQueryString(List<Filter> filters)
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.Append($"{_keyWord}=");

            foreach (var filter in filters)
            {
                string serialized = filter.ToString(_keyValueDel);

                if (serialized != string.Empty)
                {
                    stringBuilder.Append(serialized + _filterDel);
                }
            }

            return stringBuilder.ToString().Trim();
        }
    }
}
