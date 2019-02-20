using System;

namespace SecKill.Application.Models
{
    public class GoodsBase
    {
        public Guid GoodsId { get; set; }

        public string GoodsName { get; set; }

        public string Img { get; set; }
    }

    public class Goods : GoodsBase
    {

        public double Price { get; set; }

        /// <summary>
        /// 库存数量
        /// </summary>
        public int StockCount { get; set; }
    }
}
