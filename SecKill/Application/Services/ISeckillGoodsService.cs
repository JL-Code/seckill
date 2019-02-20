using SecKill.Application.Models;
using SecKill.Domain.AggregatesModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SecKill.Application.Services
{
    public interface ISeckillGoodsService
    {
        List<SeckillGoodsDto> ListSeckillGoods();
    }

    public class SeckillGoodsService : ISeckillGoodsService
    {
        readonly ISeckillGoodsRepository _repository;

        public SeckillGoodsService(ISeckillGoodsRepository repository)
        {
            _repository = repository;
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
                Img = entity.Img
            }).ToList();
        }
    }
}
