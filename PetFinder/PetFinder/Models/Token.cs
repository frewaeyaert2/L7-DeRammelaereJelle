using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetFinder.Models
{
    public class Token
    {
        [JsonProperty(PropertyName = "grant_type")]
        public string GrantType { get; set; } = "client_credentials";
        [JsonProperty(PropertyName = "client_id")]
        public string ClientId { get; set; } = "6OFg5fghAaAziT9KqcTdT9lYsSeRxpFcNKhnFO6ZtsXyFwmvnR";
        [JsonProperty(PropertyName = "client_secret")]
        public string ClientSecret { get; set; } = "PFD5CtYOn67Y9WSoaoOsmonqJtCbQHSAvyeTE2xp";
    }
}
