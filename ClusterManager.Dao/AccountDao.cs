using ClusterManager.Dao.Infrastructures;
using MongoDB.Driver;
using ClusterManager.Utility;
using System;
using System.Collections.Generic;
using System.Text;
using ClusterManager.Model;

namespace ClusterManager.Dao
{
    public class AccountDao:IAccountDao
    {
        private readonly IMongoCollection<AccountDataModel> _accountData;
        public AccountDao()
        {
            var client = new MongoClient(Constant.getMongoDBConnectString());
            var database = client.GetDatabase("azureuser");
            _accountData = database.GetCollection<AccountDataModel>("userinfo");
        }
        public object CreateUser(string email, string pwd)
        {
            AccountDataModel accountDataModel = new AccountDataModel
            {
                Email = email,
                Password = pwd,

            };
            _accountData.InsertOneAsync(accountDataModel);
            return new { success=true};
        }
        public AccountModel GetUserByEmail(string email)
        {
            if(UserIsExist(email))
            {
               AccountDataModel accountDataModel = _accountData.Find(s => s.Email == email).FirstOrDefault();
                AccountModel accountModel = new AccountModel
                {
                    email = accountDataModel.Email,
                    password = accountDataModel.Password,
                };
                return accountModel;
            }
            else
            {
                return null;
            }
        }
        public bool UserIsExist(string email)
        {
            var user= _accountData.Find(s => s.Email == email).FirstOrDefault();
            if (user == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
