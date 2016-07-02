using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using DataLayer;

namespace BusinessLayer
{
    public class AuthorProvider : IAuthorProvider
    {
        IAuthorRepository authorRepository;
        INovelRepository novelRepository;

        public AuthorProvider(string connectionString)
        {
            authorRepository = new AuthorRepository(connectionString);
            novelRepository = new NovelRepository(connectionString);
        }

        public Author ChangeName(Author author, string newName)
        {
            author.Name = newName;
            authorRepository.Update(author);
            return author;
        }

        public IEnumerable<Author> GetAll()
        {
            return authorRepository.GetAll();
        }

        public Author LoadData(int id)
        {
            var author = authorRepository.GetById(id);
            author.Novels = novelRepository.GetNovelsForAuthor(id);
            foreach (var novel in author.Novels)
            {
                novel.Author = author;
            }
            return author;
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    authorRepository.Dispose();
                    novelRepository.Dispose();
                }

                // free unmanaged resources (unmanaged objects) and override a finalizer below.
                // set large fields to null.

                disposedValue = true;
            }
        }

        // override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~AuthorProvider() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }

        #endregion
    }
}
