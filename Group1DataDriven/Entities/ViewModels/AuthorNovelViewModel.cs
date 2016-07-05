using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ViewModels
{
    public struct AuthorNovelViewModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public bool IsRead { get; set; }

        internal static AuthorNovelViewModel FromModel(Novel novel)
        {
            return new AuthorNovelViewModel
            {
                ID = novel.ID,
                Title = novel.Title,
                IsRead = novel.IsRead
            };
        }
    }
}
