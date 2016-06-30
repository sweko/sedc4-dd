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
                while (true)
                {
                    string name = Console.ReadLine();
                    var author = repository.GetAuthorByName(name);
                    Console.WriteLine(author);
                }
            }
        }
    }
}
