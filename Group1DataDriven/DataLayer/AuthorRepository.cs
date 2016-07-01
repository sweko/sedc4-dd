using Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataLayer
{
    public class AuthorRepository : IAuthorRepository
    {
        private SqlConnection connection = new SqlConnection();

        public AuthorRepository(string connectionString)
        {
            connection.ConnectionString = connectionString;
            connection.Open();
        }

        public bool Delete(int authorID)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Author author)
        {
            return Delete(author.ID);
        }

        public IEnumerable<Author> GetAll()
        {
            throw new NotImplementedException();
        }

        public Author GetById(int id)
        {
            //make command
            using (SqlCommand command = new SqlCommand())
            {
                command.CommandText = "select * from Authors where ID=@id";
                command.Connection = connection;
                command.Parameters.AddWithValue("@id", id);

                //execute command / get result
                using (var reader = command.ExecuteReader())
                {

                    //make author from result
                    if (!reader.Read())
                    {
                        return null;
                    }

                    //get things from reader into an object
                    var authorId = (int)reader["ID"];
                    var name = (string)reader["Name"];
                    var birthDate = (DateTime)reader["DateOfBirth"];
                    var deathDate = reader["DateOfDeath"] as DateTime?;

                    return new Author
                    {
                        ID = authorId,
                        Name = name,
                        BirthDate = birthDate,
                        DeathDate = deathDate
                    };
                }
            }
        }

        public Author GetByName(string name)
        {
            using (SqlCommand command = new SqlCommand())
            {
                command.CommandText = "select top 1 * from Authors where Name like '%'+@pere+'%'";
                command.Connection = connection;
                command.Parameters.AddWithValue("@pere", name);

                //execute command / get result
                using (var reader = command.ExecuteReader())
                {
                    //make author from result
                    if (!reader.Read())
                    {
                        return null;
                    }

                    //get things from reader into an object
                    var authorId = (int)reader["ID"];
                    var authorName = (string)reader["Name"];
                    var birthDate = (DateTime)reader["DateOfBirth"];
                    var deathDate = reader["DateOfDeath"] as DateTime?;

                    return new Author
                    {
                        ID = authorId,
                        Name = authorName,
                        BirthDate = birthDate,
                        DeathDate = deathDate
                    };
                }
            }
        }

        public Author Save(Author author)
        {
            throw new NotImplementedException();
        }

        public Author Update(Author author)
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
        // ~AuthorRepository() {
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
