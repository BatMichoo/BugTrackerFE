namespace Core.Utilities
{
    public class PagedList<T> where T : class
    {        
        public PagingInfo PageInfo { get; set; } = new PagingInfo();
        public int ResultItemCount { get; set; }

        public List<T> Items { get; set; } = new List<T>();
    }
}
