using ClusterManager.Core.Infrastructures;
using ClusterManager.Dto.Infrastructures;
using ClusterManager.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClusterManager.Core
{
    public class AKSBus:IAKSBus
    {
        private readonly IAKSDto _aKSDto;
        private readonly ITokenDto _tokenDto;
        private string _subid;
        private string _clientId;
        private string _clientSecret;
        public AKSBus(IAKSDto aKSDto,ITokenDto tokenDto)
        {
            this._aKSDto = aKSDto;
            this._tokenDto = tokenDto;
            this._subid= "6273fbea-8a11-498b-8218-02b6f4398e12";
            this._clientId = "57d1ea2f-7ba4-4d03-936a-036368ff957c";
            this._clientSecret = "77b650d9-f8d3-4511-8587-c6c930e05225";

        }
        public async Task<object> ListAllAKS()
        {
            string access_token = this._tokenDto.GetToken().Result.access_token;
            return await this._aKSDto.ListAllAKS(this._subid, access_token);
        }
        public async Task<object> GetAKSInfo(string resourceGroup, string AKSName)
        {
            string access_token = this._tokenDto.GetToken().Result.access_token;
            return await this._aKSDto.GetAKSInfo(this._subid, resourceGroup, AKSName, access_token);
        }
        public async Task<object> CreateAKS(string resourceGroupName, CreateAKSModel createAKSModel)
        {
            string access_token = this._tokenDto.GetToken().Result.access_token;
            return await this._aKSDto.CreateAKS(this._subid, resourceGroupName, createAKSModel, this._clientId, this._clientSecret, access_token);
        }
    }
}
