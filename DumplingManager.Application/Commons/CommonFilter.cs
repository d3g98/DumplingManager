namespace DumplingManager.Application.Commons
{
    public class CustomFilterParam<T>
    {
        public T? data { get; set; }
        public string? search { get; set; }

        public int? page
        {
            set
            {
                page = value;
            }

            get
            {
                if (page == null || page == 0) return 1; else return page;
            }
        }

        public int? pageSize
        {
            set
            {
                pageSize = value;
            }

            get
            {
                if (pageSize == null || pageSize == 0) return 20; else return pageSize;
            }
        }
    }
}