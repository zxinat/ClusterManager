using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ClusterManager.Core;
using ClusterManager.Core.Infrastructures;
using ClusterManager.Model.ResponseModel;
using ClusterManager.Model;

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
        [HttpGet("{email}/{subid}/GetAllResourceGroup")]
        public async Task<ResourceGroupModel> GetAllResourceGroup(string email,string subid)
        {
            return await this._resourceGroupBus.GetAllResourceGroup(email,subid);
        }
        [HttpPut("{email}/CreateOrUpdate/{resourceGroupName}/{location}")]
        public async Task<string> CreateOrUpdate(string email,string resourceGroupName,string location)
        {
            return await this._resourceGroupBus.CreateOrUpdate(email, resourceGroupName,location);
        }
        [HttpGet("{email}/{resourceGroupName}/ListAllResource")]
        public async Task<string> ListAllResource(string email,string resourceGroupName)
        {
            return await this._resourceGroupBus.ListResource(email,resourceGroupName);
        }
        [HttpGet("{email}/GetSubscriptions")]
        public async Task<List<SubscriptionModel>> GetSubscriptions(string email)
        {
            return await this._resourceGroupBus.GetSubsciptions(email);
        }
    }
}