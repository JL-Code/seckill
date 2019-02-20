using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SecKill.Infrastructure;
using SecKill.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
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
            var user = users.Where(m => m.UserName == model.Account && m.Password == model.Password).FirstOrDefault();

            // 生成jwt格式的令牌

            if (user == null)
            {
                return NotFound(new
                {
                    code = 11000,
                    message = "账号或密码错误"
                });
            }

            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var authTime = DateTime.UtcNow;
            var expiresAt = authTime.AddMinutes(10);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                // 身份卡
                Subject = new ClaimsIdentity(new Claim[] {
                    new Claim ("aud","http://localhost:8080"), // aud
                    new Claim ("iss","http://localhost:8080"), // iss
                    new Claim ("name",user.UserName), // name
                    new Claim ("id",user.UserId.ToString())
                }),
                //// 令牌颁发者
                //Issuer = "http://localhost:8080",
                //// 令牌受众
                //Audience = "http://localhost:8080",
                // 过期时间
                Expires = expiresAt,
                // 签名证书
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(JwtOptions.Constants.SECRET_KEY)), SecurityAlgorithms.HmacSha256Signature)
            };
            var securityToken = jwtTokenHandler.CreateToken(tokenDescriptor);
            return Ok(new
            {
                token_type = "Bearer",
                access_token = jwtTokenHandler.WriteToken(securityToken),
                profile = new
                {
                    sid = user.UserId,
                    name = user.UserName,
                    auth_time = new DateTimeOffset(authTime).ToUnixTimeSeconds(),
                    expires_at = new DateTimeOffset(expiresAt).ToUnixTimeSeconds()
                }
            });
        }

    }
}