using System.ComponentModel.DataAnnotations.Schema;

namespace PGDemo.Model
{
    [Table("order_item")]
    public class OrderItem
    {
        [Column(name: "id")]
        public int Id { get; set; }

        [Column(name: "product_id")]
        public int ProductId { get; set; }

        [Column(name: "order_id")]
        public int OrderId { get; set; }

        [Column(name: "price")]
        public decimal Price { get; set; }
    }
}
