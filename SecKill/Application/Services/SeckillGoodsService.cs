using SecKill.Application.Models;
using SecKill.Domain.AggregatesModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SecKill.Application.Services
{
    public class SeckillGoodsService : ISeckillGoodsService
    {
        readonly ISeckillGoodsRepository _repository;

        public SeckillGoodsService(ISeckillGoodsRepository repository)
        {
            _repository = repository;
        }

        public bool CanDeductInventory(Guid goodsId, int quantity)
        {
            var goods = _repository.Get(m => m.GoodsId == goodsId);
            if (goods == null)
                return false;
            if (goods.Quantity - quantity < 0)
                return false;
            return true;
        }

        /// <summary>
        /// 减库存
        /// </summary>
        /// <param name="goodsId"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public bool DeductInventory(Guid goodsId, int quantity)
        {
            var goods = _repository.Get(m => m.GoodsId == goodsId);
            if (CanDeductInventory(goodsId, quantity))
            {
                goods.Quantity -= quantity;
                _repository.Update(goods);
                return true;
            }
            return false;
        }

        public SeckillGoods GetById(Guid id)
        {
            return _repository.Get(id);
        }

        public List<SeckillGoodsDto> ListSeckillGoods()
        {
            var entities = _repository.ListEntities().ToList();
            return entities.Select(entity => new SeckillGoodsDto
            {
                GoodsId = entity.GoodsId,
                GoodsName = entity.GoodsName,
                Quantity = entity.Quantity,
                EndDate = entity.EndDate,
                SeckillGoodsId = entity.SeckillGoodsId,
                StartDate = entity.StartDate,
                SeckillPrice = entity.SeckillPrice,
                PictureUrl = entity.PictureUrl
            }).ToList();
        }
    }
}
