using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using System.Data.SqlClient;

namespace DataLayer
{
    public class NovelRepository : INovelRepository
    {
        private SqlConnection connection;

        public NovelRepository(string connectionString)
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
        }

        public bool DeleteNovel(int id)
        {
            throw new NotImplementedException();
        }

        public bool DeleteNovel(Novel novel)
        {
            throw new NotImplementedException();
        }

        public Novel GetNovel(int id)
        {
            throw new NotImplementedException();
        }

        public Novel GetNovelByName(string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Novel> GetNovelsByAuthor(int authorId)
        {
            using (var cmd = new SqlCommand("select * from novels where authorId=@id", connection))
            {
                cmd.Parameters.AddWithValue("@id", authorId);
                using (var reader = cmd.ExecuteReader())
                {
                    var result = new List<Novel>();
                    while (reader.Read())
                    {
                        result.Add(GetNovelFromDataReader(reader));
                    }
                    return result;

                }
            }
        }

        private static Novel GetNovelFromDataReader(SqlDataReader reader)
        {
            var resultId = (int)reader["ID"];
            var title = (string)reader["Title"];
            var authorId = (int)reader["AuthorId"];
            var isRead = (bool)reader["IsRead"];

            return new Novel
            {
                ID = resultId,
                Title = title,
                AuthorID = authorId,
                IsRead = isRead
            };
        }

        public Novel SaveNovel(Novel novel)
        {
            throw new NotImplementedException();
        }

        public Novel UpdateNovel(Novel novel)
        {
            throw new NotImplementedException();
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    connection.Dispose();
                }

                // free unmanaged resources (unmanaged objects) and override a finalizer below.
                // set large fields to null.

                disposedValue = true;
            }
        }

        // override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~NovelRepository() {
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
