using Entities;
using System.Collections.Generic;

namespace DataLayer
{
    public interface IAuthorRepository
    {
        bool Delete(Author author);
        bool Delete(int authorID);

        Author Save(Author author);

        Author Update(Author author);

        Author Get(int id);
        IEnumerable<Author> GetAll();

    }
}