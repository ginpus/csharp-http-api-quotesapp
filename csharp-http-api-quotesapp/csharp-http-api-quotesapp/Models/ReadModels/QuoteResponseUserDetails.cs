using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace csharp_http_api_quotesapp.Models.ReadModels
{
    public class QuoteResponseUserDetails
    {
        [JsonPropertyName("favorite")]
        public bool Favorite { get; set; }

        [JsonPropertyName("upvote")]
        public bool Upvote { get; set; }

        [JsonPropertyName("downvote")]
        public bool Downvote { get; set; }

        [JsonPropertyName("hidden")]
        public bool Hidden { get; set; }
    }
}