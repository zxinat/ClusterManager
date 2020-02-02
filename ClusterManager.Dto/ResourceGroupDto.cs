using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using ClusterManager.Dto.Infrastructures;
using ClusterManager.Model.ResponseModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ClusterManager.Dto
{
    public class ResourceGroupDto : IResourceGroupDto
    {
        private readonly IHttpClientFactory _clientFactory;
        public ResourceGroupDto(IHttpClientFactory httpClientFactory)
        {
            this._clientFactory = httpClientFactory;
        }
        public async Task<ResourceGroupModel> GetAllResource(string subid,string access_token)
        {

            string url = string.Format("https://management.chinacloudapi.cn/" +
                "subscriptions/{0}/resourcegroups?api-version=2017-05-10", subid);
            ResourceGroupModel resourceGroup = null;
            using (HttpClient httpClient = new HttpClient())
            {
                //httpClient.DefaultRequestHeaders.Add("Cache-Control", "no-cache");
                //HttpContent content = new FormUrlEncodedContent(vals);
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", access_token);
                HttpResponseMessage hrm = httpClient.GetAsync(url).Result;
                if (hrm.IsSuccessStatusCode)
                {
                    string data = await hrm.Content.ReadAsStringAsync();
                    resourceGroup = JsonConvert.DeserializeObject<ResourceGroupModel>(data);
                    //await DataOperations(authenticationResponse);
                }
                else
                {
                    Console.WriteLine("Error." + hrm.ReasonPhrase);
                }
            }
            return resourceGroup;
        }
        public async Task<string> CreateOrUpdate(string subid,string resourceGroupName,string location,string access_token)
        {
            //List<KeyValuePair<string, string>> vals = new List<KeyValuePair<string, string>>();
            //vals.Add(new KeyValuePair<string, string>("location", location)); 
            //url="https://management.chinacloudapi.cn/subscriptions/{{subscriptionId}}/resourcegroups/{{resourceGroupName}}?api-version=2019-08-01"
            string url = string.Format("{0}/resourcegroups/{1}?api-version=2019-08-01",subid,resourceGroupName);
            var request = new HttpRequestMessage(HttpMethod.Put, url);
            var client = this._clientFactory.CreateClient("chinacloudapi");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", access_token);
            //string requestbody = JsonConvert.SerializeObject(resourceGroupName);
            JObject requestbodyJson = new JObject();
            requestbodyJson.Add("location", location);
            string requestbody = JsonConvert.SerializeObject(requestbodyJson);
            
            //HttpContent content = new FormUrlEncodedContent(vals);
            //string requestbody = string.Format("\"location\":\"{0}\"",location);
            request.Content = new StringContent(requestbody, UnicodeEncoding.UTF8, "application/json");
            var response = await client.SendAsync(request);
            string reasult = null;
            if (response.IsSuccessStatusCode)
            {
                reasult = response.StatusCode.ToString();
            }
            else
            {
                reasult = "Failed to Create ! ";
            }
            return reasult;
        }
        public async Task<string> ListResource(string subid,string resourceGroupName,string access_token)
        {
            string url = string.Format("{0}/resourceGroups/{1}/resources?api-version=2019-10-01", subid, resourceGroupName);
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            var client = this._clientFactory.CreateClient("chinacloudapi");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", access_token);
            var response = await client.SendAsync(request);
            string result = null;
            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsStringAsync();
                JObject job = (JObject)JsonConvert.DeserializeObject(result);
                
            }
            else
            {
                result = response.ReasonPhrase;
            }
            return result;
        }

    }
}
