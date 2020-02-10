using ClusterManager.Core.Infrastructures;
using ClusterManager.Dao.Infrastructures;
using ClusterManager.Model;
using ClusterManager.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClusterManager.Core
{
    public class AccountBus:IAccountBus
    {
        private readonly IAuthBus _authBus;
        private readonly IAccountDao _accountDao;
        public AccountBus(IAccountDao accountDao,IAuthBus authBus)
        {
            _authBus = authBus;
            _accountDao = accountDao;
        }
        public object CreateUser(string email,string pwd)
        {
            object result = null;
            if (_accountDao.UserIsExist(email)==false)
            {
                result= _accountDao.CreateUser(email, pwd);
            }
            else
            {
                result = new { success = false };
            }
            return result;
        }
        public object Login(string email,string pwd)
        {
            if(_accountDao.UserIsExist(email))
            {
                AccountDataModel user = _accountDao.GetUserByEmail(email);
                if (user.Password== pwd)
                {
                    TokenModel tokenInfo = _authBus.RequestToken(email, pwd);
                    return new
                    {
                        success = true,
                        info = user.Id,
                        email = email,
                        access_token = tokenInfo.access_token
                    };
                }
                else
                {
                    return new
                    {
                        success = false,
                        info = 1
                    };
                }   
            }
            else
            {
                return new
                {
                    success = false,
                    info = 0
                };
            }
        }
        /*public AccountModel GetUserInfo(string email)
        {
            AccountDataModel accountDataModel = this._accountDao.GetUserByEmail(email);
            AccountModel accountModel = new AccountModel
            {
                email = accountDataModel.Email,
                tenantId=accountDataModel.TenantId,
                subscriptionId=accountDataModel.SubscriptionId,
                clientId=accountDataModel.ClientId
            };
            return accountModel;
        }*/
        public string AddServicePrinciple(string email,ServicePrinciple servicePrinciple)
        {
             
            return this._accountDao.AddServicePrinciple(email, servicePrinciple);
        }
        public string UpdateClientSecret(string email, ServicePrinciple servicePrinciple)
        {
            return this._accountDao.UpdateClientSecret(email, servicePrinciple);
        }
        public List<ServicePrinciple> ListServicePrinciples(string email)
        {
            return this._accountDao.ListServicePrinciples(email);
        }
        public string DeleteServicePrinciple(string email, string tenantId, string clientId)
        {
            return this._accountDao.DeleteServicePrinciple(email, tenantId, clientId);
        }
        public string GetClientSecret(string email, string tenantId, string clientId)
        {
            return this._accountDao.GetClientSecret(email, tenantId, clientId);
        }
        public ServicePrinciple GetCurrentService(string email)
        {
            return this._accountDao.GetCurrentService(email);
        }
        public string SetServicePrinciple(string email,string tenantId,string clientId)
        {
            return this._accountDao.SetServicePrinciple(email, tenantId, clientId);
        }

        /*
        public string AddTenantId(string email, string tenantId)
        {
            return this._accountDao.AddTenantId(email, tenantId);
        }
        public List<string> ListTenantIdByEmail(string email)
        {
            return this._accountDao.ListTenantIdByEmail(email);
        }
        public string AddClient(string email,string tenantId,Client client)
        {
            return this._accountDao.AddClient(email, tenantId, client);
        }
        public List<Client> ListClientByTenantId(string email,string tenantId)
        {
            return this._accountDao.ListClientByTenantId(email, tenantId);
        }*/

    }
}
