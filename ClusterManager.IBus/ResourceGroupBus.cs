using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ClusterManager.Core.Infrastructures;
using ClusterManager.Model.ResponseModel;
using ClusterManager.Dto;
using ClusterManager.Dto.Infrastructures;
using Microsoft.Extensions.Configuration;
using ClusterManager.Model;
using ClusterManager.Dao.Infrastructures;

namespace ClusterManager.Core
{
    public class ResourceGroupBus:IResourceGroupBus
    {
        private readonly IResourceGroupDto _resourceGroupDto;
        private readonly IConfiguration _configuration;
        private readonly ITokenDto _tokenDto;
        private readonly string subid;
        private readonly ISubscriptionDto _subscriptionDto;
        private readonly ServicePrinciple servicePrinciple;
        public ResourceGroupBus(IResourceGroupDto resourceGroupDto,
            IConfiguration configuration,
            ITokenDto tokenDto,
            ISubscriptionDto subscriptionDto,
            IAccountDao accountDao)
        {

            this._resourceGroupDto = resourceGroupDto;
            this._configuration = configuration;
            this._tokenDto = tokenDto;
            this._subscriptionDto = subscriptionDto;
            this.subid = "6273fbea-8a11-498b-8218-02b6f4398e12";
        }
        public async Task<ResourceGroupModel> GetAllResourceGroup(string email,string subid)
        {
            //string subid = this._configuration["accountsetting:subscriptionId"]; 
            //string subid = "6273fbea-8a11-498b-8218-02b6f4398e12";
            string access_token = this._tokenDto.GetToken(email).Result.access_token;
            ResourceGroupModel resourceGroup = await this._resourceGroupDto.GetAllResource(subid ,access_token);
            return resourceGroup;
        }
        public async Task<string> CreateOrUpdate(string email,string resourceName,string location)
        {
            string access_token = this._tokenDto.GetToken(email).Result.access_token;
            return await this._resourceGroupDto.CreateOrUpdate(this.subid, resourceName,location,access_token);
        }
        public async Task<string> ListResource(string email,string resourceGroupName)
        {
            string access_token = this._tokenDto.GetToken(email).Result.access_token;
            return await this._resourceGroupDto.ListResource(this.subid, resourceGroupName, access_token);
        }
        public async Task<List<SubscriptionModel>> GetSubsciptions(string email)
        {
            string access_token = this._tokenDto.GetToken(email).Result.access_token;
            return await this._subscriptionDto.GetSubscriptions(access_token);
        }

    }
}
