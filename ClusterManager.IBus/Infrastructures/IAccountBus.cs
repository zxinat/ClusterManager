using ClusterManager.Model;
using ClusterManager.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClusterManager.Core.Infrastructures
{
    public interface IAccountBus
    {
        object CreateUser(string email, string pwd);
        object Login(string email, string pwd);
        //AccountModel GetUserInfo(string email);
        string AddServicePrinciple(string email, ServicePrinciple servicePrinciple);
        //string AddTenantId(string email, string tenantId);
        //string AddClient(string email, string tenantId, Client client);
        //List<string> ListTenantIdByEmail(string email);
        //List<Client> ListClientByTenantId(string email, string tenantId);
        string UpdateClientSecret(string email, ServicePrinciple servicePrinciple);
        List<ServicePrinciple> ListServicePrinciples(string email);
        string DeleteServicePrinciple(string email, string tenantId, string clientId);
        string GetClientSecret(string email, string tenantId, string clientId);
        ServicePrinciple GetCurrentService(string email);
        string SetServicePrinciple(string email, string tenantId, string clientId);
    }
}
