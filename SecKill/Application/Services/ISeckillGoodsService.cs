using SecKill.Application.Models;
using System;
using System.Collections.Generic;

namespace SecKill.Application.Services
{
    public interface ISeckillGoodsService
    {
        List<SeckillGoodsDto> ListSeckillGoods();

        /// <summary>
        /// 扣减库存
        /// </summary>
        /// <param name="goodsId">商品ID</param>
        /// <param name="quantity">商品数量</param>
        /// <returns></returns>
        bool DeductInventory(Guid goodsId, int quantity);
    }
}
