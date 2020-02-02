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
        [HttpGet("ListAllAKS")]
        public async Task<object> ListAllAKS()
        {
            return await this._aKSBus.ListAllAKS();
        }
        [HttpGet("GetAKSInfo/{resourceGroup}/{AKSName}")]
        public async Task<object> GetAKSInfo(string resourceGroup, string AKSName)
        {
            return await this._aKSBus.GetAKSInfo(resourceGroup, AKSName);
        }
        [HttpPost("CreateAKS/{resourceGoupName}/{AKSName}")]
        public async Task<object> CreateAKS(string resourceGroupName, [FromBody] CreateAKSModel createAKSModel)
        {
            return await this._aKSBus.CreateAKS(resourceGroupName, createAKSModel);
        }
    }
}