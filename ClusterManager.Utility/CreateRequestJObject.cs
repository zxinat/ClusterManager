using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using ClusterManager.Model;

namespace ClusterManager.Utility
{
    public class CreateRequestJObject
    {
        public JObject CreateAKSRequestJObject(CreateAKSModel AKSModel,string clientId,string clientSecret)
        {
            var requestmodel = new JObject
            {
                {"location",AKSModel.location }
            };
            var properties = new JObject
            {
                { "kubernetesVersion",AKSModel.Properties.kubernetesVersion},
                { "dnsPrefix",AKSModel.Properties.dnsPrefix}
            };
            var agentPoolProfiles = new JArray
            {
                new JObject
                {
                    {"name","nodepool1" },
                    { "count",AKSModel.Properties.agentPoolProfiles[0].count},
                    { "vmSize",AKSModel.Properties.agentPoolProfiles[0].vmSize}
                }
            };
            var networkProfile = new JObject
            {
                {"loadBalancerSku", AKSModel.Properties.networkProfile.loadBalancerSku},
                { "outboundType","loadBalancer"}
            };
            var servicePrincipalProfile = new JObject
            {
                {"clientId",clientId },
                { "secret",clientSecret}
            };
            properties.Add("agentPoolProfiles", agentPoolProfiles);
            properties.Add("networkProfile", networkProfile);
            properties.Add("servicePrincipalProfile", servicePrincipalProfile);
            requestmodel.Add("properties", properties);
            return requestmodel;
        }
        public JObject CreateModulesContentRequestJObject()
        {
            var requestBody = new JObject
            {

            };
            var modulesContent = new JObject
            {
            };
            return null;   
        }
    }
}
