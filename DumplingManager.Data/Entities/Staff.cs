namespace DumplingManager.Data.Entities
{
    public class Staff : BaseEntity
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public decimal Discount { get; set; }

        public IEnumerable<Order> Orders { get; set; }
    }
}