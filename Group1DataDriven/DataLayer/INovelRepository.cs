using Entities;
using System;
using System.Collections.Generic;

namespace DataLayer
{
    public interface INovelRepository : IDisposable
    {
        bool Delete(Novel novel);
        bool Delete(int novelID);

        Novel Save(Novel novel);

        Novel Update(Novel novel);

        Novel GetById(int id);
        Novel GetByName(string name);

        IEnumerable<Novel> GetNovelsForAuthor(int authorId);
    }
}