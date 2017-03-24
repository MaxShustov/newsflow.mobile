using Newtonsoft.Json;

namespace WhatsSay.Core.Models
{
    public class LoginModel
    {
        [JsonProperty("grant_type")]
        public string GrantType { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }
    }
}