namespace DumplingManager.Application.Commons
{
    public class Defaults
    {
        public const int PageSize = 20;
        public const string DateFormatFilter = "dd/MM/yyyy";
        public static readonly DateTime MinDate = new DateTime(2000, 1, 1);
        public static readonly DateTime MaxDate = new DateTime(2100, 1, 1);

        public const string FolderImage = "uploads/Images/";
        public const string FolderImageProduct = "Product";
    }
}
