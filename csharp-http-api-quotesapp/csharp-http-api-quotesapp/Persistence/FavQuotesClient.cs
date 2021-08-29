using csharp_http_api_quotesapp.Models.ReadModels;
using csharp_http_api_quotesapp.Models.WriteModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace csharp_http_api_quotesapp.Persistence
{
    public class FavQuotesClient : IFavQuotesClient
    {
        private readonly HttpClient _httpClient;

        public FavQuotesClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<GetQuotes> ShowAllQuotes()
        {
            const string url = "/api/quotes";
            return _httpClient.GetFromJsonAsync<GetQuotes>(url);
        }

        public async Task<GetSingleQuote> ShowQuoteById(int id)
        {
            var url = $"/api/quotes/{id}";
            var result = await _httpClient.GetFromJsonAsync<GetSingleQuote>(url);
            return result;
        }

        public async Task<PostUserResponse> CreateUserSession(string login, string password)
        {
            var userCreds = new PostUser
            {
                User = new PostUserContent
                {
                    Login = login,
                    Password = password
                    /*

                                        Login = login,
                                        Password = password*/
                }
            };
            const string url = "/api/session";
            var response = await _httpClient.PostAsJsonAsync(url, userCreds);
            return await response.Content.ReadFromJsonAsync<PostUserResponse>();
        }

        public async Task<HttpResponseMessage> PostQuote(string author, string quote, string userToken)
        {
            const string url = "/api/quotes";

            var quoteObj = new PostQuote
            {
                Quote = new PostQuoteContent
                {
                    Author = author,
                    Body = quote
                }
            };

            var quoteJson = JsonSerializer.Serialize(quoteObj);

            var request = new HttpRequestMessage();

            request.RequestUri = new Uri(_httpClient.BaseAddress, url);
            request.Method = HttpMethod.Post;
            request.Content = new StringContent(quoteJson, Encoding.UTF8, "application/json");

            request.Headers.Add("User-Token", userToken);

            var response = await _httpClient.SendAsync(request);

            Console.WriteLine(await response.Content.ReadAsStringAsync());

            return response;
        }

        public async Task<HttpResponseMessage> FavQuote(int id, string userToken)
        {
            var url = $"/api/{id.ToString()}/fav";

            /*            var quoteObj = new PostQuote
                        {
                            Quote = new PostQuoteContent
                            {
                                Author = author,
                                Body = quote
                            }
                        };*/

            //var quoteJson = JsonSerializer.Serialize(quoteObj);

            var request = new HttpRequestMessage();

            request.RequestUri = new Uri(_httpClient.BaseAddress, url);
            request.Method = HttpMethod.Put;
            //request.Content = new StringContent(quoteJson, Encoding.UTF8, "application/json");

            request.Headers.Add("User-Token", userToken);

            var response = await _httpClient.SendAsync(request);

            Console.WriteLine(await response.Content.ReadAsStringAsync());

            return response;
        }
    }
}