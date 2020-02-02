using ClusterManager.Core.Infrastructures;
using ClusterManager.Dao.Infrastructures;
using ClusterManager.Model;
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
            if (_accountDao.UserIsExist(email))
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
                AccountModel user = _accountDao.GetUserByEmail(email);
                if (user.password == pwd)
                {
                    TokenModel tokenInfo = _authBus.RequestToken(email, pwd);
                    return new
                    {
                        success = true,
                        info = _accountDao.GetUserByEmail(email),
                        eamil = email,
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
    }
}
