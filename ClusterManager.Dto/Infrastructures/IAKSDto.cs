using ClusterManager.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClusterManager.Dto.Infrastructures
{
    public interface IAKSDto
    {
        Task<object> ListAllAKS(string subid, string access_token);
        Task<object> GetAKSInfo(string subid, string resourceGroup, string AKSName, string access_token);
        Task<object> CreateAKS(string subid, string resourceGroupName, CreateAKSModel createAKSModel,
            string clientId, string clientSecret, string access_token);
    }
}
