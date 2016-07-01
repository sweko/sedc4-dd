using DataLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var username = ConfigurationManager.AppSettings["username"];
            Console.WriteLine($"Hello {username}, welcome to the SciFi Database");

            var connectionString = ConfigurationManager.ConnectionStrings["SciFiDatabase"].ConnectionString;
            while (true)
            {
                using (var repository = new AuthorRepository(connectionString))
                {
                    //int authorId = int.Parse(Console.ReadLine());
                    var authorName = Console.ReadLine();
                    var result = repository.GetByName(authorName);
                    Console.WriteLine(result);
                }
            }
        }
    }
}
