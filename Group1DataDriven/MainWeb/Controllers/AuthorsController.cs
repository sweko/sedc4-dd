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
    public class AuthorsController : ApiController
    {
        private string connectionString;
        public AuthorsController()
        {
            connectionString = ConfigurationManager.ConnectionStrings["SciFiDatabase"].ConnectionString;
        }

        // GET: api/Authors
        public AuthorListViewModel Get()
        {
            using (var provider = new AuthorProvider(connectionString))
            {
                return AuthorListViewModel.FromModel(provider.GetAll());
            }
        }

        // GET: api/Authors/5
        public AuthorViewModel Get(int id)
        {
            using (var provider = new AuthorProvider(connectionString))
            {
                var author = provider.LoadData(id);
                return AuthorViewModel.FromModel(author);
            }
        }

        // POST: api/Authors
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Authors/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Authors/5
        public void Delete(int id)
        {
        }
    }
}
