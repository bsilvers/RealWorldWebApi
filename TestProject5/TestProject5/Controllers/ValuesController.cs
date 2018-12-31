using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TestProject5.Filters;

namespace TestProject5.Controllers
{
    [RoutePrefix("values")]
    [RouteTimerFilter("GetAllValues")]
    public class ValuesController : ApiController
    {
        [HttpGet, Route("")]
        // GET: api/Values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Values/5
        [HttpGet, Route("{id:int}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Values
        [HttpPost, Route("")]
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Values/5
        [HttpPut, Route("")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Values/5
        [HttpDelete, Route("{id:int}")]
        public void Delete(int id)
        {
        }
    }
}
