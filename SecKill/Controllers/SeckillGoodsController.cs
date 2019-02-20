using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SecKill.Application.Models;
using SecKill.Application.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SecKill.Controllers
{
    /// <summary>
    /// 秒杀商品
    /// </summary>
    [Route("api/[controller]")]
    public class SeckillGoodsController : Controller
    {
        private readonly ISeckillGoodsService _seckillGoodsService;

        public SeckillGoodsController(ISeckillGoodsService seckillGoodsService)
        {
            _seckillGoodsService = seckillGoodsService;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<SeckillGoodsDto> Get()
        {
            var data = _seckillGoodsService.ListSeckillGoods();
            return data;
        }

        [Authorize]
        [HttpPost]
        public IActionResult Post()
        {
            return Ok();
        }

    }
}
