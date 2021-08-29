using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace csharp_http_api_quotesapp.Models.WriteModels
{
    public class PostUser
    {
        [JsonPropertyName("user")]
        public PostUserContent User { get; set; }

        public override string ToString()
        {
            return $"{User.Login} {User.Password}";
        }
    }
}