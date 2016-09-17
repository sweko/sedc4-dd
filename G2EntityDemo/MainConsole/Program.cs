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
            //var authors = context.Authors;

            //foreach (var author in authors)
            //{
            //    Console.WriteLine(author);
            //}

            //Console.WriteLine(authors.Count());

            //var andyWeir = new Author
            //{
            //    Name = "Andy Weir",
            //    BirthDate = new DateTime(1968, 7, 7)
            //};

            //Console.WriteLine(andyWeir);
            //context.Authors.Add(andyWeir);
            //context.SaveChanges();
            //Console.WriteLine(andyWeir);

            //var marsNovels = context.Novels
            //    .Where(n => n.Title.Contains("Mars"));


            //var ksrMarsNovels = marsNovels
            //    .Where(n => n.AuthorID == 274);

            //foreach (var novel in ksrMarsNovels)
            //{
            //    Console.WriteLine(novel);
            //}

            //Console.WriteLine(ksrMarsNovels.Count());


            var ksr = context.Authors.Single(a => a.ID == 274);

            //Console.WriteLine(ksr.GetType().FullName);

            Console.WriteLine(ksr);
            foreach (var novel in ksr.Novels)
            {
                Console.WriteLine($"  {novel}");
            }

            //var authors = context.Authors.Include("Novels");

            //foreach (var author in authors)
            //{
            //    //Console.WriteLine(author.Novels.Count());
            //    Console.WriteLine($"{author.Name} ({author.Novels.Count()})");
            //}
        }
    }
}
