using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ClusterManager.Model;
using ClusterManager.Model.ResponseModel;
using ClusterManager.Model.ViewModels;
using Newtonsoft.Json;

namespace ClusterManager.Dto.Infrastructures
{
    public interface IIoTHubResourceDto
    {
        Task<Model.ResponseModel.IoTHubResourceModel> ListBySubId(string SubId, string access_token);
        Task<string> CreateOrUpdate(string subid, IoTHubModel ioTHubModel,string resourceGroupName ,string access_token);
    }
}
