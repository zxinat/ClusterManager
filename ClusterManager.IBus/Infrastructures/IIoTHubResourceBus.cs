using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ClusterManager.Model;
using ClusterManager.Model.ViewModels;

namespace ClusterManager.Core.Infrastructures
{
     public interface IIoTHubResourceBus
    {
         Task<string> GetBySubId(string SubId);
        Task<string> CreateOrUpdate( IoTHubModel ioTHubModel,string resourceGroupName);
    }
}
