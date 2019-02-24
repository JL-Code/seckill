using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NLog;
using SecKill.Application.Services;
using SecKill.Domain.AggregatesModel;
using SecKill.Domain.SeedWork;
using SecKill.Infrastructure;
using SecKill.Infrastructure.Utils;
using SecKill.Models;
using System;
using System.Threading.Tasks;

namespace SecKill.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly static ILogger logger = LogManager.GetCurrentClassLogger();
        private readonly RedisManager _redisManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOrderService _orderService;
        private readonly ISeckillGoodsService _seckillGoodsService;

        public OrderController(IUnitOfWork unitOfWork, IOrderService orderService, ISeckillGoodsService seckillGoodsService, RedisManager redisManager)
        {
            _unitOfWork = unitOfWork;
            _orderService = orderService;
            _seckillGoodsService = seckillGoodsService;
            _redisManager = redisManager;
        }

        /// <summary>
        /// 创建订单
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost()]
        public IActionResult Post(OrderViewModel model)
        {

            var userInfo = User.Identity.ToUserInfo();

            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                var timestamp = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeMilliseconds().ToString();
                var idstr = userInfo.UserId.ToString().Replace("-", "").ToLower();
                var date = DateTime.UtcNow.ToString("yyyyMMdd");
                var orderNumber = date + timestamp.Substring(8) + idstr.Substring(27);
                var order = new SeckillOrder()
                {
                    OrderId = model.OrderId.GetValueOrDefault(),
                    OrderNumber = orderNumber,
                    GoodsId = model.GoodsId.GetValueOrDefault(),
                    GoodsName = model.GoodsName,
                    GoodsPrice = model.GoodsPrice,
                    OrderDate = DateTime.Now,
                    Address = model.Address,
                    OrderState = OrderState.UnPaid,
                    Quantity = model.Quantity,
                    UserId = userInfo.UserId,
                };
                var existingOrder = _orderService.GetSeckillOrderBy(userInfo.UserId, order.GoodsId);
                if (existingOrder != null)
                {
                    // refs:https://www.restapitutorial.com/httpstatuscodes.html
                    return StatusCode(200, CodeMessage.CONNNOT_REPEAT_SECKILL_GOODS);
                }
                _orderService.TryCreateOrder(order, out CodeMessage message);
                if (message.HasError)
                {
                    return Ok(message);
                }
                _unitOfWork.Commit();
                return Ok(new
                {
                    orderNumber = order.OrderNumber,
                    goodsPrice = order.GoodsPrice
                });
            }
            catch (Exception ex)
            {
                logger.Error(ex, $"订单创建失败：{ex.Message}");
                _unitOfWork.Rollback();
                return StatusCode(500, new
                {
                    code = 500,
                    message = ex.Message
                });
            }
        }

        /// <summary>
        /// 创建订单草稿
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost("draft")]
        public async Task<IActionResult> CreateDraft(OrderDraftViewModel orderDraft)
        {
            try
            {
                var userInfo = User.Identity.ToUserInfo();
                // 1. 判断是否重复秒杀 2.判断商品是否还有库存
                var existingOrder = await _orderService.GetSeckillOrderByAsync(userInfo.UserId, orderDraft.GoodsId.GetValueOrDefault());

                if (existingOrder != null)
                {
                    return StatusCode(200, CodeMessage.CONNNOT_REPEAT_SECKILL_GOODS);
                }

                if (!await _seckillGoodsService.CanDeductInventoryAsync(orderDraft.GoodsId.GetValueOrDefault(), 1))
                {
                    return StatusCode(200, CodeMessage.GOODS_SOLD_OUT);
                }

                orderDraft.OrderId = Guid.NewGuid();
                var key = "uid_" + userInfo.UserId.ToString() + "_gid_" + orderDraft.GoodsId.ToString();
                await _redisManager.RedisDb.StringSetAsync(key, JsonUtil.Serialize(orderDraft));
                return Ok(orderDraft);
            }
            catch (Exception ex)
            {
                logger.Error(ex, $"订单草稿创建失败：{ex.Message}");
                return StatusCode(500, new
                {
                    code = 500,
                    message = ex.Message
                });
            }
        }
    }
}