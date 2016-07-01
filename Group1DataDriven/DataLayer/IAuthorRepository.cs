using Entities;
using System;
using System.Collections.Generic;

namespace DataLayer
{
    public interface IAuthorRepository : IDisposable
    {
        bool Delete(Author author);
        bool Delete(int authorID);

        Author Save(Author author);

        Author Update(Author author);

        Author GetById(int id);
        Author GetByName(string name);

        IEnumerable<Author> GetAll();

    }
}