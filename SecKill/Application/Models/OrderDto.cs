using SecKill.Domain.AggregatesModel;
using System;

namespace SecKill.Application.Models
{
    /// <summary>
    /// 订单信息
    /// </summary>
    public class OrderDto
    {
        public Guid OrderId { get; set; }

        /// <summary>
        /// 订单状态
        /// </summary>
        public OrderState OrderState { get; set; }

        public DateTime OrderDate { get; set; }

        /// <summary>
        /// 支付方式
        /// </summary>
        public string PaymentTerms { get; set; }

        // TODO: 1.收货信息是否应该是采用复杂类型 2.商品的冗余信息、商品快照体现
        public Guid GoodsId { get; set; }
        public double GoodsPrice { get; set; }
        public string GoodsName { get; set; }

        public int Quantity { get; set; }

        /// <summary>
        /// 简单的收货地址
        /// </summary>
        public string Address { get; set; }

        public SeckillGoods Goods { get; set; }
    }
}
