using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ViewModels
{
    public struct AutorListViewModel
    {
        public struct AuthorViewModel
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public DateTime BirthDate { get; set; }
            public int NovelCount { get; set; }
        }

        public AuthorViewModel[] Authors { get; set; }

        public static AuthorViewModel FromAuthorModel(Author author)
        {
            return new AuthorViewModel
            {
                ID = author.ID,
                Name = author.Name,
                BirthDate = author.BirthDate,
                NovelCount = author.NovelCount ?? author.Novels.Count()
            };
        }


        public static AutorListViewModel FromModel(IEnumerable<Author> model)
        {
            return new AutorListViewModel
            {
                Authors = model.Select(FromAuthorModel).ToArray()
            };
        }
    }
}
