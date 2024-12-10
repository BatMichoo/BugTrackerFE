namespace Core.Utilities
{
    public class PagingInfo
    {
        public int CurrentPage { get; set; }
        public int ElementsPerPage { get; set; }
        public int PageCount { get; set; }
        public bool HasPrevious { get; set; }
        public bool HasNext { get; set; }
        public int TotalElementCount { get; set; }
    }
}
