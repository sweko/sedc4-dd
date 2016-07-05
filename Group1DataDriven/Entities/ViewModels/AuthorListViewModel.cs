using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ViewModels
{
    public struct AuthorListViewModel
    {
        public AuthorItemViewModel[] Authors { get; set; } 

        public static AuthorListViewModel FromModel(IEnumerable<Author> model)
        {
            return new AuthorListViewModel
            {
                Authors = model.Select(AuthorItemViewModel.FromModel).ToArray()
            };
            
        }
    }


}
