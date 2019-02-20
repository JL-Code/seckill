using SecKill.Domain.SeedWork;

namespace SecKill.Domain.AggregatesModel
{
    /// <summary>
    /// 秒杀订单
    /// </summary>
    public interface ISecKillOrderRepository : IRepository<SeckillOrder> { }
}
