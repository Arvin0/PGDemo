using System;
using System.Collections.Generic;

namespace PGDemo.Model
{
    public class OrderViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public decimal TotalPrice { get; set; }

        public int TotalAmount { get; set; }

        public DateTime CreateTime { get; set; }

        public IList<OrderItemViewModel> OrderItems { get; set; }
    }
}
