using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClusterManager.Core.Infrastructures;
using ClusterManager.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClusterManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AKSController : ControllerBase
    {
        private readonly IAKSBus _aKSBus;
        public AKSController(IAKSBus aKSBus)
        {
            this._aKSBus = aKSBus;
        }
        [HttpGet("{email}/{subid}/ListAllAKS")]
        public async Task<object> ListAllAKS(string email,string subid)
        {
            return await this._aKSBus.ListAllAKS(email,subid);
        }
        [HttpGet("{email}/{subid}/{resourceGroup}/GetAKSInfo/{AKSName}")]
        public async Task<object> GetAKSInfo(string email,string subid,string resourceGroup, string AKSName)
        {
            return await this._aKSBus.GetAKSInfo(email,subid,resourceGroup, AKSName);
        }
        [HttpPost("{email}/{subid}/{resourceGoupName}/CreateAKS/{AKSName}")]
        public async Task<object> CreateAKS(string email ,string subid,string resourceGroupName, [FromBody] CreateAKSModel createAKSModel)
        {
            return await this._aKSBus.CreateAKS(email,subid,resourceGroupName, createAKSModel);
        }
    }
}