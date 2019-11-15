using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetFinder.Models
{
    public class Authentication
    {
        [JsonProperty(PropertyName = "token_type")]
        public string TokenType { get; set; }
        [JsonProperty(PropertyName = "access_token")]
        public string AccessToken { get; set; }
    }
}
