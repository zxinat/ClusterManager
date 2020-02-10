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
    //[Produces("application/json")]
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
        public object Login([FromBody] UserInfoModel userInfoModel)
        {
            return _accountBus.Login(userInfoModel.email, userInfoModel.password);
        }
        [HttpPost("Register")]
        public object Register([FromBody] AccountModel accountModel)
        {
            return _accountBus.CreateUser(accountModel.email, accountModel.password);
        }
        /*[HttpGet("GetUserInfo/{username}")]
        public AccountModel GetUserInfo(string username)
        {
            return _accountBus.GetUserInfo(username);
        }*/
        [HttpPost("{email}/AddServicePrinciple")]
        public string AddServicePrinciple(string email, [FromBody] ServicePrinciple  servicePrinciple)
        {
            return _accountBus.AddServicePrinciple(email, servicePrinciple);
        }
        [HttpGet("{email}/ListServicePrinciples")]
        public List<ServicePrinciple> ListServicePrinciples(string email)
        {
            return _accountBus.ListServicePrinciples(email);
        }
        [HttpDelete("{email}/DeleteServicePrinciple/{tenantId}/{clientId}")]
        public string DeleteServicePrinciple(string email, string tenantId,string clientId)
        {
            return _accountBus.DeleteServicePrinciple(email, tenantId, clientId);
        }
        [HttpPost("{email}/UpdateClientSerect")]
        public string UpdateClientSeret(string email, [FromBody] ServicePrinciple servicePrinciple)
        {
            return this._accountBus.UpdateClientSecret(email, servicePrinciple);
        }
        [HttpGet("{email}/GetClientSecret/{tenantId}/{clientId}")]
        public string GetClientSecret(string email, string tenantId,string clientId)
        {
            return this._accountBus.GetClientSecret(email, tenantId, clientId);
        }
        [HttpPost("{email}/GetCurrentService")]
        public ServicePrinciple GetCurrentService(string email)
        {
            return this._accountBus.GetCurrentService(email);
        }
        [HttpGet("{email}/SetServicePrinciple/{tenantId}/{clientId}")]
        public string SetServicePrinciple(string email, string tenantId,string clientId)
        {
            return this._accountBus.SetServicePrinciple(email, tenantId, clientId);
        }
        /*[HttpGet("AddTenantId/{username}/{TenantId}")]
        public string AddTenantId(string username,string TenantId)
        {
            return _accountBus.AddTenantId(username, TenantId);
        }
        [HttpGet("ListTenantId/{username}")]
        public List<string> ListTenantId(string username)
        {
            return this._accountBus.ListTenantIdByEmail(username);
        }
        [HttpPost("AddClient/{username}/{TenantId}")]
        public string AddClient(string username,string TenantId,[FromBody] Client client)
        {
            return this._accountBus.AddClient(username, TenantId, client);
        }
        [HttpGet("ListClient/{username}/{tenantId}")]
        public List<Client> ListClient(string username,string tenantId)
        {
            return this._accountBus.ListClientByTenantId(username, tenantId);
        }*/


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