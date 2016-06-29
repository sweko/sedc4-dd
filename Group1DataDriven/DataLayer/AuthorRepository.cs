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
        public bool Delete(int authorID)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Author author)
        {
            return Delete(author.ID);
        }

        public Author Get(int id)
        {
            //connect to database
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = @"Server=.\sqlexpress; Database=SciFiAwards; Trusted_Connection=True;";
            connection.Open();

            //make command
            SqlCommand command = new SqlCommand();
            command.CommandText = "select * from Authors where ID="+id.ToString();
            command.Connection = connection;

            //execute command / get result
            var reader = command.ExecuteReader();

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

        public IEnumerable<Author> GetAll()
        {
            throw new NotImplementedException();
        }

        public Author Save(Author author)
        {
            throw new NotImplementedException();
        }

        public Author Update(Author author)
        {
            throw new NotImplementedException();
        }
    }
}
