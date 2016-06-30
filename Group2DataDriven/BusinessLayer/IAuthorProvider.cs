using Entities;
using System;

namespace BusinessLayer
{
    public interface IAuthorProvider : IDisposable
    {
        Author LoadAuthor(int id, bool loadNovels);

        Author RegisterDeath(Author author, DateTime deathDate, bool isUndead);
        Author Ressurect(Author author);

    }
}