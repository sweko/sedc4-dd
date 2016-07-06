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

            foreach (var author in context.Authors)
            {
                Console.WriteLine(author);
            }

            //var cline = new Author
            //{
            //    Name = "Ernest Cline",
            //    BirthDate = new DateTime(1981, 8, 9)
            //};

            //Console.WriteLine(cline);

            //context.Authors.Add(cline);
            //context.SaveChanges();

            //Console.WriteLine(cline);


        }
    }
}
