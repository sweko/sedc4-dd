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
            var repository = new AuthorRepository();
            while (true)
            {
                //int authorId = int.Parse(Console.ReadLine());
                var authorName = Console.ReadLine();
                var result = repository.GetByName(authorName);
                Console.WriteLine(result);
            }

        }
    }
}
