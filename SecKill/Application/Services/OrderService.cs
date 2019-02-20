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

        public OrderDto CreateOrder(OrderDto orderDto)
        {
            var success = _seckillGoodsService.DeductInventory(orderDto.GoodsId, orderDto.Quantity);
            if (!success)
                throw new BusinessException("扣减库存失败");
            var order = new SeckillOrder()
            {
                OrderId = Guid.NewGuid(),
                OrderDate = DateTime.Now,
                OrderState = OrderState.UnPaid,
                GoodsId = orderDto.GoodsId,
                GoodsName = orderDto.GoodsName,
                GoodsPrice = orderDto.GoodsPrice,
                PaymentTerms = orderDto.PaymentTerms,
                Address = orderDto.Address
            };
            _repository.Add(order);
            return new OrderDto();
        }
    }
}
