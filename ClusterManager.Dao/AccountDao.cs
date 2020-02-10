using ClusterManager.Dao.Infrastructures;
using MongoDB.Driver;
using ClusterManager.Utility;
using System;
using System.Collections.Generic;
using System.Text;
using ClusterManager.Model;
using ClusterManager.Model.ViewModels;
using MongoDB.Bson;
using MongoDB.Driver.Linq;

namespace ClusterManager.Dao
{
    public class AccountDao : IAccountDao
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
                servicePrinciples = null
            };
            _accountData.InsertOneAsync(accountDataModel);
            return new { success = true };
        }
        public AccountDataModel GetUserByEmail(string email)
        {
            if (UserIsExist(email))
            {
                AccountDataModel accountDataModel = _accountData.Find(s => s.Email == email).FirstOrDefault();
                AccountModel accountModel = new AccountModel
                {
                    email = accountDataModel.Email,
                    password = accountDataModel.Password,
                };
                return accountDataModel;
            }
            else
            {
                return null;
            }
        }
        public bool UserIsExist(string email)
        {
            var user = _accountData.Find(s => s.Email == email).FirstOrDefault();
            if (user == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public string AddServicePrinciple(string email, ServicePrinciple servicePrinciple)
        {
            AccountDataModel accountDataModel = _accountData.Find(s => s.Email == email).FirstOrDefault();
            List<ServicePrinciple> servicePrinciples = accountDataModel.servicePrinciples;
            if (servicePrinciples != null)
            {
                ServicePrinciple service = servicePrinciples.Find(s => s.TenantId == servicePrinciple.TenantId && s.ClientId == servicePrinciple.ClientId);
                if (service == null)
                {
                    accountDataModel.servicePrinciples.Add(servicePrinciple);
                }
                else
                {
                    return "service is already Exist";
                }
            }
            else
            {
                List<ServicePrinciple> temp_servicePrinciples = new List<ServicePrinciple>();
                temp_servicePrinciples.Add(servicePrinciple);
                accountDataModel.servicePrinciples = temp_servicePrinciples;
            }
            var filter = Builders<AccountDataModel>.Filter.Eq("Email", email);
            var update = Builders<AccountDataModel>.Update.Set("ServicePrinciples", accountDataModel.servicePrinciples);
            //BsonDocument bd = BsonExtensionMethods.ToBsonDocument(accountDataModel);
            _accountData.UpdateOne(filter, update);
            return "success";
        }
        public List<ServicePrinciple> ListServicePrinciples(string email)
        {
            AccountDataModel accountDataModel = _accountData.Find(s => s.Email == email).FirstOrDefault();
            List<ServicePrinciple> servicePrinciples = accountDataModel.servicePrinciples;
            return servicePrinciples;
        }
        public string UpdateClientSecret(string email, ServicePrinciple servicePrinciple)
        {
            AccountDataModel accountDataModel = _accountData.Find(s => s.Email == email).FirstOrDefault();
            accountDataModel.servicePrinciples.Find(s => s.TenantId == servicePrinciple.TenantId && s.ClientId == servicePrinciple.ClientId).ClientSecret = servicePrinciple.ClientSecret;
            var filter = Builders<AccountDataModel>.Filter.Eq("Email", email);
            var update = Builders<AccountDataModel>.Update.Set("ServicePrinciples", accountDataModel.servicePrinciples);
            //BsonDocument bd = BsonExtensionMethods.ToBsonDocument(accountDataModel);
            _accountData.UpdateOne(filter, update);
            return "success";
        }
        public string DeleteServicePrinciple(string email, string tenantId, string clientId)
        {
            AccountDataModel accountDataModel = _accountData.Find(s => s.Email == email).FirstOrDefault();
            ServicePrinciple servicePrinciple = accountDataModel.servicePrinciples.Find(s => s.TenantId == tenantId && s.ClientId == clientId);
            accountDataModel.servicePrinciples.Remove(servicePrinciple);
            var filter = Builders<AccountDataModel>.Filter.Eq("Email", email);
            var update = Builders<AccountDataModel>.Update.Set("ServicePrinciples", accountDataModel.servicePrinciples);
            //BsonDocument bd = BsonExtensionMethods.ToBsonDocument(accountDataModel);
            _accountData.UpdateOne(filter, update);
            return "success";
        }
        public ServicePrinciple GetCurrentService(string email)
        {
            AccountDataModel accountDataModel = _accountData.Find(s => s.Email == email).FirstOrDefault();
            ServicePrinciple servicePrinciple = accountDataModel.servicePrinciples.Find(s => s.flag == true);
            return servicePrinciple;
        }
        public string SetServicePrinciple(string email,string tenantId,string clientId)
        {
            AccountDataModel accountDataModel = _accountData.Find(s => s.Email == email).FirstOrDefault();
            ServicePrinciple current_servicePrinciple = accountDataModel.servicePrinciples.Find(s => s.flag == true);
            ServicePrinciple servicePrinciple = accountDataModel.servicePrinciples.Find(s => s.TenantId == tenantId && s.ClientId == clientId);
            if (current_servicePrinciple == null)
            {
                servicePrinciple.flag = true;
            }
            else
            {
                current_servicePrinciple.flag = false;
                servicePrinciple.flag = true;
            }
            var filter = Builders<AccountDataModel>.Filter.Eq("Email", email);
            var update = Builders<AccountDataModel>.Update.Set("ServicePrinciples", accountDataModel.servicePrinciples);
            _accountData.UpdateOne(filter, update);
            return "success";
        }
        public string GetClientSecret(string email,string tenantId,string clientId)
        {
            AccountDataModel accountDataModel = _accountData.Find(s => s.Email == email).FirstOrDefault();
            return accountDataModel.servicePrinciples.Find(s => s.TenantId == tenantId && s.ClientId == clientId).ClientSecret;
        }
        /*public ResponseSerializer AddServicePrinciple(string email, ServicePrinciple servicePrinciple)
        {
            string message = null;
            AccountDataModel accountDataModel = GetUserByEmail(email);
            var isExist = accountDataModel.servicePrinciples.Contains(servicePrinciple);
            if(isExist==false)
            {
                accountDataModel.servicePrinciples.Add(servicePrinciple);
                
                message = "OK";
            }
            else
            {
                message = "Error";
            }
            return new ResponseSerializer(200, message, accountDataModel);
        }
        public List<string> ListTenantIdByEmail(string email)
        {
            AccountDataModel accountDataModel = _accountData.Find(s => s.Email == email).FirstOrDefault();
            List<string> TenantIds = new List<string>();
            if (accountDataModel.Tenants != null)
            {
                foreach (Tenant tenant in accountDataModel.Tenants)
                {
                    TenantIds.Add(tenant.TenantId);
                }
                return TenantIds;
            }
            else
            {
                return null;
            }
            
        }
        public string AddTenantId(string email, string tenantId)
        {
            AccountDataModel accountDataModel = _accountData.Find(s => s.Email == email).FirstOrDefault();
            List<string> tenantIds = ListTenantIdByEmail(email);
            if (tenantIds != null)
            {
                if(!tenantIds.Contains(tenantId))
                {
                    Tenant tenant = new Tenant
                    {
                        TenantId = tenantId,
                    };
                    accountDataModel.Tenants.Add(tenant);
                    var filter = Builders<AccountDataModel>.Filter.Eq("Email", email);
                    var update = Builders<AccountDataModel>.Update.Set("Tenants", accountDataModel.Tenants);
                    //BsonDocument bd = BsonExtensionMethods.ToBsonDocument(accountDataModel);
                    _accountData.UpdateOne(filter, update);
                    return "success";
                }
                else
                {
                    return "error";
                }
            }
            else
            {
                Tenant tenant = new Tenant
                {
                    TenantId = tenantId,
                };
                List<Tenant> tenants = new List<Tenant>();
                tenants.Add(tenant);
                accountDataModel.Tenants = tenants;
                var filter = Builders<AccountDataModel>.Filter.Eq("Email", email);
                var update = Builders<AccountDataModel>.Update.Set("Tenants", accountDataModel.Tenants);
                //BsonDocument bd = BsonExtensionMethods.ToBsonDocument(accountDataModel);
                _accountData.UpdateOne(filter, update);
                return "success";
            }

        }
        public string AddClient(string email,string tenantId,Client client)
        {
            AccountDataModel accountDataModel = _accountData.Find(s => s.Email == email).FirstOrDefault();
            List<Client> clients = accountDataModel.Tenants.Find(t => t.TenantId == tenantId).clients;
            if (clients != null)
            {
                var c = clients.Find(i => i.ClientId == client.ClientId);
                if (c == null)
                {
                    clients.Add(client);
                    var filter = Builders<AccountDataModel>.Filter.Eq("Email", email);
                    var update = Builders<AccountDataModel>.Update.Set("Tenants", accountDataModel.Tenants);
                    //BsonDocument bd = BsonExtensionMethods.ToBsonDocument(accountDataModel);
                    _accountData.UpdateOne(filter, update);
                    return "success";
                }
                else
                {
                    return "error";
                }
            }                       
            else
            {
                List<Client> Temp_clients = new List<Client>();
                Temp_clients.Add(client);

                accountDataModel.Tenants.Find(t => t.TenantId == tenantId).clients = Temp_clients;
                var filter = Builders<AccountDataModel>.Filter.Eq("Email", email);
                var update = Builders<AccountDataModel>.Update.Set("Tenants", accountDataModel.Tenants);
                //BsonDocument bd = BsonExtensionMethods.ToBsonDocument(accountDataModel);
                _accountData.UpdateOne(filter, update);
                return "success";
            }
        }
        public List<Client> ListClientByTenantId(string email,string tenantId)
        {
            AccountDataModel accountDataModel = _accountData.Find(s => s.Email == email).FirstOrDefault();
            List<Client> clients = accountDataModel.Tenants.Find(t => t.TenantId == tenantId).clients;
            return clients;
        }
        public string UpdateClientSecret(string email,ServicePrinciple servicePrinciple)
        {
            AccountDataModel accountDataModel = _accountData.Find(s => s.Email == email).FirstOrDefault();
            accountDataModel.Tenants.Find(t => t.TenantId == servicePrinciple.TenantId).clients.Find(c => c.ClientId == servicePrinciple.ClientId).ClientSecret = servicePrinciple.ClientSecret;
            var filter = Builders<AccountDataModel>.Filter.Eq("Email", email);
            var update = Builders<AccountDataModel>.Update.Set("Tenants", accountDataModel.Tenants);
            //BsonDocument bd = BsonExtensionMethods.ToBsonDocument(accountDataModel);
            _accountData.UpdateOne(filter, update);
            return "success";
        }
        public object UpdateUserInfo(string email, ServicePrincipleModel servicePrincipleModel)
        {
            AccountDataModel accountData = GetUserByEmail(email);
            Client client = new Client
            {
                ClientId = servicePrincipleModel.ClientId,
                ClientSecret = servicePrincipleModel.ClientSerect
            };
            return null;
        }*/

    }
}
