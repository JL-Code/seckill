using SecKill.Domain.SeedWork;
using System;

namespace SecKill.Domain.AggregatesModel
{
    public class User : Entity, IAggregateRoot
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        /// <value>The user identifier.</value>
        public Guid UserId { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        /// <value>The name of the user.</value>
        public string UserName { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }
    }

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
    }

    /// <summary>
    /// 秒杀订单
    /// </summary>
    public class SeckillOrder : Entity, IAggregateRoot
    {

        public Guid OrderId { get; set; }

        /// <summary>
        /// 订单状态
        /// </summary>
        public string OrderState { get; set; }

        public DateTime OrderDate { get; set; }

        /// <summary>
        /// 支付方式
        /// </summary>
        public string PaymentTerms { get; set; }

        // TODO: 1.收货信息是否应该是采用复杂类型 2.商品的冗余信息、商品快照体现

        public double GoodsPrice { get; set; }
        public string GoodsName { get; set; }

        /// <summary>
        /// 简单的收货地址
        /// </summary>
        public string Address { get; set; }
    }
}
