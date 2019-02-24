using SecKill.Domain.AggregatesModel;
using SecKill.Infrastructure;
using System;
using System.Threading.Tasks;

namespace SecKill.Application.Services
{
    public interface IOrderService
    {

        SeckillOrder GetSeckillOrderBy(Guid userId, Guid goodsId);

        Task<SeckillOrder> GetSeckillOrderByAsync(Guid userId, Guid goodsId);

        /// <summary>
        /// 尝试创建订单
        /// </summary>
        /// <param name="order">订单信息</param>
        /// <param name="message">消息</param>
        /// <returns></returns>
        bool TryCreateOrder(SeckillOrder order, out CodeMessage message);
    }
}
