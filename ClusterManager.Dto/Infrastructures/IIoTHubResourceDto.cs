using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ClusterManager.Model;
using ClusterManager.Model.ResponseModel;
using ClusterManager.Model.ViewModels;
using Microsoft.Azure.Devices;
using Microsoft.Azure.Devices.Common;
using Microsoft.Azure.Devices.Shared;
using Newtonsoft.Json;

namespace ClusterManager.Dto.Infrastructures
{
    public interface IIoTHubResourceDto
    {
        Task<Model.ResponseModel.IoTHubResourceModel> ListBySubId(string SubId, string access_token);
        Task<string> CreateOrUpdate(string subid, IoTHubModel ioTHubModel,string resourceGroupName ,string access_token);
        Task<string> DeleteIotHub(string subid, string resourceGroupName, string resourceName, string access_token);
        Task<IoTHubInfoModel> GetIoTHubInfo(string subid, string resourceGroupName, string resourceName, string access_token);
        Task<IoTHubKeys> GetIoTHubKeys(string subid, string resourceGroupName, string resourceName, string access_token);
        Task<string> CreateDevice(AccessPolicyModel createDeviceModel,string deviceId,bool isIotEdge);
        Task<DeviceInfoModel> GetDeviceInfo(AccessPolicyModel accessPolicyModel, string deviceId,string access_token);
        Task<DeviceInfoModel> UpdateDeviceInfo(UpdateDeviceViewModel updateDeviceViewModel, AccessPolicyModel accessPolicyModel, string deviceId, string access_token);
        Task<object> GetIotEdgeDevices(AccessPolicyModel accessPolicyModel, string access_token);
        Task<object> GetIotDevices(AccessPolicyModel accessPolicyModel, string access_token);
        IQuery ListDevices(int maxCount, AccessPolicyModel createDeviceModel);
        Task<ConcurrentBag<Device>> GetDevicesAsync( AccessPolicyModel accessPolicyModel);
        Task<string> DeleteDevice(string deviceId, AccessPolicyModel accessPolicyModel);
        string GetDeviceKey(string deviceId, AccessPolicyModel accessPolicyModel);
        Task<Twin> GetDeviceTwin(string deviceId, AccessPolicyModel accessPolicyModel,string access_token);
        //Task<Twin> UpdateDeviceTwin(string deviceId, string jsonTwinPatch, string etag, AccessPolicyModel accessPolicyModel);
        Task<string> UpdateDeviceTwin(string deviceId, Twin twin, AccessPolicyModel accessPolicyModel, string access_token);
        Task<object> GetIoTEdgeDeviceDeployment(AccessPolicyModel accessPolicyModel, string access_token);
        Task<object> GetDeviceModules(string deviceId, AccessPolicyModel accessPolicyModel, string access_token);
        Task<InsightResponseModel> GetIoTHubInsight(string subid, string resourceGroupName, string resourceName, string access_token, InsightModel insightModel);

    }
}
