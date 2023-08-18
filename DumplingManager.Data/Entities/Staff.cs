namespace DumplingManager.Data.Entities
{
    public class Staff : BaseEntity
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        public int DiscountWithQuantity { get; set; }
        public double DiscountPercent { get; set; }
        public double DiscountOne { get; set; }

        public IEnumerable<Order> Orders { get; set; }
    }
}