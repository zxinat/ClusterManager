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
    }
}
