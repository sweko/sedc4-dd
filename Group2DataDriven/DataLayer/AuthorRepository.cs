using Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class AuthorRepository : IAuthorRepository
    {
        private SqlConnection connection;

        public AuthorRepository(string connectionString)
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
        }

        public bool DeleteAuthor(int id)
        {
            using (var cmd = new SqlCommand("delete from authors where id=@id", connection))
            {
                cmd.Parameters.AddWithValue("@id", id);
                var result = cmd.ExecuteNonQuery();
                return (result == 1);
            }
        }

        public bool DeleteAuthor(Author author)
        {
            return DeleteAuthor(author.ID);
        }

        public IEnumerable<Author> GetAllAuthors()
        {
            using (var cmd = new SqlCommand(@"select a.ID, a.Name, a.DateOfBirth, a.DateOfDeath, count(*) as NovelCount
from authors a
inner
join Novels n on a.ID = n.AuthorID
group by a.ID, a.Name, a.DateOfBirth, a.DateOfDeath", connection))
            {
                using (var reader = cmd.ExecuteReader())
                {
                    var result = new List<Author>();
                    while (reader.Read())
                    {
                       result.Add(GetAuthorFromDataReader(reader, true));
                    }
                    return result;
                }
            }
        }

        public Author GetAuthor(int id)
        {
            using (var cmd = new SqlCommand("select * from authors where id=@id", connection))
            {
                cmd.Parameters.AddWithValue("@id", id);
                using (var reader = cmd.ExecuteReader())
                {
                    if (!reader.Read())
                    {
                        return null;
                    }

                    return GetAuthorFromDataReader(reader);
                }
            }
        }

        public Author GetAuthorByName(string name)
        {
            using (var cmd = new SqlCommand("select top 1 * from authors where name like '%'+@name+'%'", connection))
            {
                cmd.Parameters.AddWithValue("@name", name);
                using (var reader = cmd.ExecuteReader())
                {
                    if (!reader.Read())
                    {
                        return null;
                    }

                    return GetAuthorFromDataReader(reader);
                }
            }
        }

        private static Author GetAuthorFromDataReader(SqlDataReader reader, bool mapNovelCount = false)
        {
            var resultId = (int)reader["ID"];
            var authorName = (string)reader["Name"];
            var birthDate = (DateTime)reader["DateOfBirth"];
            var deathDate = reader["DateOfDeath"] as DateTime?;
            var novelCount = (mapNovelCount) ? (int)reader["NovelCount"] : (int?)null;

            return new Author
            {
                ID = resultId,
                Name = authorName,
                BirthDate = birthDate,
                DeathDate = deathDate,
                NovelCount = novelCount
            };
        }


        public Author SaveAuthor(Author author)
        {
            if (author.ID != 0)
                return UpdateAuthor(author);

            if (ExistByName(author))
                throw new ArgumentException("author already exists");

            using (var cmd = new SqlCommand("insert into Authors (Name, DateOfBirth, DateOfDeath) values (@name, @birthDate, @deathDate)", connection))
            {
                cmd.Parameters.AddWithValue("@name", author.Name);
                cmd.Parameters.AddWithValue("@birthDate", author.BirthDate);
                cmd.Parameters.AddWithValue("@deathDate", author.DeathDate);
                cmd.ExecuteNonQuery();

                return GetAuthorByName(author.Name);
            }
        }

        public Author UpdateAuthor(Author author)
        {
            if (author.ID == 0)
                return SaveAuthor(author);

            throw new NotImplementedException();
        }

        private bool ExistByName(Author author)
        {
            using (var cmd = new SqlCommand("select count(*) from Authors where Name = @name", connection))
            {
                cmd.Parameters.AddWithValue("@name", author.Name);
                var count = (int)cmd.ExecuteScalar();

                return count == 1;
            }
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
