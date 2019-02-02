using SecKill.Domain.SeedWork;

namespace SecKill.Domain.AggregatesModel
{
    public interface IUserRepository : IRepository<User>
    {
    }

    public interface IGoodsRepository : IRepository<Goods> { }


    /// <summary>
    /// 秒杀订单
    /// </summary>
    public interface ISecKillOrderRepository : IRepository<SeckillOrder> { }

    /// <summary>
    /// 秒杀商品
    /// </summary>
    public interface ISeckillGoodsRepository : IRepository<SeckillGoods> { }
}
