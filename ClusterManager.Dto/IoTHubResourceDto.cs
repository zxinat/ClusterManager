using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ClusterManager.Model;
using ClusterManager.Model.ResponseModel;
using Newtonsoft.Json;
using ClusterManager.Dto.Infrastructures;
using System.Net.Http.Headers;
using ClusterManager.Model.ViewModels;
//using Microsoft.IdentityModel.Clients.ActiveDirectory;
namespace ClusterManager.Dto
{
    public class IoTHubResourceDto:IIoTHubResourceDto
    {
        readonly IHttpClientFactory _clientFactory;
        public IoTHubResourceDto(IHttpClientFactory clientFactory)
        {
            this._clientFactory = clientFactory;
        }
        public async Task<Model.ResponseModel.IoTHubResourceModel> ListBySubId(string SubId,string access_token)

        {
            //List<KeyValuePair<string, string>> vals = new List<KeyValuePair<string, string>>();

            //vals.Add(new KeyValuePair<string, string>("subscriptionId", SubId)); 
            string url = string.Format("https://management.chinacloudapi.cn/subscriptions/{0}" +
                "/providers/Microsoft.Devices/IotHubs?api-version=2018-04-01", SubId);
            Model.ResponseModel.IoTHubResourceModel objs =null;
            using(HttpClient httpClient = new HttpClient())
            {
                //httpClient.DefaultRequestHeaders.Add("Cache-Control", "no-cache");
                //HttpContent content = new FormUrlEncodedContent(vals);
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",access_token);
                HttpResponseMessage hrm = httpClient.GetAsync(url).Result;
                if (hrm.IsSuccessStatusCode)
                {
                    string data = await hrm.Content.ReadAsStringAsync();
                    objs = JsonConvert.DeserializeObject<Model.ResponseModel.IoTHubResourceModel>(data);
                    //await DataOperations(authenticationResponse);
                }
                else
                {
                    Console.WriteLine("Error." + hrm.ReasonPhrase);
                }
            }
            return objs;
        }
        public async Task<string> CreateOrUpdate(string subid,IoTHubModel ioTHubModel,string resourceGoupNname ,string access_token)
        {
            string url = string.Format("{0}/resourceGroups/{1}/providers/Microsoft.Devices/IotHubs/" +
                "{2}?api-version=2018-04-01",subid, resourceGoupNname, ioTHubModel.name);
            var request = new HttpRequestMessage(HttpMethod.Put, url);
            var client = this._clientFactory.CreateClient("chinacloudapi");
            client.DefaultRequestHeaders.Authorization=new AuthenticationHeaderValue("Bearer", access_token);
            string requestbody = JsonConvert.SerializeObject(ioTHubModel);
            request.Content= new StringContent(requestbody, UnicodeEncoding.UTF8, "application/json");
            var response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                return "success";
            }
            else
            {
                return "error";
            }
            /*string url = string.Format("https://management.chinacloudapi.cn/subscriptions/" +
                "{0}/resourceGroups/{1}/" +
                "providers/Microsoft.Devices/IotHubs/" +
                "{2}?api-version=2018-04-01",subid,ioTHubModel.resourceGroupName,ioTHubModel.iothubName);
            using (HttpClient httpClient = new HttpClient())
            {
                //httpClient.DefaultRequestHeaders.Add("Cache-Control", "no-cache");
                string requestbody = JsonConvert.SerializeObject(ioTHubModel);
                var content = new StringContent(requestbody, UnicodeEncoding.UTF8, "application/json");
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", access_token);
                HttpResponseMessage hrm =  httpClient.PutAsync(url,content).Result;
                if (hrm.IsSuccessStatusCode)
                {
                    return "success";
                }
                else
                {
                    Console.WriteLine("Error." + hrm.ReasonPhrase);
                    return "error";
                }
            }*/
            
        }
    
    }
}
