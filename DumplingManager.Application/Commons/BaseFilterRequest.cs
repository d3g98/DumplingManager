namespace DumplingManager.Application.Commons
{
    public class BaseFilterRequest
    {
        private int page;

        private int pageSize;

        public int Page
        {
            set { page = value; }
            get { if (page <= 0) page = 1; return page; }
        }

        public int PageSize
        {
            set { pageSize = value; }
            get { if (pageSize <= 0) pageSize = Defaults.PageSize; return pageSize; }
        }
    }
}