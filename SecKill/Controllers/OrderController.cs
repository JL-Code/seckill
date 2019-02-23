using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SecKill.Application.Models;
using SecKill.Application.Services;
using SecKill.Domain.AggregatesModel;
using SecKill.Domain.SeedWork;
using SecKill.Infrastructure;
using SecKill.Models;
using System;

namespace SecKill.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOrderService _orderService;
        private readonly ISeckillGoodsService _seckillGoodsService;

        public OrderController(IUnitOfWork unitOfWork, IOrderService orderService, ISeckillGoodsService seckillGoodsService)
        {
            _unitOfWork = unitOfWork;
            _orderService = orderService;
            _seckillGoodsService = seckillGoodsService;
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
                    return StatusCode(409, CodeMessage.CONNNOT_REPEAT_SECKILL_GOODS);
                }
                _orderService.TryCreateOrder(order);
                _unitOfWork.Commit();
                return Ok(new {
                    orderNumber = order.OrderNumber,
                    goodsPrice = order.GoodsPrice
                });
            }
            catch (Exception ex)
            {
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
        public IActionResult CreateDraft(OrderDraftViewModel orderDraft)
        {
            try
            {
                var userInfo = User.Identity.ToUserInfo();
                // 1. 判断是否重复秒杀 2.判断商品是否还有库存
                var existingOrder = _orderService.GetSeckillOrderBy(userInfo.UserId, orderDraft.GoodsId.GetValueOrDefault());
                if (existingOrder != null)
                {
                    return StatusCode(500, CodeMessage.CONNNOT_REPEAT_SECKILL_GOODS);
                }

                if (!_seckillGoodsService.CanDeductInventory(orderDraft.GoodsId.GetValueOrDefault(), 1))
                {
                    return StatusCode(500, CodeMessage.GOODS_SOLD_OUT);
                }
                orderDraft.OrderId = Guid.NewGuid();
                return Ok(orderDraft);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    code = 500,
                    message = ex.Message
                });
            }
        }
    }
}