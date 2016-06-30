using Entities;
using System;
using System.Collections.Generic;
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
        public IEnumerable<Author> Get()
        {
            throw new NotImplementedException();
        }

        // GET: api/Authors/5
        public string Get(int id)
        {
            throw new NotImplementedException();
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
