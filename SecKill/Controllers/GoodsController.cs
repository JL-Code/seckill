using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SecKill.Controllers
{
    [Route("api/[controller]")]
    public class GoodsController : Controller
    {

        public IActionResult Post()
        {
            return Ok();
        }
    }
}
