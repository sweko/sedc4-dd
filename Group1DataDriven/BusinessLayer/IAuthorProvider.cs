using Entities;
using System;
using System.Collections.Generic;

namespace BusinessLayer
{
    public interface IAuthorProvider : IDisposable
    {
        Author ChangeName(Author author, string newName);

        IEnumerable<Author> GetAll();

        Author LoadData(int id);

    }
}