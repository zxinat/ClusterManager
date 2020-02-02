using ClusterManager.Dto.Infrastructures;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using ClusterManager.Utility;
using ClusterManager.Model;

namespace ClusterManager.Dto
{
    public class AKSDto : IAKSDto
    {
        readonly IHttpClientFactory _clientFactory;
        public AKSDto(IHttpClientFactory clientFactory)
        {
            this._clientFactory = clientFactory;
        }
        public async Task<object> ListAllAKS(string subid, string access_token)
        {
            var requestmodel = new JObject();
            var requests = new JArray
            {
                new JObject
                {
                    { "httpMethod","GET"},
                    { "requestHeaderDetails",
                        new JObject
                        {
                            { "commandName", "HubsExtension.GridV2Browse.resource-ManagedClusters.-1" }
                        }
                    },
                    { "url",
                        string.Format("/resources?api-version=2014-04-01-preview&%24filter=(subscriptionId%20eq%20'{0}')%20and%20(resourceType%20eq%20'microsoft.containerservice%2Fmanagedclusters')",subid)
                    }

                }
            };
            requestmodel.Add("requests", requests);
            string url = "https://management.chinacloudapi.cn/batch?api-version=2015-11-01";
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            var client = this._clientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", access_token);
            string requestbody = JsonConvert.SerializeObject(requestmodel);
            request.Content = new StringContent(requestbody, UnicodeEncoding.UTF8, "application/json");
            var response = await client.SendAsync(request);
            string result = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                JObject job = (JObject)JsonConvert.DeserializeObject(result);
                return job;
            }
            else
            {
                return response.ReasonPhrase;
            }
        }
        public async Task<object> GetAKSInfo(string subid,string resourceGroup,string AKSName,string access_token)
        {
            string url = string.Format("{0}/resourceGroups/{1}/providers/Microsoft.ContainerService" +
                "/managedClusters/{2}?api-version=2018-03-31",subid,resourceGroup,AKSName);
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            var client = this._clientFactory.CreateClient("chinacloudapi");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", access_token);
            var response = await client.SendAsync(request);
            string result = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject(result);
            }
            else
            {
                return response.ReasonPhrase;
            }
        }
        public async Task<object> CreateAKS(string subid, string resourceGroupName, CreateAKSModel createAKSModel,
            string clientId,string clientSecret,string access_token)
        {
            CreateRequestJObject createRequestJObject = new CreateRequestJObject();
            var requestmodel = createRequestJObject.CreateAKSRequestJObject(createAKSModel,clientId,clientSecret);
            string url = string.Format("{0}/resourceGroups/{1}/providers/Microsoft.ContainerService" +
                "/managedClusters/{2}?api-version=2019-10-01", subid, resourceGroupName, createAKSModel.name);
            var request = new HttpRequestMessage(HttpMethod.Put, url);
            var client = this._clientFactory.CreateClient("chinacloudapi");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", access_token);
            string requestbody = JsonConvert.SerializeObject(requestmodel);
            request.Content = new StringContent(requestbody, UnicodeEncoding.UTF8, "application/json");
            var response = await client.SendAsync(request);
            string result = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject(result);
            }
            else
            {
                return response.ReasonPhrase;
            }
        }
    }
}
