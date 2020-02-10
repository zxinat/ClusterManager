using ClusterManager.Core.Infrastructures;
using ClusterManager.Dao.Infrastructures;
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
        private readonly IAccountDao _accountDao;
        public AKSBus(IAKSDto aKSDto,ITokenDto tokenDto,IAccountDao accountDao)
        {
            this._aKSDto = aKSDto;
            this._tokenDto = tokenDto;
            _accountDao = accountDao;

        }
        public async Task<object> ListAllAKS(string email,string subid)
        {
            string access_token = this._tokenDto.GetToken(email).Result.access_token;
            return await this._aKSDto.ListAllAKS(subid, access_token);
        }
        public async Task<object> GetAKSInfo(string email, string subid,string resourceGroup, string AKSName)
        {
            string access_token = this._tokenDto.GetToken(email).Result.access_token;
            return await this._aKSDto.GetAKSInfo(subid, resourceGroup, AKSName, access_token);
        }
        public async Task<object> CreateAKS(string email,string subid,string resourceGroupName, CreateAKSModel createAKSModel)
        {
            string access_token = this._tokenDto.GetToken(email).Result.access_token;
            ServicePrinciple servicePrinciple = _accountDao.GetCurrentService(email);
            return await this._aKSDto.CreateAKS(subid, resourceGroupName, createAKSModel, servicePrinciple.ClientId, servicePrinciple.ClientSecret, access_token);
        }
    }
}
