﻿namespace PGDemo.Model
{
    public class OrderItemViewModel
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public int OrderId { get; set; }

        public decimal Price { get; set; }
    }
}
