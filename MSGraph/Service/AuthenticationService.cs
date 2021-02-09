using System;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using MSGraph.IService;
using System.Collections.Generic;

namespace MSGraph.Service
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly Configuration configuration = new Configuration();
        
        public async Task<dynamic> GetAuthenticationInfo(string accessToken)
        {
            //1. Get Access_Token
            var pairs = new List<KeyValuePair<string, string>>
            {
            new KeyValuePair<string, string>("client_id", configuration.ClientID),
            new KeyValuePair<string, string>("scope", configuration.Scope),
            new KeyValuePair<string, string>("code", accessToken),
            new KeyValuePair<string, string>("redirect_uri", configuration.RedirectUri),
            new KeyValuePair<string, string>("grant_type", configuration.GrandType),
            new KeyValuePair<string, string>("client_secret", configuration.ClientSecret),
            };

            var tokenContent = new FormUrlEncodedContent(pairs);
            var tokenClient = new HttpClient { BaseAddress = new Uri("https://login.microsoftonline.com") };
            var tokenResponse = tokenClient.PostAsync("/common/oauth2/v2.0/token", tokenContent).Result;
            string tokenTmp = tokenResponse.Content.ReadAsStringAsync().Result;
            dynamic tokenJson = JsonConvert.DeserializeObject(tokenTmp);
            string token = "Bearer " + tokenJson.access_token;

            //2. Get User Data
            HttpClient client = new HttpClient();
            var url = "https://graph.microsoft.com/beta/me";
            HttpRequestMessage dataRequest = new HttpRequestMessage(HttpMethod.Get, url);
            dataRequest.Headers.Add("Authorization", token);
            HttpResponseMessage dataResponse = await client.SendAsync(dataRequest);
            string result = dataResponse.Content.ReadAsStringAsync().Result;

            return result;
        }
    }
}
