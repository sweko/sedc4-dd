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
            SqlConnection connection = new SqlConnection(@"Server=.\sqlexpress;Database=SciFiAwards;Trusted_Connection=True;");
            connection.Open();

            SqlCommand cmd = new SqlCommand("select top 1 ID from authors", connection);

            var result = (int)cmd.ExecuteScalar();

            Console.WriteLine(result);

            return null;
            //connect to database
            //make query
            //send query 
            //get result
            //create author
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
