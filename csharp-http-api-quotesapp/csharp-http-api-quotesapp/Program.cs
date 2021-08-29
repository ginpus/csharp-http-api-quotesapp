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

            /*            Console.WriteLine("----------Get all quotes----------");
                        var quotes = await favQuotesClient.ShowAllQuotes();

                        //Console.WriteLine(quotes);

                        foreach (var quote in quotes.Quotes)
                        {
                            Console.WriteLine(quote);
                        }

                        Console.WriteLine("----------Get single quote----------");
                        Console.WriteLine("Select quote ID:");
                        var selectedQuoteId = Convert.ToInt32(Console.ReadLine());

                        var quoteById = await favQuotesClient.ShowQuoteById(selectedQuoteId);

                        Console.WriteLine(quoteById);*/

            Console.WriteLine("----------Create user session----------");
            Console.WriteLine("User:");
            var login = Console.ReadLine();
            Console.WriteLine("Password:");
            var password = Console.ReadLine();

            var user = await favQuotesClient.CreateUserSession(login, password);

            var userToken = user.UserToken;

            Console.WriteLine(userToken);

            /*            Console.WriteLine("----------Post a quote----------");

                        Console.WriteLine("Author:");
                        var author = Console.ReadLine();
                        Console.WriteLine("Quote body:");
                        var body = Console.ReadLine();

                        var response = await favQuotesClient.PostQuote(author, body, user.UserToken);
                        //Console.WriteLine(response.EnsureSuccessStatusCode());
                        var quoteResponse = response.Content.ReadFromJsonAsync<QuoteResponse>();

                        Console.WriteLine(quoteResponse);
                        //Console.WriteLine(await response.Content.ReadAsStringAsync());*/

            Console.WriteLine("----------Fav a quote----------");

            Console.WriteLine("Quote of ID to fav:");
            var idFav = Convert.ToInt32(Console.ReadLine());

            var responseFav = await favQuotesClient.FavQuote(idFav, user.UserToken);
            //Console.WriteLine(response.EnsureSuccessStatusCode());
            var quoteResponseFav = responseFav.Content.ReadFromJsonAsync<QuoteResponse>();

            Console.WriteLine(quoteResponseFav);
            //Console.WriteLine(await response.Content.ReadAsStringAsync());
        }
    }
}