using SecKill.Domain.SeedWork;
using System;

namespace SecKill.Domain.AggregatesModel
{
    /// <summary>
    /// 商品
    /// </summary>
    public class Goods : Entity, IAggregateRoot
    {
        public Guid GoodsId { get; set; }

        public string GoodsName { get; set; }

        public double Price { get; set; }

        /// <summary>
        /// 库存数量
        /// </summary>
        public int StockCount { get; set; }
    }
}
