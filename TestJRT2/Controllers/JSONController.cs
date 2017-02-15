using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TestJRT2.Controllers
{
    public class JSONController : ApiController
    {
        // GET: api/JSON
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/JSON/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/JSON
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/JSON/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/JSON/5
        public void Delete(int id)
        {
        }
    }
}
