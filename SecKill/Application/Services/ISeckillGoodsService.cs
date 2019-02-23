using SecKill.Application.Models;
using SecKill.Domain.AggregatesModel;
using System;
using System.Collections.Generic;

namespace SecKill.Application.Services
{
    public interface ISeckillGoodsService
    {
        SeckillGoods GetById(Guid id);

        List<SeckillGoodsDto> ListSeckillGoods();

        /// <summary>
        /// 扣减库存
        /// </summary>
        /// <param name="goodsId">商品ID</param>
        /// <param name="quantity">商品数量</param>
        /// <returns></returns>
        bool DeductInventory(Guid goodsId, int quantity);

        /// <summary>
        /// 是否能扣减库存
        /// </summary>
        /// <param name="goodsId"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        bool CanDeductInventory(Guid goodsId, int quantity);
    }
}
