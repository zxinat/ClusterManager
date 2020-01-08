using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using ClusterManager.Dto.Infrastructures;
using ClusterManager.Model.ResponseModel;
using Newtonsoft.Json;

namespace ClusterManager.Dto
{
    public class ResourceGroupDto : IResourceGroupDto
    {
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
    }
}
