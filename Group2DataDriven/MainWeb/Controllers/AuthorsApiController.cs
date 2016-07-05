using BusinessLayer;
using Entities;
using Entities.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MainWeb.Controllers
{
    [RoutePrefix("api/authors")]
    public class AuthorsApiController : ApiController
    {

        // GET: api/Authors
        public AutorListViewModel Get()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["scifi-database"].ConnectionString;
            using (var provider = new AuthorProvider(connectionString))
            {
                return AutorListViewModel.FromModel(provider.GetAllAuthors());
            }
        }

        // GET: api/Authors/5
        public AuthorViewModel Get(int id)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["scifi-database"].ConnectionString;
            using (var provider = new AuthorProvider(connectionString))
            {
                var author = provider.LoadAuthor(id, true);
                return AuthorViewModel.FromModel(author);
            }
        }

        // POST: api/Authors
        public void Post(Author value)
        {
        }

        // PUT: api/Authors/5
        public void Put(int id, Author value)
        {
        }

        // DELETE: api/Authors/5
        public void Delete(int id)
        {
        }
    }
}
