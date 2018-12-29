using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TestProject2.Controllers
{
    public class ValuesController : ApiController
    {
        // GET: api/Values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Values
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Values/5
        public void Delete(int id)
        {
        }

        [HttpGet, Route("dates/{*myDate:datetime}")]
        public string GetDate(DateTime myDate)
        {
            return myDate.ToLongDateString();
        }

        [HttpGet, Route("segments/{*array:maxlength(256)}")]
        public string[] GetSegements(string[] array)
        {
            return array;
        }
    }
}
