using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace csharp_http_api_quotesapp.Models.WriteModels
{
    public class PostQuoteContent
    {
        [JsonPropertyName("author")]
        public string Author { get; set; }

        [JsonPropertyName("body")]
        public string Body { get; set; }
    }
}