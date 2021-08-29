using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace csharp_http_api_quotesapp.Models.ReadModels
{
    public class GetQuotes
    {
        [JsonPropertyName("page")]
        public int Page { get; set; }

        [JsonPropertyName("last_page")]
        public bool LastPage { get; set; }

        [JsonPropertyName("quotes")]
        public IEnumerable<GetQuotesQuotes> Quotes { get; set; }

        public override string ToString()
        {
            return $"{Page} {LastPage}";
        }
    }
}