using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    internal class AuthorMapper : EntityTypeConfiguration<Author>
    {
        public AuthorMapper()
        {
            ToTable("Authors");

            Property(author => author.BirthDate).HasColumnName("DateOfBirth");
            Property(author => author.DeathDate).HasColumnName("DateOfDeath");

            HasKey(author => author.ID);
            Property(author => author.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
