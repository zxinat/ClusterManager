using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ClusterManager.Model.ResponseModel;

namespace ClusterManager.Dto.Infrastructures
{
    public interface IResourceGroupDto
    {
        Task<ResourceGroupModel> GetAllResource(string subid,string access_token);
        Task<string> CreateOrUpdate(string subid, string resourceGroupName, string location,string access_token);
        Task<string> ListResource(string subid, string resourceGroupName, string access_token);
    }
}
