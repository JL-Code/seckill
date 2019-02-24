using SecKill.Application.Models;
using SecKill.Domain.AggregatesModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SecKill.Application.Services
{
    public interface ISeckillGoodsService
    {
        SeckillGoods GetByGoodsId(Guid goodsId);

        Task<SeckillGoods> GetByGoodsIdAsync(Guid goodsId);

        List<SeckillGoodsDto> ListSeckillGoods();

        /// <summary>
        /// 扣减库存
        /// </summary>
        /// <param name="goodsId">商品ID</param>
        /// <param name="quantity">商品数量</param>
        /// <returns></returns>
        bool DeductInventory(Guid goodsId, int quantity);

        bool CanDeductInventory(SeckillGoods goods, int quantity);

        /// <summary>
        /// 是否能扣减库存
        /// </summary>
        /// <param name="goodsId"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        bool CanDeductInventory(Guid goodsId, int quantity);

        Task<bool> CanDeductInventoryAsync(Guid goodsId, int quantity);
    }
}
