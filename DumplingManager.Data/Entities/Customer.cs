﻿namespace DumplingManager.Data.Entities
{
    public class Customer : BaseEntity
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int TypePriceId { get; set; }
        public int UseCabinet { get; set; }

        public IEnumerable<Order> Orders { get; set; }
    }
}