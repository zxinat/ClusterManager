using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ClusterManager.Core;
using ClusterManager.Core.Infrastructures;
using ClusterManager.Model.ResponseModel;

namespace ClusterManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResourceGroupController : ControllerBase
    {
        readonly IResourceGroupBus _resourceGroupBus;
        public ResourceGroupController(IResourceGroupBus resourceGroupBus)
        {
            this._resourceGroupBus = resourceGroupBus;
        }
        [HttpGet]
        public async Task<ResourceGroupModel> GetAllResourceGroup()
        {
            return await this._resourceGroupBus.GetAllResourceGroup();
        }
        [HttpPut("CreateOrUpdate/{resourceGroupName}/{location}")]
        public async Task<string> CreateOrUpdate(string resourceGroupName,string location)
        {
            return await this._resourceGroupBus.CreateOrUpdate(resourceGroupName,location);
        }
        [HttpGet("{resourceGroupName}/ListAllResource")]
        public async Task<string> ListAllResource(string resourceGroupName)
        {
            return await this._resourceGroupBus.ListResource(resourceGroupName);
        }
    }
}