using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ModernHttpClient;
using Newtonsoft.Json;
using WhatsSay.Core.ApiClients.Abstract;

namespace WhatsSay.Core.ApiClients.Implementation
{
    public class ApiContext : IApiContext
    {
        private const string LoginUrl = @"http://localhost:52185/api/auth/token";

        private readonly HttpClient _httpClient;

        public ApiContext()
        {
            _httpClient = new HttpClient(new NativeMessageHandler());
        }

        public async Task<string> Login(string login, string password)
        {
            var loginModel = new LoginModel()
            {
                GrantType = "password",
                Password = password,
                Username = login
            };

            var loginResult = await Post<LoginResultModel, LoginModel>(LoginUrl, loginModel);
            var token = $"{loginResult.TokenType} {loginResult.AccessToken}";

            _httpClient.DefaultRequestHeaders.Add("Authorization", token);

            return token;
        }

        public async Task<T> Get<T>(string url)
        {
            var result = await _httpClient.GetAsync(url);
            var json = await result.Content.ReadAsStringAsync();

            return (T)JsonConvert.DeserializeObject(json, typeof(T));
        }

        public async Task<TResult> Post<TResult, TContent>(string url, TContent content)
        {
            var json = JsonConvert.SerializeObject(content);
            var result = await _httpClient.PostAsync(url, new StringContent(json, Encoding.Unicode, "application/json"));
            var jsonResult = await result.Content.ReadAsStringAsync();

            return (TResult)JsonConvert.DeserializeObject(jsonResult, typeof(TResult));
        }

        public Task Put<T>(string url, T content)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(string url)
        {
            throw new System.NotImplementedException();
        }
    }
}