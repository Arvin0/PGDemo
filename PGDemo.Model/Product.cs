using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace PGDemo.Model
{
    /// <summary>
    /// 产品模型
    /// </summary>
    [Table("product")]
    public class Product
    {
        /// <summary>
        /// 产品ID
        /// </summary>
        [Column(name:"id")]
        public int Id { get; set; }

        /// <summary>
        /// 产品名称
        /// </summary>
        [Column(name: "name")]
        public string Name { get; set; }

        /// <summary>
        /// 产品分类
        /// </summary>
        [Column(name: "category", TypeName = "json")]
        public string Category { get; set; }

        /// <summary>
        /// 产品分类
        /// </summary>
        [Column(name: "categoryb", TypeName = "jsonb")]
        public string CategoryB { get; set; }

        /// <summary>
        /// 产品描述
        /// </summary>
        [Column(name: "description")]
        public string Description { get; set; }

        /// <summary>
        /// 产品价格
        /// </summary>
        [Column(name: "price")]
        public decimal Price { get; set; }
    }
}
