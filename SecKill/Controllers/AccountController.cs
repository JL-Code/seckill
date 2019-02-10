using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SecKill.Infrastructure;
using SecKill.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecKill.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        readonly DefaultContext _dbContext;

        public AccountController(DefaultContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public IActionResult Login(AccountViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var users = _dbContext.Set<Domain.AggregatesModel.User>();
            var user = users.Where(m => m.UserName == model.UserName && m.Password == model.Password).FirstOrDefault();

            return Ok(user);
        }
    }
}