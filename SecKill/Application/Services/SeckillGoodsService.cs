using NLog;
using SecKill.Application.Models;
using SecKill.Domain.AggregatesModel;
using SecKill.Infrastructure;
using SecKill.Infrastructure.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecKill.Application.Services
{
    public class SeckillGoodsService : ISeckillGoodsService
    {
        private readonly static ILogger logger = LogManager.GetCurrentClassLogger();
        private readonly RedisManager _redisManager;
        private readonly ISeckillGoodsRepository _repository;

        const string SeckillGoods_Key = "seckillgoods_key";

        public SeckillGoodsService(ISeckillGoodsRepository repository, RedisManager redisManager)
        {
            _repository = repository;
            _redisManager = redisManager;
        }

        public bool CanDeductInventory(Guid goodsId, int quantity)
        {
            var goods = GetByGoodsId(goodsId);
            return CanDeductInventory(goods, quantity);
        }

        public async Task<bool> CanDeductInventoryAsync(Guid goodsId, int quantity)
        {
            var goods = await GetByGoodsIdAsync(goodsId);
            if (goods == null)
                return false;
            if (goods.StockCount - quantity < 0)
                return false;
            return true;
        }


        public bool CanDeductInventory(SeckillGoods goods, int quantity)
        {
            if (goods == null)
                return false;
            if (goods.StockCount - quantity < 0)
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
            var goods = GetByGoodsId(goodsId);
            if (CanDeductInventory(goodsId, quantity))
            {
                goods.StockCount -= quantity;
                _repository.Update(goods);
                return true;
            }
            return false;
        }

        public SeckillGoods GetByGoodsId(Guid goodsId)
        {
            //0.先从缓存获取信息 存在直接返回 不存在则 查询数据库并更新缓存
            var value = _redisManager.RedisDb.StringGet(goodsId.ToString());
            if (!value.IsNullOrEmpty)
                return JsonUtil.Deserialize<SeckillGoods>(value);
            logger.Warn("缓存失效：" + "key：" + goodsId + " time：" + DateTime.Now.ToString());
            var seckillGoods = _repository.Get(m => m.GoodsId == goodsId);
            if (seckillGoods != null)
            {
                _redisManager.RedisDb.StringSet(goodsId.ToString(), JsonUtil.Serialize(seckillGoods));
            }
            return seckillGoods;
        }

        public async Task<SeckillGoods> GetByGoodsIdAsync(Guid goodsId)
        {
            //0.先从缓存获取信息 存在直接返回 不存在则 查询数据库并更新缓存
            var value = await _redisManager.RedisDb.StringGetAsync(goodsId.ToString());
            if (!value.IsNullOrEmpty)
                return JsonUtil.Deserialize<SeckillGoods>(value);
            logger.Warn("缓存失效：" + "key：" + goodsId + " time：" + DateTime.Now.ToString());
            var seckillGoods = await _repository.GetAsync(m => m.GoodsId == goodsId);
            if (seckillGoods != null)
            {
                await _redisManager.RedisDb.StringSetAsync(goodsId.ToString(), JsonUtil.Serialize(seckillGoods));
            }
            return seckillGoods;
        }

        public List<SeckillGoodsDto> ListSeckillGoods()
        {

            var entities = _repository.ListEntities().ToList();

            return entities.Select(entity => new SeckillGoodsDto
            {
                GoodsId = entity.GoodsId,
                GoodsName = entity.GoodsName,
                StockCount = entity.StockCount,
                EndDate = entity.EndDate,
                SeckillGoodsId = entity.SeckillGoodsId,
                StartDate = entity.StartDate,
                SeckillPrice = entity.SeckillPrice,
                PictureUrl = entity.PictureUrl
            }).ToList();
        }

        public async Task<List<SeckillGoodsDto>> ListSeckillGoodsAsync()
        {
           
            var value = await _redisManager.RedisDb.StringGetAsync(SeckillGoods_Key);
            if (!value.IsNullOrEmpty)
                return JsonUtil.Deserialize<List<SeckillGoodsDto>>(value);
            var entities = await _repository.ListEntitiesAsync().ToList();
            var dtos = entities.Select(entity => new SeckillGoodsDto
            {
                GoodsId = entity.GoodsId,
                GoodsName = entity.GoodsName,
                StockCount = entity.StockCount,
                EndDate = entity.EndDate,
                SeckillGoodsId = entity.SeckillGoodsId,
                StartDate = entity.StartDate,
                SeckillPrice = entity.SeckillPrice,
                PictureUrl = entity.PictureUrl
            }).ToList();
            await _redisManager.RedisDb.StringSetAsync(SeckillGoods_Key, JsonUtil.Serialize(dtos));
            return dtos;
        }

    }
}
