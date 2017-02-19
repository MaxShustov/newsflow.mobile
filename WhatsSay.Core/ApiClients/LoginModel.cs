using Newtonsoft.Json;

namespace WhatsSay.Core.ApiClients
{
    public class LoginModel
    {
        [JsonProperty("grunt_type")]
        public string GrantType { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }
    }
}