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

        }

        public DbSet<Author> Authors { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AuthorMapper());
            base.OnModelCreating(modelBuilder);

        }
    }
}
