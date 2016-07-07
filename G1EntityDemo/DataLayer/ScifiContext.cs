using Entities;
using StackExchange.Profiling;
using StackExchange.Profiling.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class ScifiContext : DbContext
    {
        static ScifiContext()
        {
            Database.SetInitializer<ScifiContext>(null); 
        }

        public ScifiContext() : base("SciFiDatabase")
        {

        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Novel> Novels { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AuthorMapper());
            base.OnModelCreating(modelBuilder);
        }
    }
}
