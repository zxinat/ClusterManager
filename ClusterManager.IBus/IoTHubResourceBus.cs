using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Concurrent;
using ClusterManager.Core.Infrastructures;
using ClusterManager.Model;
using ClusterManager.Dto;
using ClusterManager.Dto.Infrastructures;
using System.Threading.Tasks;
using ClusterManager.Model.ResponseModel;
using ClusterManager.Model.ViewModels;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.Azure.Devices;
using Microsoft.Azure.Devices.Common;
using Microsoft.Azure.Devices.Shared;
using ClusterManager.Dao.Infrastructures;

namespace ClusterManager.Core
{
    public class IoTHubResourceBus:IIoTHubResourceBus
    {
        readonly ITokenDto _tokenDto;
        readonly IIoTHubResourceDto _ioTHubResourceDto;
        private IAccountDao _accountDao;
        readonly IConfiguration _configuration;
        readonly AccountModel _accountModel;
        private readonly AccountDataModel _accountDataModel;
        private readonly ISubscriptionDto _subscriptionDto;
        //readonly string subid;
        readonly string access_token;
        public IoTHubResourceBus(
            ITokenDto tokenDto,
            ISubscriptionDto subscriptionDto,
            IIoTHubResourceDto ioTHubResourceDto,
            IConfiguration configuration,
            IAccountDao accountDao)
        {
            _accountDao = accountDao;
            this._tokenDto = tokenDto;
            this._ioTHubResourceDto = ioTHubResourceDto;
            this._configuration = configuration;
            _subscriptionDto = subscriptionDto;
            //this.subid= "6273fbea-8a11-498b-8218-02b6f4398e12";

            //this._accountModel = accountModel;
        }
    //    private readonly IIoTHubResourceDto _ioTHubResourceDto;



