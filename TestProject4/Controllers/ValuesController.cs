using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TestProject4.Handlers;

namespace TestProject4.Controllers
{
    [RoutePrefix("values")]
    public class ValuesController : ApiController
    {
        [HttpGet, Route("")]
        // GET: api/Values
        public IEnumerable<string> Get()
        {
            var getByIdUrl = Url.Link("GetById", new { id = 123 });
            //return new string[] { "value1", "value2", Request.GetApiKey() };
            return new string[]
            {
                getByIdUrl,
                Request.GetSelfReferenceBaseUrl().ToString(),
                Request.RebaseUrlForClient(new Uri(getByIdUrl)).ToString()
            };

            
        }

        // GET: api/Values/5
        [HttpGet, Route("{id:int}", Name = "GetById")]
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
        public void Delete(int id)
        {
        }
    }
}
