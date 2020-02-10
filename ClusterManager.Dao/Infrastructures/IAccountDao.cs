using ClusterManager.Model;
using ClusterManager.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClusterManager.Dao.Infrastructures
{
    public interface IAccountDao
    {
        object CreateUser(string email, string pwd);
        AccountDataModel GetUserByEmail(string email);
        bool UserIsExist(string email);
        //ResponseSerializer AddServicePrinciple(string email, ServicePrinciple servicePrinciple);
        //string AddTenantId(string email, string tenantId);
        //string AddClient(string email, string tenantId, Client client);
        //List<Client> ListClientByTenantId(string email, string tenantId);
        //List<string> ListTenantIdByEmail(string email);
        string UpdateClientSecret(string email, ServicePrinciple servicePrinciple);
        string AddServicePrinciple(string email, ServicePrinciple servicePrinciple);
        List<ServicePrinciple> ListServicePrinciples(string email);
        string DeleteServicePrinciple(string email, string tenantId, string clientId);
        string GetClientSecret(string email, string tenantId, string clientId);
        ServicePrinciple GetCurrentService(string email);
        string SetServicePrinciple(string email, string tenantId, string clientId);

    }
}
