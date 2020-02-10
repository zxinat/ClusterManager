using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using ClusterManager.Dao.Infrastructures;
using ClusterManager.Dto.Infrastructures;
using ClusterManager.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ClusterManager.Dto
{
    public class SubscriptionDto:ISubscriptionDto
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IAccountDao _accountDao;

        public SubscriptionDto(IHttpClientFactory httpClientFactory, IAccountDao accountDao)
        {
            _clientFactory = httpClientFactory;
            _accountDao = accountDao;
        }
        public async Task<List<SubscriptionModel>> GetSubscriptions(string access_token)
        {
            string url = "https://management.chinacloudapi.cn/subscriptions?api-version=2018-02-01";
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            var client = this._clientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", access_token);
            var response = await client.SendAsync(request);
            string data = await response.Content.ReadAsStringAsync();
            SubscriptionsModel subscriptions = new SubscriptionsModel();
            
            if (response.IsSuccessStatusCode)
            {
                subscriptions = JsonConvert.DeserializeObject<SubscriptionsModel>(data);
            }
            else
            {
                Console.WriteLine("Error." + response.ReasonPhrase);
            }
            return subscriptions.value;
        }
    }
}
