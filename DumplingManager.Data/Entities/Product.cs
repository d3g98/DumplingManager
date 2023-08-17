﻿namespace DumplingManager.Data.Entities
{
    public class Product : BaseEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public double Price2 { get; set; }
        public double Price3 { get; set; }
        public double Price4 { get; set; }
        public double Price5 { get; set; }
        public string Image { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }
    }
}