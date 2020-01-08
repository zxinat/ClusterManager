using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ClusterManager.Core.Infrastructures;
using ClusterManager.Model.ResponseModel;
using ClusterManager.Dto;
using ClusterManager.Dto.Infrastructures;
using Microsoft.Extensions.Configuration;


namespace ClusterManager.Core
{
    public class ResourceGroupBus:IResourceGroupBus
    {
        private readonly IResourceGroupDto _resourceGroupDto;
        private readonly IConfiguration _configuration;
        private readonly ITokenDto _tokenDto;
        public ResourceGroupBus(IResourceGroupDto resourceGroupDto,
            IConfiguration configuration,
            ITokenDto tokenDto)
        {
            this._resourceGroupDto = resourceGroupDto;
            this._configuration = configuration;
            this._tokenDto = tokenDto;
        }
        public async Task<ResourceGroupModel> GetAllResourceGroup()
        {
            //string subid = this._configuration["accountsetting:subscriptionId"]; 
            string subid = "6273fbea-8a11-498b-8218-02b6f4398e12";
            string access_token = this._tokenDto.GetToken().Result.access_token;
            ResourceGroupModel resourceGroup = await this._resourceGroupDto.GetAllResource(subid ,access_token);
            return resourceGroup;
        }
    }
}
