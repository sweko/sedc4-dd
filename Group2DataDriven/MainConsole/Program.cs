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
            var connectionString = ConfigurationManager.ConnectionStrings["scifi-database"].ConnectionString;
            using (var provider = new AuthorProvider(connectionString))
            {
                var author = provider.LoadAuthor(92, true);

                Console.WriteLine(author);
                foreach (var novel in author.Novels)
                {
                    Console.WriteLine(novel);
                }

                //author = new Author
                //{
                //    Name = "novo dete",
                //    BirthDate = new DateTime(1978, 2, 3),
                //    DeathDate = new DateTime(2016, 2, 3),
                //};

                //author = repository.SaveAuthor(author);

                //Console.WriteLine(author);


                //var authors = repository.GetAllAuthors();
                //foreach (var author in authors)
                //{
                //    Console.WriteLine(author);
                //}

                //while (true)
                //{
                //    string name = Console.ReadLine();
                //    var author = repository.GetAuthorByName(name);
                //    Console.WriteLine(author);
                //}
            }
        }
    }
}
