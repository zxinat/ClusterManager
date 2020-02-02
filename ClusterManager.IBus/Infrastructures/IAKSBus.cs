using ClusterManager.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClusterManager.Core.Infrastructures
{
    public interface IAKSBus
    {
        Task<object> ListAllAKS();
        Task<object> GetAKSInfo(string resourceGroup, string AKSName);
        Task<object> CreateAKS(string resourceGroupName, CreateAKSModel createAKSModel);
    }
}
