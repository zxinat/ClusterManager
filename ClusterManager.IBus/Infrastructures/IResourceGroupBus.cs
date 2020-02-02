using System;
using System.Collections.Generic;
using System.Text;
using ClusterManager.Model.ResponseModel;
using ClusterManager.Dto;
using ClusterManager.Dto.Infrastructures;
using System.Threading.Tasks;

namespace ClusterManager.Core.Infrastructures
{
    public interface IResourceGroupBus
    {
        Task<ResourceGroupModel> GetAllResourceGroup();
        Task<string> CreateOrUpdate(string resourceName,string location);
        Task<string> ListResource(string resourceGroupName);
    }
}
