using BusinessLayer;
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
            using (var provider = new AuthorProvider(connectionString))
            {
                var author = provider.LoadData(92);
                Console.WriteLine(author);
                foreach (var novel in author.Novels)
                {
                    Console.WriteLine($"   {novel}");
                }


                //var authors = provider.GetAll();
                //foreach (var author in authors)
                //{
                //    Console.WriteLine(author);
                //}
            }

            //using (var repository = new AuthorRepository(connectionString))
            //{
            //    var author = new Author
            //    {
            //        Name = "Pero",
            //        BirthDate = new DateTime(1943, 12, 3),
            //        DeathDate = new DateTime(2012, 3, 3)
            //    };

                //    author = repository.Save(author);
                //    Console.WriteLine(author);

                //var results = repository.GetAll();
                //foreach (var author in results)
                //{
                //    Console.WriteLine(author);
                //}


                //while (true)
                //{
                //    //int authorId = int.Parse(Console.ReadLine());
                //    var authorName = Console.ReadLine();
                //    var result = repository.GetByName(authorName);
                //    Console.WriteLine(result);
                //}
            //}
        }
    }
}
