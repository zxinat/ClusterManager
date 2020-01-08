using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ClusterManager.Utility
{
    public class AuthenticationResponse
    {
        public string access_token { get; set; }
        public int expires_in { get; set; }
        public int expires_on { get; set; }
        public int ext_expires_in { get; set; }
        public int not_before { get; set; }
        public string resource { get; set; }
        public string token_type { get; set; }    
    }
    public class AuthResponse
    {
        static string resourceUrl = "https://management.chinacoudapi.cn";
        static string clientId = "57d1ea2f-7ba4-4d03-936a-036368ff957c";
        static string clientSecret = "77b650d9-f8d3-4511-8587-c6c930e05225";
        static string tenantId = "c7917735-5d61-4832-8b54-b11d5f1e7810";
        public static async void GetAuthorizationResponse()
        {

            List<KeyValuePair<string, string>> vals = new List<KeyValuePair<string, string>>();

            vals.Add(new KeyValuePair<string, string>("client_id", clientId));
            vals.Add(new KeyValuePair<string, string>("resource", resourceUrl));
            vals.Add(new KeyValuePair<string, string>("grant_type", "client_credentials"));
            vals.Add(new KeyValuePair<string, string>("client_secret", clientSecret));
            string tokenUrl = string.Format("https://login.chinacloudapi.cn/{0}/oauth2/token", tenantId);

            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Cache-Control", "no-cache");
                HttpContent content = new FormUrlEncodedContent(vals);
                HttpResponseMessage hrm = httpClient.GetAsync(tokenUrl).Result;
                AuthenticationResponse authenticationResponse = null;
                if (hrm.IsSuccessStatusCode)
                {
                    string data = await hrm.Content.ReadAsStringAsync();
                    authenticationResponse = JsonConvert.DeserializeObject<AuthenticationResponse>(data);
                    Console.WriteLine(authenticationResponse);
                    //await DataOperations(authenticationResponse);
                }
                else
                {
                    Console.WriteLine("Error." + hrm.ReasonPhrase);
                }
            }
        }


    }
}
