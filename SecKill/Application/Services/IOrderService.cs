using SecKill.Application.Models;
using SecKill.Domain.AggregatesModel;
using System;

namespace SecKill.Application.Services
{
    public interface IOrderService
    {

        SeckillOrder GetSeckillOrderBy(Guid userId, Guid goodsId);

        /// <summary>
        /// 尝试创建订单
        /// </summary>
        /// <param name="order"></param>
        void TryCreateOrder(SeckillOrder order);
    }
}
