using SecKill.Domain.SeedWork;
using System;

namespace SecKill.Domain.AggregatesModel
{
    // TODO: 可以研究下类继承对EF生成表结构的影响
    /// <summary>
    /// 秒杀商品
    /// </summary>
    public class SeckillGoods : Entity, IAggregateRoot
    {
        public Guid SeckillGoodsId { get; set; }

        public Guid GoodsId { get; set; }

        public string GoodsName { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        /// <summary>
        /// 秒杀价格
        /// </summary>
        public double SeckillPrice { get; set; }

        /// <summary>
        /// 放出的秒杀数量
        /// </summary>
        public int Quantity { get; set; }

        public string PictureUrl { get; set; }
    }
}
