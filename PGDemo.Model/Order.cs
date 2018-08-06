using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PGDemo.Model
{
    [Table("order")]
    public class Order
    {
        [Column(name: "id")]
        public int Id { get; set; }

        [Column(name: "title")]
        public string Title { get; set; }

        [Column(name: "total_price")]
        public decimal TotalPrice { get; set; }

        [Column(name: "total_amount")]
        public int TotalAmount { get; set; }

        [Column(name: "create_date")]
        public DateTime CreateTime { get; set; }
    }
}
