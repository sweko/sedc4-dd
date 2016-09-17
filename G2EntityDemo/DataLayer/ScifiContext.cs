using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class ScifiContext : DbContext
    {
        public ScifiContext() : base("SciFiDatabase")
        {
            Database.SetInitializer<ScifiContext>(null);
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Novel> Novels { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AuthorMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
