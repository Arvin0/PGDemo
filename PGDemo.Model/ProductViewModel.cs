namespace PGDemo.Model
{
    public class ProductViewModel
    {
        /// <summary>
        /// 产品ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 产品名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 产品分类
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// 产品分类
        /// </summary>
        public string CategoryB { get; set; }

        /// <summary>
        /// 产品描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 产品价格
        /// </summary>
        public decimal Price { get; set; }
    }
}
