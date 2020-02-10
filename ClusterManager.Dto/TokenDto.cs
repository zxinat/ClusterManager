using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ClusterManager.Dao.Infrastructures;
using ClusterManager.Dto.Infrastructures;
using ClusterManager.Model;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace ClusterManager.Dto
{
    public class TokenDto:ITokenDto
    {
        private readonly IAccountDao _accountDao;
        private readonly IConfiguration _configuration; 
        public TokenDto(IConfiguration configuration,IAccountDao accountDao)
        {
            this._accountDao = accountDao;
            this._configuration = configuration;
        }
        public async Task<TokenModel>  GetToken(string email)
        {
            ServicePrinciple servicePrinciple=this._accountDao.GetCurrentService(email);
            //string clientId = this._configuration["accountsetting:clientId"];
            //string clientSecret = this._configuration["accountsetting:clientSecret"];
            //string resource = this._configuration["accountsetting:resource"];
            //string tenantId = this._configuration["accountsetting:tenantId"];
            //string tenantId = "c7917735-5d61-4832-8b54-b11d5f1e7810";
            string tenantId = servicePrinciple.TenantId;
            //string clientSecret = "77b650d9-f8d3-4511-8587-c6c930e05225";
            string clientSecret = servicePrinciple.ClientSecret;
            string resource = "https://management.chinacloudapi.cn";
            string clientId = servicePrinciple.ClientId;
            //string clientId = "57d1ea2f-7ba4-4d03-936a-036368ff957c";
            List<KeyValuePair<string, string>> vals = new List<KeyValuePair<string, string>>();
            vals.Add(new KeyValuePair<string, string>("client_id", clientId));
            vals.Add(new KeyValuePair<string, string>("resource", resource));
            vals.Add(new KeyValuePair<string, string>("grant_type", "client_credentials"));
            vals.Add(new KeyValuePair<string, string>("client_secret", clientSecret));
            string tokenUrl = string.Format("https://login.chinacloudapi.cn/{0}/oauth2/token",tenantId);
            TokenModel TokenResponse = null;
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Cache-Control", "no-cache");
                HttpContent content = new FormUrlEncodedContent(vals);
                HttpResponseMessage hrm = httpClient.PostAsync(tokenUrl,content).Result;
                
                if (hrm.IsSuccessStatusCode)
                {
                    string data = await hrm.Content.ReadAsStringAsync();
                    TokenResponse = JsonConvert.DeserializeObject<TokenModel>(data);
                    Console.WriteLine(TokenResponse);
                    //await DataOperations(authenticationResponse);
                }
                else
                {
                    Console.WriteLine("Error." + hrm.ReasonPhrase);
                }

            }
            return TokenResponse ;
        }                
    }
}
