using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ClusterManager.Dao.Infrastructures;
using ClusterManager.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace ClusterManager.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        public readonly IConfiguration _configuration;
        private readonly IAccountDao _accountDao;
        public LoginController(IConfiguration configuration,IAccountDao accountDao)
        {
            _configuration = configuration;
            _accountDao = accountDao;
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult RequestToken([FromBody] UserInfoModel userInfoModel)
        {
            if (userInfoModel.email=="694575171@qq.com" && userInfoModel.password=="zx000000")
            {
                var claims = new[]
                {
                    new Claim(ClaimTypes.Name,userInfoModel.email)
                };
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:SecurityKey"]));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                    issuer:"http://localhost:44350",
                    audience:"http://localhost:44350",
                    claims:claims,
                    expires:DateTime.Now.AddSeconds(60),
                    signingCredentials:creds);
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiresSec = 60
                });
                    
            }
            return BadRequest("Could not verify email and password");
        }
    }
}