namespace DumplingManager.Application.Commons
{
    public class TransactionFilter : BaseFilterRequest
    {
        public string FromDate { set; get; }

        public string ToDate { set; get; }

        public DateTime GetFromDate()
        {
            if (FromDate == null) FromDate = Defaults.MinDate.ToString(Defaults.DateFormatFilter);
            return DateTime.ParseExact(FromDate, Defaults.DateFormatFilter, null);
        }

        public DateTime GetToDate()
        {
            if (ToDate == null) ToDate = Defaults.MaxDate.ToString(Defaults.DateFormatFilter);
            return DateTime.ParseExact(ToDate, Defaults.DateFormatFilter, null);
        }
    }
}