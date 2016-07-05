using System;
using System.Linq;

namespace Entities.ViewModels
{
    public class AuthorItemViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public bool IsDead { get; set; }
        public int NovelCount { get; set; }

        internal static AuthorItemViewModel FromModel(Author author)
        {
            return new AuthorItemViewModel
            {
                ID = author.ID,
                Name = author.Name,
                BirthDate = author.BirthDate,
                IsDead = author.DeathDate != null,
                NovelCount = author.NovelCount ?? author.Novels.Count()
            };
        }
    }
}