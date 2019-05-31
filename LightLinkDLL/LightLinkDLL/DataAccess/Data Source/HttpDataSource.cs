using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using LightLinkModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace LightLinkDLL.DataAccess
{
    public class HttpDataSource : IDataSource
    {

        private static readonly HttpClient client = new HttpClient();

        public string BaseUrl { get; }
        public string Username { get; }
        private string responseString = null;
        private bool finished = false;
        private Profile currentProfile;

        public HttpDataSource(string host, string username)
        {
            BaseUrl = host;
            Username = username;
        }

        private async void GetInformation(String url)
        {
            responseString = await client.GetStringAsync(url);
            finished = true;
        }

        public Profile GetProfile()
        {
            if (currentProfile is null)
            {
                string profileRoute = BaseUrl + "/Profile/active/" + Username;
                GetInformation(profileRoute);
                if (finished)
                {
                    if (string.IsNullOrEmpty(responseString)) throw new Exception();
                    JToken profileToken = JObject.Parse(responseString.Trim());
                    finished = false;
                    currentProfile = JsonConvert.DeserializeObject<Profile>(profileToken.ToString());
                }
            }
            return currentProfile;
        }

        public async void UpdateData(Computer computer)
        {
            string profileRoute = BaseUrl + "/Computer";
            String serializedComputer = JsonConvert.SerializeObject(computer);
            Console.WriteLine(serializedComputer);
            StringContent computerQuery = new StringContent(serializedComputer);
            computerQuery.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");               
            HttpResponseMessage response = await client.PostAsync(profileRoute, computerQuery);
            response.EnsureSuccessStatusCode();
        }
    }
}
