using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ClusterManager.Model;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;
using ClusterManager.Dao.Infrastructures;
using ClusterManager.Core.Infrastructures;
using Newtonsoft.Json.Linq;

namespace ClusterManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private IConfiguration _configuration;
        private AccountModel _account;
        private readonly IAccountBus _accountBus;
        public ValuesController(IOptions<AccountModel> account,IConfiguration configuration,IAccountBus accountBus)
        {
            _configuration = configuration;
            this._account = account.Value;
            _accountBus = accountBus;
        }
        // GET api/values
        [HttpGet]
        //[Authorize]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" ,this._account.clientId};
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            new JObject
            {
                { "$message",123}
            };
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        [HttpPost("register")]
        public object CreateUser([FromBody] AccountModel accountModel)
        {
            return _accountBus.CreateUser(accountModel.email,accountModel.password);
        }
        [HttpPost("login")]
        public object Login([FromBody] AccountModel accountModel)
        {
            return _accountBus.Login(accountModel.email, accountModel.password);
        }
    }
}
