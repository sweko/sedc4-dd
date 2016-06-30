using DataLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var repository = new AuthorRepository())
            {
                var author = repository.GetAuthorByName("novo dete");

                repository.DeleteAuthor(author);

                author = new Author
                {
                    Name = "novo dete",
                    BirthDate = new DateTime(1978, 2, 3),
                    DeathDate = new DateTime(2016, 2, 3),
                };

                author = repository.SaveAuthor(author);

                Console.WriteLine(author);


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
