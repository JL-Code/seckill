using SecKill.Application.Models;
using SecKill.Domain.AggregatesModel;
using SecKill.Infrastructure.Exceptions;
using System;

namespace SecKill.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly ISeckillGoodsService _seckillGoodsService;
        private readonly ISecKillOrderRepository _repository;

        public OrderService(ISecKillOrderRepository repository, ISeckillGoodsService seckillGoodsService)
        {
            _repository = repository;
            _seckillGoodsService = seckillGoodsService;
        }

        public SeckillOrder GetSeckillOrderBy(Guid userId, Guid goodsId)
        {
            var order = _repository.Get(m => m.UserId == userId && m.GoodsId == goodsId);
            return order;
        }

        public void TryCreateOrder(SeckillOrder order)
        {
            var success = _seckillGoodsService.DeductInventory(order.GoodsId, order.Quantity);
            if (!success)
                throw new BusinessException("扣减库存失败");
            _repository.Add(order);
        }
    }
}
