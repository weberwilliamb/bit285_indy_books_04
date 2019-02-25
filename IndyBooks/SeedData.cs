using System;
using System.Linq;
using System.Threading.Tasks;
using IndyBooks.Models;
using Microsoft.Extensions.DependencyInjection;

namespace IndyBooks
{
    public static class SeedData
    {
        public static async Task InitializeAsync(IServiceProvider services)
        {
            await Seed(services.GetRequiredService<IndyBooksDataContext>());
        }

        public static async Task Seed(IndyBooksDataContext context)
        {
            if (context.Books.Any())
            {
                return; //already has data, don't add any more test data
            }
            //  TODO: Create two additional books in the seed data 
            //         drop and then update the database using ef
            //
            context.Books.Add(new Book
            {
                Id = 1,
                Title = "Pride and Prejudice",
                Author = "Jane Austin",
                Price = 9.99M
            });
            context.Books.Add(new Book
            {
                Id = 2,
                Title = "Northanger Abbey",
                Author = "Jane Austin",
                Price = 12.95M
            });
            context.Books.Add(new Book
            {
                Id = 3,
                Title = "David Copperfield",
                Author = "Charles Dickens",
                Price = 15.00M
            });
            context.Books.Add(new Book
            {
                Id = 4,
                Title = "The Wizard of EarthSea",
                Author = "Ursula Le Guin",
                Price = 8.95M
            });
            context.Books.Add(new Book
            {
                Id = 5,
                Title = "The Tombs of Atuan",
                Author = "Ursula Le Guin",
                Price = 7.95M
            });
            context.Books.Add(new Book
            {
                Id = 6,
                Title = "The Farthest Shore",
                Author = "Ursula Le Guin",
                Price = 9.95M
            });

            await context.SaveChangesAsync();
        }
    }
}
