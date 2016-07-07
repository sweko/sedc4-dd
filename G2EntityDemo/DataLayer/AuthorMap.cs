using Entities;
using System.Data.Entity.ModelConfiguration;

namespace DataLayer
{
    internal class AuthorMap : EntityTypeConfiguration<Author>
    {
        public AuthorMap()
        {
            Property(author => author.BirthDate).HasColumnName("DateOfBirth");
            Property(author => author.DeathDate).HasColumnName("DateOfDeath");
        }
    }
}