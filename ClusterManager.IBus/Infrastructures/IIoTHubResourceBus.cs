using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using ClusterManager.Model;
using ClusterManager.Model.ResponseModel;
using ClusterManager.Model.ViewModels;
using Microsoft.Azure.Devices;
using Microsoft.Azure.Devices.Shared;

namespace ClusterManager.Core.Infrastructures
{
     public interface IIoTHubResourceBus
    {
         Task<string> GetBySubId(string SubId);
        Task<string> CreateOrUpdate( IoTHubModel ioTHubModel,string resourceGroupName);
        Task<string> DeleteIoTHub(string resourceGroupName, string resourceName);
        Task<IoTHubInfoModel> GetIoTHubInfo(string resourceGroupName, string resourceName);
        Task<IoTHubKeys> GetIoTHubKeys(string resourceGroupName, string resourceName);
        Task<string> CreateDevice(AccessPolicyModel createDeviceModel,string deviceId,bool isIotEdge);
        Task<string> GetIotEdgeDevices(AccessPolicyModel accessPolicyModel);
        Task<string> GetIotDevices(AccessPolicyModel accessPolicyModel);
        IQuery ListDevices(int maxCount, AccessPolicyModel createDeviceModel);
        Task<ConcurrentBag<Device>> GetDevicesAsync( AccessPolicyModel accessPolicyModel);
        Task<string> DeleteDevice(string deviceId, AccessPolicyModel accessPolicyModel);
        string GetDeviceKey(string deviceId, AccessPolicyModel accessPolicyModel);
        Task<Twin> GetDeivceTwin(string deviceId, AccessPolicyModel accessPolicyModel);
        //Task<Twin> UpdateDeviceTwin(string deviceId, string jsonTwinPatch, string etag, AccessPolicyModel accessPolicyModel);
        Task<string> UpdateDeviceTwin(string resourceGroupName, string resourceName, string deviceId, Twin twin);
        Task<object> GetIoTEdgeDeviceDeployment(string resourceGroupName, string resourceName);
    }
}
