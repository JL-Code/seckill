using SecKill.Application.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecKill.Application.Services
{
    public interface IOrderService
    {
        /// <summary>
        /// 创建订单
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        OrderDto CreateOrder(OrderDto order);

    }
}
