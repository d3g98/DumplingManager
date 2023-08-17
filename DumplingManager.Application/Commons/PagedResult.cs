namespace DumplingManager.Application.Commons
{
    public class PagedResult<T>
    {
        public PagedResult()
        {
            page = 1;
            pageSize = 1;
            totalPage = 1;
            items = new List<T>();
        }

        public int page { get; set; }
        public int pageSize { get; set; }
        public int totalPage { get; set; }
        public List<T> items { get; set; }
    }
}
