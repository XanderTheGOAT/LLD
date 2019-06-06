using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using LightLinkModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace LightLinkDLL.DataAccess
{
    public class HttpDataSource : IDataSource
    {

        public string BaseUrl { get; }
        public UserLogin Login { get; }
        public string Token { get; private set; }

        private Profile currentProfile;
        private string filename = "tokens.txt";
        private static readonly HttpClient client = new HttpClient();

        public HttpDataSource(string host, UserLogin login)
        {
            BaseUrl = host;
            Login = login;
            ReadTokenFromFile();
            if (!String.IsNullOrEmpty(Token))
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Token.Split('/')[1]);
            else
                RetrieveToken();
        }

        private void RetrieveToken()
        {
            string tokenRoute = BaseUrl + "user/authenticate";
            string serializedLogin = JsonConvert.SerializeObject(Login);
            StringContent loginQuery = new StringContent(serializedLogin);
            loginQuery.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
            var task = client.PostAsync(tokenRoute, loginQuery);
            task.Wait();
            var result = task.Result;
            if (!result.IsSuccessStatusCode) throw new ArgumentException("Server threw " + result.StatusCode.ToString() + " error");

            var contentTask = result.Content.ReadAsStringAsync();
            contentTask.Wait();
            var contentString = contentTask.Result;
            JToken token = JObject.Parse(contentString);
            string value = token["userName"].ToString();
            string tokenstr = token["token"].ToString();

            Token = value + " / ";
            Token += tokenstr;
            client.DefaultRequestHeaders.Remove("Authorization");
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Token.Split('/')[1]);
        }

        public Profile GetProfile()
        {
            string profileRoute = BaseUrl + "profile/active/" + Login.Username;
            var httptask = client.GetAsync(profileRoute);
            httptask.Wait();
            HttpResponseMessage response = httptask.Result;
            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                RetrieveToken();
            var task = client.GetStringAsync(profileRoute);
            task.Wait();
            var result = task.Result;
            JToken profileToken = JObject.Parse(result);
            currentProfile = JsonConvert.DeserializeObject<Profile>(profileToken.ToString());
            return currentProfile;
        }

        public void UpdateData(Computer computer)
        {
            string profileRoute = BaseUrl + "computer";
            String serializedComputer = JsonConvert.SerializeObject(computer);
            StringContent computerQuery = new StringContent(serializedComputer);
            computerQuery.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
            var task = client.PostAsync(profileRoute, computerQuery);
            task.Wait();
            HttpResponseMessage response = task.Result;
            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                RetrieveToken();
            }
            else if (!response.IsSuccessStatusCode)
                throw new ArgumentException("Server threw " + response.StatusCode.ToString() + " error");
        }

        public void WriteTokenToFile(string token)
        {
            using (StreamWriter writer = new StreamWriter(new FileStream(filename, FileMode.OpenOrCreate)))
            {
                File.SetAttributes(filename, File.GetAttributes(filename) | FileAttributes.Hidden);
                writer.Write(token);
                writer.Flush();
            }
        }
        public void ReadTokenFromFile()
        {
            if (File.Exists(filename))
                Token = File.ReadAllText(filename);
            if (Token != null)
                if (String.Compare(Token.Split('/')[0], Login.Username, true) != 0)
                    Token = null;

        }
        public void Dispose()
        {
            WriteTokenToFile(Token);
        }

    }
}
