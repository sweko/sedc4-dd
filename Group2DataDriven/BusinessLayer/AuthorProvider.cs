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
        private IAuthorRepository authorRepository;
        private INovelRepository novelRepository;

        public AuthorProvider(string connectionString)
        {
            authorRepository = new AuthorRepository(connectionString);
            novelRepository = new NovelRepository(connectionString);
        }


        public Author LoadAuthor(int id, bool loadNovels)
        {
            var result = authorRepository.GetAuthor(id);
            result.Novels = novelRepository.GetNovelsByAuthor(id);
            foreach (var novel in result.Novels)
            {
                novel.Author = result;
            }

            return result;
        }

        public Author RegisterDeath(Author author, DateTime deathDate, bool isUndead)
        {
            if (author.DeathDate != null && !isUndead)
                throw new Exception("You cannot die twice (unless undead)");

            author.DeathDate = deathDate;
            author = authorRepository.UpdateAuthor(author);
            return author;
        }

        public Author Ressurect(Author author)
        {
            if (author.DeathDate == null)
                throw new Exception("Author is still alive, kill him first");

            author.DeathDate = null;
            author = authorRepository.UpdateAuthor(author);
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
