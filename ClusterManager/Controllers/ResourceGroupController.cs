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
    }
}