using SecKill.Domain.SeedWork;
using System;

namespace SecKill.Domain.AggregatesModel
{
    /// <summary>
    /// 秒杀订单
    /// </summary>
    public class SeckillOrder : Entity, IAggregateRoot
    {
        public Guid OrderId { get; set; }

        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderNumber { get; set; }

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

        public Guid UserId { get; set; }
    }

    public enum OrderState
    {
        Draft = 0,

        // 未支付
        UnPaid = 1,

        // 已支付
        Paid = 2,

        // 订单关闭
        Closed = 99
    }
}
