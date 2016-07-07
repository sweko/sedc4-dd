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
    internal class NovelMapper : EntityTypeConfiguration<Novel>
    {
        public NovelMapper()
        {
            ToTable("Novels");

            HasRequired(n => n.Author).WithMany(a => a.Novels);

        }
    }
}
