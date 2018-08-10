using System.ComponentModel.DataAnnotations.Schema;

namespace PGDemo.DBModel
{
    [Table("order_item")]
    public class OrderItem
    {
        [Column(name: "id")]
        public int Id { get; set; }

        [Column(name: "price")]
        public decimal Price { get; set; }

        /// <summary>
        /// 订单外键
        /// </summary>
        [Column(name: "order_id")]
        public int OrderId { get; set; }

        /// <summary>
        /// 订单主表
        /// </summary>
        public Order Order { get; set; }

        /// <summary>
        /// 产品外键
        /// </summary>
        [Column(name: "product_id")]
        public int ProductId { get; set; }

        /// <summary>
        /// 产品
        /// </summary>
        public Product Product { get; set; }
    }
}
