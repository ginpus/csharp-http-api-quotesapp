using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace csharp_http_api_quotesapp.Models.ReadModels
{
    public class GetQuotesQuotes
    {
        [JsonPropertyName("tags")]
        public IEnumerable<string> Tags { get; set; }

        [JsonPropertyName("favorite")]
        public bool Favorite { get; set; }

        [JsonPropertyName("author_permalink")]
        public string AuthorPermalink { get; set; }

        [JsonPropertyName("body")]
        public string Body { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("favorites_count")]
        public int FavoritesCount { get; set; }

        [JsonPropertyName("upvotes_count")]
        public int UpvotesCount { get; set; }

        [JsonPropertyName("downvotes_count")]
        public int DownvotesCount { get; set; }

        [JsonPropertyName("dialogue")]
        public bool Dialogue { get; set; }

        [JsonPropertyName("author")]
        public string Author { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }

        public override string ToString()
        {
            return $"{Id} - {AuthorPermalink}:\n {Body}";
        }
    }
}