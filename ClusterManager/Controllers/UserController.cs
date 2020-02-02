using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClusterManager.Core.Infrastructures;
using ClusterManager.Model;
using ClusterManager.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;

namespace ClusterManager.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly JWTHelper _jWTHelper;
        private readonly IAuthBus _authBus;
        private readonly IAccountBus _accountBus;
        public UserController(JWTHelper jWTHelper,IAuthBus authBus,IAccountBus accountBus)
        {
            _accountBus = accountBus;
            _authBus = authBus;
            _jWTHelper = jWTHelper;
        }
        [HttpPost("Login")]
        public object Login([FromBody] AccountModel accountModel)
        {
            return _accountBus.Login(accountModel.email, accountModel.password);
        }


        [HttpGet("GetToken")]
        public string GetToken(string email, string pwd)
        {
            //JWTHelper jWTHelper = new JWTHelper();
            var payload = new Dictionary<string, object>
            {
                { "iss","owner" },
                { "exp",DateTimeOffset.UtcNow.AddSeconds(30).ToUnixTimeSeconds()},
                { "sub","azureAPI"},
                { "aud","USER"},
                { "iat",DateTime.Now.ToString()},
                { "data",new { userEmail=email,passWord=pwd} }
            };
            string token = _jWTHelper.CreateJwt(payload);
            return token;
        }
        [HttpPost("ValidateToken")]
        public object ValidateToken(string token)
        {
            string payload;
            string message;
            bool flag = _jWTHelper.ValidateJwt(token, out payload, out message);
            if (flag)
            {
                return new JObject
                {
                    {"payload",payload },
                    { "message",message}
                };
            }
            else
            {
                return message;
            }
        }
    }
}