using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TestProject2.Controllers
{
    public class OrdersController : ApiController
    {
        [HttpGet, Route("orders/{id:length(8)}", Order = 2 )]
        public string GetOrderById(string id)
        {
            return "order-" + id;
        }
        [HttpGet, Route("orders/{status:regex(^(?i)(new|complete|pending)$)}", Order = 1)]
        public IEnumerable<string> GetOrderStatus()
        {
            return new string[] { "status1", "status2" };
        }
        // GET: api/Orders
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Orders/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Orders
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Orders/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Orders/5
        public void Delete(int id)
        {
        }
    }
}
