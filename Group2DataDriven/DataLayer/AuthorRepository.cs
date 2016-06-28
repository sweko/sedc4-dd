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

        public AuthorRepository()
        {
            connection = new SqlConnection(@"Server=.\sqlexpress;Database=SciFiAwards;Trusted_Connection=True;");
            connection.Open();
        }

        public bool DeleteAuthor(int id)
        {
            throw new NotImplementedException();
        }

        public bool DeleteAuthor(Author author)
        {
            return DeleteAuthor(author.ID);
        }

        public IEnumerable<Author> GetAllAuthors()
        {
            throw new NotImplementedException();
        }

        public Author GetAuthor(int id)
        {
            SqlCommand cmd = new SqlCommand("select * from authors where id = @id", connection);
            cmd.Parameters.AddWithValue("@id", id);
            var reader = cmd.ExecuteReader();

            if (!reader.Read()) 
            {
                return null;
            }

            var resultId = (int)reader["ID"];
            var name = (string)reader["Name"];
            var birthDate = (DateTime)reader["DateOfBirth"];
            var deathDate = reader["DateOfDeath"] as DateTime?;

            return new Author
            {
                ID = resultId,
                Name = name,
                BirthDate = birthDate,
                DeathDate = deathDate
            };
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

                    var resultId = (int)reader["ID"];
                    var authorName = (string)reader["Name"];
                    var birthDate = (DateTime)reader["DateOfBirth"];
                    var deathDate = reader["DateOfDeath"] as DateTime?;

                    return new Author
                    {
                        ID = resultId,
                        Name = authorName,
                        BirthDate = birthDate,
                        DeathDate = deathDate
                    };
                }
            }
        }

        public Author SaveAuthor(Author author)
        {
            throw new NotImplementedException();
        }

        public Author UpdateAuthor(Author author)
        {
            throw new NotImplementedException();
        }
    }
}
