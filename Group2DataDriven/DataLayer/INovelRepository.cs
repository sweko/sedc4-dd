using Entities;
using System;
using System.Collections.Generic;

namespace DataLayer
{
    public interface INovelRepository : IDisposable
    {
        Novel GetNovel(int id);
        IEnumerable<Novel> GetNovelsByAuthor(int authorId);

        Novel SaveNovel(Novel novel);

        Novel UpdateNovel(Novel novel);

        bool DeleteNovel(Novel novel);
        bool DeleteNovel(int id);

        Novel GetNovelByName(string name);
    }
}