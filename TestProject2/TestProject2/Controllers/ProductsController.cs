using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TestProject2.Controllers
{
    [RoutePrefix("api/products")]
    public class ProductsController : ApiController
    {
        [HttpGet, Route("")]
        // GET: api/Products
        public IEnumerable<string> GetAllProducts()
        {
            return new string[] { "product1", "product2" };
        }
        [HttpGet, Route("{id:int:range(1000,3000)}")]
        // GET: api/Products/5
        public string GetProduct(int id)
        {
            return "product-" + id;
        }
        [HttpGet, Route("{id:int:range(1000,3000)}/orders/{custid}")]
        // GET: api/Products/5
        public string GetProductForCustomer(int id, string custid)
        {
            return "product-orders-" + custid;
        }

        [HttpPost, Route("")]
        // POST: api/Products
        public void CreateProduct([FromBody]string value)
        {
        }
        [HttpPut, Route("{id:int:range(1000,3000)}")]
        // PUT: api/Products/5
        public void Put(int id, [FromBody]string value)
        {
        }
        [HttpDelete, Route("{id:int:range(1000,3000)}")]
        // DELETE: api/Products/5
        public void Delete(int id)
        {
        }
    }
}
