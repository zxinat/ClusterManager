using System;
using System.Collections.Generic;
using System.Text;
using ClusterManager.Model.ResponseModel;
using ClusterManager.Dto;
using ClusterManager.Dto.Infrastructures;
using System.Threading.Tasks;
using ClusterManager.Model;

namespace ClusterManager.Core.Infrastructures
{
    public interface IResourceGroupBus
    {
        Task<ResourceGroupModel> GetAllResourceGroup(string email,string subid);
        Task<string> CreateOrUpdate(string email,string resourceName,string location);
        Task<string> ListResource(string email,string resourceGroupName);
        Task<List<SubscriptionModel>> GetSubsciptions(string email);
    }
}
