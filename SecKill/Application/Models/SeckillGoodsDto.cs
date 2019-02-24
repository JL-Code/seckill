using System;

namespace SecKill.Application.Models
{
    /// <summary>
    /// 秒杀商品
    /// </summary>
    public class SeckillGoodsDto : GoodsBase
    {
        public Guid SeckillGoodsId { get; set; }

        public double SeckillPrice { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int StockCount { get; set; }
    }
}
