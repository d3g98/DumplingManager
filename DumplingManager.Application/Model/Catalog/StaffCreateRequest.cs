namespace DumplingManager.Application.Model.Catalog
{
    public class StaffCreateRequest
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int DiscountWithQuantity { get; set; }
        public double DiscountOne { get; set; }
        public double DiscountPercent { get; set; }
        public string Note { get; set; }
    }
}
