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
        private SqlConnection connection = new SqlConnection();

        public NovelRepository(string connectionString)
        {
            connection.ConnectionString = connectionString;
            connection.Open();
        }

        public bool Delete(int novelID)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Novel novel)
        {
            throw new NotImplementedException();
        }

        public Novel GetById(int id)
        {
            //make command
            using (SqlCommand command = new SqlCommand())
            {
                command.CommandText = "select * from Novels where ID=@id";
                command.Connection = connection;
                command.Parameters.AddWithValue("@id", id);

                //execute command / get result
                using (var reader = command.ExecuteReader())
                {

                    //make novel from result
                    if (!reader.Read())
                    {
                        return null;
                    }

                    return GetNovelForDataReaderRow(reader);
                }
            }
        }

        public Novel GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Novel> GetNovelsForAuthor(int authorId)
        {
            //make command
            using (SqlCommand command = new SqlCommand())
            {
                command.CommandText = "select * from Novels where AuthorID = @authorId";
                command.Connection = connection;
                command.Parameters.AddWithValue("@authorId", authorId);

                //execute command / get result
                using (var reader = command.ExecuteReader())
                {
                    var result = new HashSet<Novel>();
                    //make author from result
                    while (reader.Read())
                    {
                        result.Add(GetNovelForDataReaderRow(reader));
                    }
                    return result;
                }
            }
        }

        private static Novel GetNovelForDataReaderRow(SqlDataReader reader)
        {
            //get things from reader into an object
            var id = (int)reader["ID"];
            var title = (string)reader["Title"];
            var authorId = (int)reader["AuthorID"];
            var isRead = (bool)reader["IsRead"];

            return new Novel
            {
                ID = id,
                Title = title,
                AuthorID = authorId,
                IsRead = isRead
            };
        }


        public Novel Save(Novel novel)
        {
            throw new NotImplementedException();
        }

        public Novel Update(Novel novel)
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
