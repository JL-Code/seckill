using NLog;
using SecKill.Domain.AggregatesModel;
using SecKill.Infrastructure;
using SecKill.Infrastructure.Utils;
using System;
using System.Threading.Tasks;

namespace SecKill.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly static ILogger logger = LogManager.GetCurrentClassLogger();
        private readonly RedisManager _redisManager;
        private readonly ISeckillGoodsService _seckillGoodsService;
        private readonly ISecKillOrderRepository _repository;

        public OrderService(ISecKillOrderRepository repository, ISeckillGoodsService seckillGoodsService, RedisManager redisManager)
        {
            _repository = repository;
            _seckillGoodsService = seckillGoodsService;
            _redisManager = redisManager;
        }

        public SeckillOrder GetSeckillOrderBy(Guid userId, Guid goodsId)
        {
            var key = "uid_" + userId.ToString() + "_gid_" + goodsId.ToString();
            var value = _redisManager.RedisDb.StringGet(key);
            if (!value.IsNullOrEmpty)
                return JsonUtil.Deserialize<SeckillOrder>(value);
            logger.Warn("缓存失效：" + "key：" + key + " time：" + DateTime.Now.ToString());
            var order = _repository.Get(m => m.UserId == userId && m.GoodsId == goodsId);
            if (order != null)
            {
                _redisManager.RedisDb.StringSet(key, JsonUtil.Serialize(order));
            }
            return order;
        }

        public async Task<SeckillOrder> GetSeckillOrderByAsync(Guid userId, Guid goodsId)
        {
            var key = "uid_" + userId.ToString() + "_gid_" + goodsId.ToString();
            var value = await _redisManager.RedisDb.StringGetAsync(key);
            if (!value.IsNullOrEmpty)
                return JsonUtil.Deserialize<SeckillOrder>(value);
            logger.Warn("缓存失效：" + "key：" + key + " time：" + DateTime.Now.ToString());
            var order = await _repository.GetAsync(m => m.UserId == userId && m.GoodsId == goodsId);
            if (order != null)
            {
                await _redisManager.RedisDb.StringSetAsync(key, JsonUtil.Serialize(order));
            }
            return order;
        }

        public bool TryCreateOrder(SeckillOrder order, out CodeMessage codeMessage)
        {
            codeMessage = new CodeMessage(0, "");
            var success = _seckillGoodsService.DeductInventory(order.GoodsId, order.Quantity);
            if (!success)
            {
                codeMessage.Code = 4002;
                codeMessage.Message = "扣减库存失败";
                return false;
            }
            _repository.Add(order);
            return true;
        }
    }
}
