using System;
using System.Collections.Generic;
using System.Text;
using ClusterManager.Core.Infrastructures;
using ClusterManager.Model;
using ClusterManager.Dto;
using ClusterManager.Dto.Infrastructures;
using System.Threading.Tasks;
using ClusterManager.Model.ResponseModel;
using ClusterManager.Model.ViewModels;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;

namespace ClusterManager.Core
{
    public class IoTHubResourceBus:IIoTHubResourceBus
    {
        readonly ITokenDto _tokenDto;
        readonly IIoTHubResourceDto _ioTHubResourceDto;
        readonly IConfiguration _configuration;
        public IoTHubResourceBus(
            ITokenDto tokenDto,
            IIoTHubResourceDto ioTHubResourceDto,
            IConfiguration configuration)
        {
            this._tokenDto = tokenDto;
            this._ioTHubResourceDto = ioTHubResourceDto;
            this._configuration = configuration;
            
            //this._accountModel = accountModel;
        }
    //    private readonly IIoTHubResourceDto _ioTHubResourceDto;



        //public IoTHubResourceBus(IIoTHubResourceDto ioTHubResourceDto)
        //{
        //    this._ioTHubResourceDto = ioTHubResourceDto;
 
//        }
        public async Task<string> GetBySubId(string SubId)
        {
            //SubId = this._configuration["accountsetting:subscriptionId"];
            SubId = "6273fbea-8a11-498b-8218-02b6f4398e12";
            TokenModel Token = this._tokenDto.GetToken().Result;
            Model.ResponseModel.IoTHubResourceModel objs = null;
            //IoTHubResourceDto ioTHubResourceDto = new IoTHubResourceDto();
            objs = await this._ioTHubResourceDto.ListBySubId(SubId, Token.access_token);
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
        public async Task<string> CreateOrUpdate(IoTHubModel ioTHubModel,string resourceGroupName)
        {
            //string subid = this._configuration["accountsetting:subscriptionId"];
            string subid = "6273fbea-8a11-498b-8218-02b6f4398e12";
            string access_token = this._tokenDto.GetToken().Result.access_token;
            return await this._ioTHubResourceDto.CreateOrUpdate(subid,ioTHubModel,resourceGroupName,access_token);
        }
    }
}
