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
        public UserLogin Login { get; }
        private Profile currentProfile;
        public string Token { get; private set; }

        public HttpDataSource(string host, UserLogin login)
        {
            BaseUrl = host;
            Login = login;
        }

        private void RetrieveToken()
        {
            string tokenRoute = BaseUrl + "/user/authenticate";
            string serializedLogin = JsonConvert.SerializeObject(Login);
            StringContent loginQuery = new StringContent(serializedLogin);
            loginQuery.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
            var task = client.PostAsync(tokenRoute, loginQuery);
            task.Wait();
            var result = task.Result;
            if (!result.EnsureSuccessStatusCode().IsSuccessStatusCode) throw new ArgumentException();

            var contentTask = result.Content.ReadAsStringAsync();
            contentTask.Wait();
            var contentString = contentTask.Result;
            JToken token = JObject.Parse(contentString);
            Token = JsonConvert.DeserializeObject<String>(token.ToString());
        }

        public Profile GetProfile()
        {
            string profileRoute = BaseUrl + "/Profile/active/" + Login.Username;
            var taskStatusCode = client.GetAsync(profileRoute);
            taskStatusCode.Wait();
            if (taskStatusCode.Result.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                RetrieveToken();
            }

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
            if (response.EnsureSuccessStatusCode().StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                RetrieveToken();
            }
            Console.WriteLine(response.IsSuccessStatusCode);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

    }
}
