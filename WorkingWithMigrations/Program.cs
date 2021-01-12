using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using WorkingWithMigrations.Entities;

namespace WorkingWithMigrations
{
    class Program
    {
        public static ProgramContext db = new ProgramContext(GetOptions());
        static void Main(string[] args)
        {
            foreach (var author in AuthorsWithHighestRate(4))
            {
                Console.WriteLine(author.Name);
            }
            Console.ReadLine();

        }
        public static DbContextOptions<ProgramContext> GetOptions()
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var config = builder.Build();
            string connectionString = config.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<ProgramContext>();
            var options = optionsBuilder
                .UseSqlServer(connectionString)
                .Options;
            return options;
        }
        public static IEnumerable<Author> AuthorsWithHighestRate(int rate)
        {
            return db.Books
                .Select(x => new { Author = x.Author, AverageRate = x.BookReviews.Average(y => y.Rating) })
                .Where(x => x.AverageRate > rate)
                .Select(x => x.Author);
        }
    }
}
