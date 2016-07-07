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
            var context = new ScifiContext();
            var authors = context.Authors;

            foreach (var author in authors)
            {
                Console.WriteLine(author);
            }

            Console.WriteLine(authors.Count());

            //var andyWeir = new Author
            //{
            //    Name = "Andy Weir",
            //    BirthDate = new DateTime(1968, 7, 7)
            //};

            //Console.WriteLine(andyWeir);
            //context.Authors.Add(andyWeir);
            //context.SaveChanges();
            //Console.WriteLine(andyWeir);
        }
    }
}
