namespace Core.Utilities
{
    public class Filter
    {
        private readonly string _key = string.Empty;
        private readonly string _value = string.Empty;

        public Filter(string key, string value)
        {
            _key = key;
            _value = value;
        }

        public string ToString(string delimiter)
        {
            if (string.IsNullOrEmpty(_key) || string.IsNullOrEmpty(_value))
                return string.Empty;

            return $"{_key}{delimiter}{_value}";
        }
    }
}
