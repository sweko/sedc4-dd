using DataLayer;
using Entities;
using MiniProfiler.Windows;
using StackExchange.Profiling;
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
            //ConsoleProfiling.Start();

            //Console.WriteLine("Starting to call methods..");

            //using (StackExchange.Profiling.MiniProfiler.Current.Step("Call Methods"))
            //{
            var context = new ScifiContext();

            foreach (var author in context.Authors.Include("Novels"))
            {
                Console.WriteLine($"{author.Name} - {author.Novels.Count()} novels");
            }

            //var heinlein = context.Authors.Include("Novels").Single(a => a.ID == 92);

            //Console.WriteLine(heinlein);
            //foreach (var novel in heinlein.Novels)
            //{
            //    Console.WriteLine($"    {novel}");
            //}
            //}

            // //Stop profiling and show results
            //Console.WriteLine(ConsoleProfiling.StopAndGetConsoleFriendlyOutputStringWithSqlTimings());


            //foreach (var author in context.Authors)
            //{
            //    Console.WriteLine(author);
            //}

            //var cline = new Author
            //{
            //    Name = "Ernest Cline",
            //    BirthDate = new DateTime(1981, 8, 9)
            //};

            //Console.WriteLine(cline);

            //context.Authors.Add(cline);
            //context.SaveChanges();

            //Console.WriteLine(cline);

            //foreach (var novel in context.Novels)
            //{
            //    Console.WriteLine(novel);
            //}






        }
    }
}
