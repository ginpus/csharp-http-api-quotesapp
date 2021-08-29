using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using csharp_http_api_quotesapp.Models.ReadModels;
using csharp_http_api_quotesapp.Persistence;
using Microsoft.Extensions.DependencyInjection;

namespace csharp_http_api_quotesapp
{
    internal class Program
    {
        public static async Task Main(string[] args)
        {
            var startup = new Startup();
            var serviceProvider = startup.ConfigureServices();

            var favQuotesClient = serviceProvider.GetService<IFavQuotesClient>();

            while (true)
            {
                Console.WriteLine("User:");
                var login = Console.ReadLine();
                Console.WriteLine("Password:");
                var password = Console.ReadLine();

                var user = await favQuotesClient.CreateUserSession(login, password);

                var userToken = user.UserToken;

                Console.WriteLine(userToken);
                while (true)
                {
                    Console.WriteLine();
                    Console.WriteLine("Available commands:");
                    Console.WriteLine("1 - Get all quotes");
                    Console.WriteLine("2 - Get single quote");
                    Console.WriteLine("3 - Post a quote");
                    Console.WriteLine("4 - Fav a quote");
                    Console.WriteLine("5 - Unfav a quote");
                    Console.WriteLine("6 - Exit");

                    var chosenCommand = Console.ReadLine();
                    switch (chosenCommand)
                    {
                        case "1":
                            var quotes = await favQuotesClient.ShowAllQuotes();

                            foreach (var quote in quotes.Quotes)
                            {
                                Console.WriteLine(quote);
                            }
                            break;

                        case "2":
                            Console.WriteLine("Select quote ID:");
                            var selectedQuoteId = Convert.ToInt32(Console.ReadLine());

                            var quoteById = await favQuotesClient.ShowQuoteById(selectedQuoteId);

                            Console.WriteLine(quoteById);
                            break;

                        case "3":
                            Console.WriteLine("Author:");
                            var author = Console.ReadLine();
                            Console.WriteLine("Quote body:");
                            var body = Console.ReadLine();

                            var response = await favQuotesClient.PostQuote(author, body, user.UserToken);
                            //Console.WriteLine(response.EnsureSuccessStatusCode());
                            var quoteResponse = response.Content.ReadFromJsonAsync<QuoteResponse>();

                            Console.WriteLine(quoteResponse);
                            //Console.WriteLine(await response.Content.ReadAsStringAsync());
                            break;

                        case "4":
                            Console.WriteLine("Quote of ID to fav:");
                            var idFav = Convert.ToInt32(Console.ReadLine());

                            var responseFav = await favQuotesClient.FavQuote(idFav, user.UserToken);

                            var quoteResponseFav = responseFav.Content.ReadFromJsonAsync<FavQuoteResponse>();

                            Console.WriteLine();
                            Console.WriteLine(await quoteResponseFav);
                            Console.WriteLine();
                            break;

                        case "5":
                            Console.WriteLine("Quote of ID to unfav:");
                            var idUnFav = Convert.ToInt32(Console.ReadLine());

                            var responseUnFav = await favQuotesClient.UnFavQuote(idUnFav, user.UserToken);

                            var quoteResponseUnFav = responseUnFav.Content.ReadFromJsonAsync<FavQuoteResponse>();

                            Console.WriteLine();
                            Console.WriteLine(await quoteResponseUnFav);
                            Console.WriteLine();
                            break;

                        case "6":
                            return;
                    }
                }
            }
        }
    }
}