        //public IoTHubResourceBus(IIoTHubResourceDto ioTHubResourceDto)
        //{
        //    this._ioTHubResourceDto = ioTHubResourceDto;
 
//        }
        public async Task<string> GetBySubId(string email,string subid)
        {
            TokenModel Token = this._tokenDto.GetToken(email).Result;
            //var accountModel= this._configuration.GetSection("appsettings").Value;
            //SubId = this._accountModel.subscriptionId;
            //subId = "6273fbea-8a11-498b-8218-02b6f4398e12";
            
            Model.ResponseModel.IoTHubResourceModel objs = null;
            //IoTHubResourceDto ioTHubResourceDto = new IoTHubResourceDto();
            objs = await this._ioTHubResourceDto.ListBySubId(subid, Token.access_token);
            List<Model.IoTHubResourceViewModel> listBySubIdResponse = new List<Model.IoTHubResourceViewModel>();
            foreach (var ob in objs.value)
            {
                Model.IoTHubResourceViewModel ioTHubResource = new Model.IoTHubResourceViewModel();
                ioTHubResource.name = ob.name;
                ioTHubResource.location = ob.location;
                ioTHubResource.resourcegroup = ob.resourcegroup;
                ioTHubResource.type = ob.type;
                ioTHubResource.subscriptionid = ob.subscriptionid;
                listBySubIdResponse.Add(ioTHubResource);
            }
            string result = JsonConvert.SerializeObject(listBySubIdResponse);

            return result;
        }
        public async Task<string> CreateOrUpdate(IoTHubModel ioTHubModel,string email,string subid,string resourceGroupName)
        {
            //string subid = this._configuration["accountsetting:subscriptionId"];
            //string subid = "6273fbea-8a11-498b-8218-02b6f4398e12";
            string access_token = this._tokenDto.GetToken(email).Result.access_token;
            return await this._ioTHubResourceDto.CreateOrUpdate(subid,ioTHubModel,resourceGroupName,access_token);
        }
        public async Task<string> DeleteIoTHub(string email,string subid,string resourceGroupName, string resourceName)
        {
            //string subid = "6273fbea-8a11-498b-8218-02b6f4398e12";
            string access_token= this._tokenDto.GetToken(email).Result.access_token; 
            return await this._ioTHubResourceDto.DeleteIotHub(subid, resourceGroupName, resourceName, access_token);
        }
        public async Task<IoTHubInfoModel> GetIoTHubInfo(string email,string subid ,string resourceGroupName, string resourceName)
        {
            string access_token= this._tokenDto.GetToken(email).Result.access_token;
            return await this._ioTHubResourceDto.GetIoTHubInfo(subid, resourceGroupName, resourceName, access_token);
        }
        public async Task<IoTHubKeys> GetIoTHubKeys(string email, string subid,string resourceGroupName, string resourceName)
        {
            string access_token=this._tokenDto.GetToken(email).Result.access_token;
            return await this._ioTHubResourceDto.GetIoTHubKeys(subid, resourceGroupName, resourceName, access_token);
        }
        public async Task<string> CreateDevice(AccessPolicyModel accessPolicyModel, string deviceId,bool isIotEdge)
        {
            return await this._ioTHubResourceDto.CreateDevice(accessPolicyModel, deviceId,isIotEdge);
        }
        public async Task<DeviceInfoModel> GetDeviceInfo(string email,string subid,string resourceGroupName, string resourceName, string deviceId)
        {
            string access_token = this._tokenDto.GetToken(email).Result.access_token;
            IoTHubKeys ioTHubKeys = await this._ioTHubResourceDto.GetIoTHubKeys(subid, resourceGroupName, resourceName, access_token);
            IoTHubInfoModel ioTHubInfoModel = await this._ioTHubResourceDto.GetIoTHubInfo(subid, resourceGroupName, resourceName, access_token);
            AccessPolicyModel accessPolicyModel = new AccessPolicyModel()
            {
                HostName = ioTHubInfoModel.properties.hostName,
                SharedAccessKeyName = ioTHubKeys.value[0].keyName,
                SharedAccessKey = ioTHubKeys.value[0].primaryKey
            };
            return await this._ioTHubResourceDto.GetDeviceInfo(accessPolicyModel, deviceId, access_token);
        }
        public async Task<DeviceInfoModel> UpdateDeviceInfo(string email,string subid,string resourceGroupName, string resourceName, string deviceId, UpdateDeviceViewModel updateDeviceViewModel)
        {
            string access_token = this._tokenDto.GetToken(email).Result.access_token;
            IoTHubKeys ioTHubKeys = await this._ioTHubResourceDto.GetIoTHubKeys(subid, resourceGroupName, resourceName, access_token);
            IoTHubInfoModel ioTHubInfoModel = await this._ioTHubResourceDto.GetIoTHubInfo(subid, resourceGroupName, resourceName, access_token);
            AccessPolicyModel accessPolicyModel = new AccessPolicyModel()
            {
                HostName = ioTHubInfoModel.properties.hostName,
                SharedAccessKeyName = ioTHubKeys.value[0].keyName,
                SharedAccessKey = ioTHubKeys.value[0].primaryKey
            };
            return await this._ioTHubResourceDto.UpdateDeviceInfo(updateDeviceViewModel, accessPolicyModel, deviceId, access_token);
        }
        public async Task<object> GetIotEdgeDevices(AccessPolicyModel accessPolicyModel, string email)
        {
            string access_token = this._tokenDto.GetToken(email).Result.access_token;
            return await this._ioTHubResourceDto.GetIotEdgeDevices(accessPolicyModel, access_token);
        }
        public async Task<object> GetIotDevices(AccessPolicyModel accessPolicyModel, string email)
        {
            string access_token = this._tokenDto.GetToken(email).Result.access_token;
            return await this._ioTHubResourceDto.GetIotDevices(accessPolicyModel, access_token);
        }
        public IQuery ListDevices( int maxCount,AccessPolicyModel accessPolicyModel)
        {
            return this._ioTHubResourceDto.ListDevices(maxCount,accessPolicyModel);
        }
        public async Task<ConcurrentBag<Device>> GetDevicesAsync( AccessPolicyModel accessPolicyModel)
        {
            return await this._ioTHubResourceDto.GetDevicesAsync(accessPolicyModel);
        }
        public async Task<string> DeleteDevice(string deviceId,AccessPolicyModel accessPolicyModel)
        {
            return await this._ioTHubResourceDto.DeleteDevice(deviceId, accessPolicyModel);
            
        }
        public string GetDeviceKey(string deviceId, AccessPolicyModel accessPolicyModel)
        {
            return this._ioTHubResourceDto.GetDeviceKey(deviceId, accessPolicyModel);
        }
        public Task<Twin> GetDeivceTwin(string email, string deviceId, AccessPolicyModel accessPolicyModel)
        {
            string access_token=this._tokenDto.GetToken(email).Result.access_token;
            return this._ioTHubResourceDto.GetDeviceTwin(deviceId, accessPolicyModel,access_token);
        }
        //public Task<Twin> UpdateDeviceTwin(string deviceId, string jsonTwinPatch, string etag, AccessPolicyModel accessPolicyModel)
        //{
        //    return this._ioTHubResourceDto.UpdateDeviceTwin(deviceId, jsonTwinPatch, etag, accessPolicyModel);
        //}
        public async Task<string> UpdateDeviceTwin(string email,string subid,string resourceGroupName, string resourceName, string deviceId,Twin twin)
        {
            string access_token = this._tokenDto.GetToken(email).Result.access_token;
            IoTHubKeys ioTHubKeys = await this._ioTHubResourceDto.GetIoTHubKeys(subid,resourceGroupName, resourceName,access_token);
            IoTHubInfoModel ioTHubInfoModel = await this._ioTHubResourceDto.GetIoTHubInfo(subid, resourceGroupName, resourceName, access_token);
            AccessPolicyModel accessPolicyModel = new AccessPolicyModel()
            {
                HostName = ioTHubInfoModel.properties.hostName,
                SharedAccessKeyName = ioTHubKeys.value[0].keyName,
                SharedAccessKey=ioTHubKeys.value[0].primaryKey
            };
            return await this._ioTHubResourceDto.UpdateDeviceTwin(deviceId, twin, accessPolicyModel, access_token);
        }
        public async Task<object> GetIoTEdgeDeviceDeployment(string email,string subid,string resourceGroupName, string resourceName)
        {
            string access_token = this._tokenDto.GetToken(email).Result.access_token;
            IoTHubKeys ioTHubKeys = await this._ioTHubResourceDto.GetIoTHubKeys(subid, resourceGroupName, resourceName, access_token);
            IoTHubInfoModel ioTHubInfoModel = await this._ioTHubResourceDto.GetIoTHubInfo(subid, resourceGroupName, resourceName, access_token);
            AccessPolicyModel accessPolicyModel = new AccessPolicyModel()
            {
                HostName = ioTHubInfoModel.properties.hostName,
                SharedAccessKeyName = ioTHubKeys.value[1].keyName,
                SharedAccessKey = ioTHubKeys.value[1].primaryKey
            };
            return await this._ioTHubResourceDto.GetIoTEdgeDeviceDeployment(accessPolicyModel, access_token);
        }
        public async Task<object> GetDeviceModules(string email,string subid,string resourceGroupName,string resourceName,string deviceId)
        {
            string access_token = this._tokenDto.GetToken(email).Result.access_token;
            IoTHubKeys ioTHubKeys = await this._ioTHubResourceDto.GetIoTHubKeys(subid, resourceGroupName, resourceName,access_token);
            IoTHubInfoModel ioTHubInfoModel = await this._ioTHubResourceDto.GetIoTHubInfo(subid, resourceGroupName, resourceName, access_token);
            AccessPolicyModel accessPolicyModel = new AccessPolicyModel()
            {
                HostName = ioTHubInfoModel.properties.hostName,
                SharedAccessKeyName = ioTHubKeys.value[0].keyName,
                SharedAccessKey = ioTHubKeys.value[0].primaryKey
            };
            return await this._ioTHubResourceDto.GetDeviceModules(deviceId, accessPolicyModel, access_token);
        }
        public async Task<InsightResponseModel> GetIoTHubInsight(string email,string subid,string resourceGroupName,string resourceName,InsightModel insightModel)
        {
            string access_token = this._tokenDto.GetToken(email).Result.access_token;
            return await this._ioTHubResourceDto.GetIoTHubInsight(subid,resourceGroupName,resourceName,access_token,insightModel);
        }
        
    }
}
