using csharp_http_api_quotesapp.Models.ReadModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace csharp_http_api_quotesapp.Persistence
{
    public interface IFavQuotesClient
    {
        Task<GetQuotes> ShowAllQuotes();

        Task<GetSingleQuote> ShowQuoteById(int id);

        Task<PostUserResponse> CreateUserSession(string login, string password);

        Task<HttpResponseMessage> PostQuote(string author, string quote, string userToken);

        Task<HttpResponseMessage> FavQuote(int id, string userToken);

        Task<HttpResponseMessage> UnFavQuote(int id, string userToken);
    }
}