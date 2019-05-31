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
        private Profile currentProfile;


        public HttpDataSource(string host, string username)
        {
            BaseUrl = host;
            Username = username;
        }


        public Profile GetProfile()
        {
            string profileRoute = BaseUrl + "/Profile/active/" + Username;
            var task = client.GetStringAsync(profileRoute);
            task.Wait();
            var result = task.Result;
            JToken profileToken = JObject.Parse(result);
            currentProfile = JsonConvert.DeserializeObject<Profile>(profileToken.ToString());
            return currentProfile;
        }

        public void UpdateData(Computer computer)
        {
            string profileRoute = BaseUrl + "/Computer";
            String serializedComputer = JsonConvert.SerializeObject(computer);
            Console.WriteLine(serializedComputer);
            StringContent computerQuery = new StringContent(serializedComputer);
            computerQuery.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
            var task = client.PostAsync(profileRoute, computerQuery);
            task.Wait();
            HttpResponseMessage response = task.Result;
            response.EnsureSuccessStatusCode();
            Console.WriteLine(response.IsSuccessStatusCode);
        }
    }
}
