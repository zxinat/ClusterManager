using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ClusterManager.Core;
using System.Net;
using ClusterManager.Core.Infrastructures;
using ClusterManager.Model;
using ClusterManager.DI;
using ClusterManager.Dto;
using ClusterManager.Model.ResponseModel;
using ClusterManager.Model.ViewModels;
using Microsoft.Azure.Devices;
using Newtonsoft.Json;
using Microsoft.Azure.Devices.Shared;
using Microsoft.AspNetCore.Authorization;

namespace ClusterManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IoTHubResourceController : ControllerBase
    {
        private readonly IIoTHubResourceBus _ioTHubResourceBus;
        public IoTHubResourceController(IIoTHubResourceBus ioTHubResourceBus)
        {
            this._ioTHubResourceBus = ioTHubResourceBus;
        }
        [HttpGet("{email}/{subid}/ListBySubId")]
        //[Authorize]
        public Task<string> ListBySubId(string email,string subid)
        {
            //subid = "6273fbea-8a11-498b-8218-02b6f4398e12";
            //Token = "eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6InpqZ3V5bi16NzY0MENONHpPY2hTOVhXbXZmUSIsImtpZCI6InpqZ3V5bi16NzY0MENONHpPY2hTOVhXbXZmUSJ9.eyJhdWQiOiJodHRwczovL21hbmFnZW1lbnQuY2hpbmFjbG91ZGFwaS5jbiIsImlzcyI6Imh0dHBzOi8vc3RzLmNoaW5hY2xvdWRhcGkuY24vYzc5MTc3MzUtNWQ2MS00ODMyLThiNTQtYjExZDVmMWU3ODEwLyIsImlhdCI6MTU3ODI4OTcyMywibmJmIjoxNTc4Mjg5NzIzLCJleHAiOjE1NzgyOTM2MjMsImFpbyI6IlkyVmdZSkJVaUUzV2Y1VCtjTXB5ZndQNTJ3K3VBUUE9IiwiYXBwaWQiOiI1N2QxZWEyZi03YmE0LTRkMDMtOTM2YS0wMzYzNjhmZjk1N2MiLCJhcHBpZGFjciI6IjEiLCJpZHAiOiJodHRwczovL3N0cy5jaGluYWNsb3VkYXBpLmNuL2M3OTE3NzM1LTVkNjEtNDgzMi04YjU0LWIxMWQ1ZjFlNzgxMC8iLCJvaWQiOiI0NTUyYmZkMS1hNDU1LTQxYjgtYTY1NS1hNzQ3NzE4NWY0MDIiLCJzdWIiOiI0NTUyYmZkMS1hNDU1LTQxYjgtYTY1NS1hNzQ3NzE4NWY0MDIiLCJ0aWQiOiJjNzkxNzczNS01ZDYxLTQ4MzItOGI1NC1iMTFkNWYxZTc4MTAiLCJ1dGkiOiJLRHQ0NWNNRVMwTzlvcUxiS0lrVUFBIiwidmVyIjoiMS4wIn0.NwCJHFmYXj9jd5alPGHCU2Wnfa8Aj2WyNz7bDIZXbpH2MsrsGu9IRr4TzF4cCGf40S8jSqQoizqLPmqt7pjtltI_Ig2jTPdqb_g-2tFRzPQYpwYpLlpqqrUb1BfQdikA0K-RkFXvoyiRIm71HC_uNW7yDC2gmKxUviaCbLHuV0JSjxYnXwpLZ6Gs6-cbQY1R0LOGEdgiQKdxeXmvLgtfdoVwmuxf6zH090iIbx_hYmCZiwecVWN3vX6_gv_D7pm8wvNvHSwbrkg_C5w1XoFJWpg07jZLy6qsp9xIr2X3P9iZPwukHY_SxoJU3YYLHWy65PLZEObLzMW8PIl9RC9Kug";
            //IoTHubResourceBus ioTHubResourceBus = new IoTHubResourceBus();
            return this._ioTHubResourceBus.GetBySubId(email,subid);
        }
        [HttpPost("{email}/{subid}/CreateOrUpdate/{resourceGroupName}/{resourceName}")]
        public async Task<string> CreateOrUpdate([FromBody] IoTHubModel ioTHubModel, string email,string subid,string resourceGroupName)
        {
            return await this._ioTHubResourceBus.CreateOrUpdate(ioTHubModel, email,subid,resourceGroupName);

        }
        [HttpPost("{email}/{subid}/Delete/{resourceGroupName}/{resourceName}")]
        public async Task<string> Delete(string email, string subid,string resourceGroupName, string resourceName)
        {
            return await this._ioTHubResourceBus.DeleteIoTHub(email,subid,resourceGroupName, resourceName);
        }
        [HttpGet("{email}/{subid}/GetIoTHubInfo/{resourceGroupName}/{resourceName}")]
        public async Task<IoTHubInfoModel> GetIoTHubInfo(string email, string subid,string resourceGroupName, string resourceName)
        {
            return await this._ioTHubResourceBus.GetIoTHubInfo(email, subid,resourceGroupName, resourceName);
        }
        [HttpPost("{email}/{subid}/GetIoTHubKeys/{resourceGroupName}/{resourceName}")]
        public async Task<IoTHubKeys> GetIoTHubKeys(string email, string subid,string resourceGroupName, string resourceName)
        {
            return await this._ioTHubResourceBus.GetIoTHubKeys(email, subid,resourceGroupName, resourceName);
        }


        [HttpPost("Device/CreateIotDevice/{deviceId}")]
        public async Task<string> CreateIotDevice([FromBody] AccessPolicyModel accessPolicyModel, string deviceId)
        {
            return await this._ioTHubResourceBus.CreateDevice(accessPolicyModel, deviceId, false);
        }
        [HttpPost("{email}/Device/GetIotDevices")]
        public async Task<object> GetIotDevices(string email, [FromBody] AccessPolicyModel accessPolicyModel)
        {
            return await this._ioTHubResourceBus.GetIotDevices(accessPolicyModel,email);
        }
        [HttpPost("Device/CreateIotEdgeDevice/{deviceId}")]
        public async Task<string> CreateIotEdgeDevice([FromBody] AccessPolicyModel accessPolicyModel, string deviceId)
        {
            return await this._ioTHubResourceBus.CreateDevice(accessPolicyModel, deviceId, true);
        }
        [HttpPost("{email}/Device/GetIotEdgeDevices")]
        public async Task<object> GetIotEdgeDevices(string email, [FromBody] AccessPolicyModel accessPolicyModel)
        {
            return await this._ioTHubResourceBus.GetIotEdgeDevices(accessPolicyModel, email);
        }
        [HttpGet("{email}/{subid}/{resourceGroupName}/{resourceName}/Device/{deviceId}/GetDeviceInfo")]
        public async Task<object> GetDeviceInfo(string email, string subid ,string resourceGroupName,string resourceName,string deviceId)
        {
            return await this._ioTHubResourceBus.GetDeviceInfo(email,subid, resourceGroupName, resourceName, deviceId);
        }
        [HttpPost("{email}/{subid}/{resourceGroupName}/{resourceName}/Device/{deviceId}/UpdateDeviceInfo")]
        public async Task<object> UpdateDeviceInfo(string email, string subid,string resourceGroupName,string resourceName,string deviceId,[FromBody] UpdateDeviceViewModel updateDeviceViewModel)
        {
            return await this._ioTHubResourceBus.UpdateDeviceInfo(email,subid ,resourceGroupName, resourceName,deviceId, updateDeviceViewModel);
        }
        
        /*[HttpPost("Device/ListDevices/{maxCount}")]
        public IQuery ListDevices([FromBody] AccessPolicyModel accessPolicyModel, int maxCount)
        {
            return this._ioTHubResourceBus.ListDevices(maxCount, accessPolicyModel);
        }
        [HttpPost("Device/GetDevices")]
        public async Task<ConcurrentBag<Device>> GetDevices([FromBody] AccessPolicyModel accessPolicyModel)
        {
            return await this._ioTHubResourceBus.GetDevicesAsync(accessPolicyModel);
        }*/
        [HttpPost("Device/DeleteDevice/{deviceId}")]
        public async Task<string> DeleteDevice(string deviceId, [FromBody] AccessPolicyModel accessPolicyModel)
        {
            return await this._ioTHubResourceBus.DeleteDevice(deviceId, accessPolicyModel);
        }
        [HttpPost("Device/GetDeviceKey/{deviceId}")]
        public string GetDeviceKey(string deviceId, [FromBody] AccessPolicyModel accessPolicyModel)
        {
            return this._ioTHubResourceBus.GetDeviceKey(deviceId, accessPolicyModel);
        }
        [HttpPost("{email}/Device/GetDeviceTwin/{deviceId}")]
        public Task<Twin> GetDeviceTwin(string email, string deviceId, [FromBody] AccessPolicyModel accessPolicyModel)
        {

            return this._ioTHubResourceBus.GetDeivceTwin(email, deviceId, accessPolicyModel);
        }
        [HttpPost("{email}/{subid}/{resourceGroupName}/{resourceName}/Device/UpdateDeviceTwin/{deviceId}")]
        public Task<string> UpdateDeviceTwin(string email, string subid,string resourceGroupName,string resourceName,string deviceId,[FromBody] Twin twin)
        {
            return this._ioTHubResourceBus.UpdateDeviceTwin(email,subid, resourceGroupName,resourceName,deviceId, twin);
        }
        [HttpPost("{email}/{subid}/{resourceGroupName}/{resourceName}/Device/GetIoTEdgeDeviceDeployment")]
        public Task<object> GetIoTEdgeDeviceDeployment(string email,string subid, string resourceGroupName, string resourceName)
        {
            return this._ioTHubResourceBus.GetIoTEdgeDeviceDeployment(email, subid,resourceGroupName, resourceName);
        }
        [HttpPost("{email}/{subid}/{resourceGroupName}/{resourceName}/Device/{deviceId}/GetDeviceModules")]
        public Task<object> GetDeviceModules(string email,string subid, string resourceGroupName,string resourceName,string deviceId)
        {
            return this._ioTHubResourceBus.GetDeviceModules(email,subid, resourceGroupName, resourceName, deviceId);
        }
        [HttpPost("{email}/{subid}/{resourceGroupName}/{resourceName}/GetInsights")]
        public async Task<InsightResponseModel> GetIoTHubInsight(string email,string subid,string resourceGroupName,string resourceName,[FromBody] InsightModel insightModel)
        {
            return await this._ioTHubResourceBus.GetIoTHubInsight(email,subid, resourceGroupName, resourceName, insightModel);
        }
    }
}