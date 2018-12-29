using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TestProject2.Controllers
{
    [RoutePrefix("api/products")]
    public class ProductsController : ApiController
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public enum Widgets
        {
            Bolt,
            Screw,
            Nut,
            Motor
        };
        [HttpGet, Route("widget/{widget:enum(TestProject2.Controllers.ProductsController+Widgets)}")]
        public string GetProductsWithWidget(Widgets widget)
        {
            return "widget-" + widget.ToString();
        }

        [HttpGet, Route("status/{status:alpha=pending}/{id:int=5}")]
        public string GetProductsWithStatus(string status, int id)
        {
            return String.IsNullOrEmpty(status) ? "NULL" : status;
        }

        [Route("")]
        [AcceptVerbs("GET", "VIEW")]
        // GET: api/Products
        public IEnumerable<string> GetAllProducts()
        {
            return new string[] { "product1", "product2" };
        }
        [HttpGet, Route("{id:int:range(1000,3000)}", Name ="GetById")]
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

        [HttpPost, Route("{prodId:int:range(1000,3000)}")]
        // POST: api/Products
        public HttpResponseMessage CreateProduct([FromUri]int prodId)
        {
            var response = Request.CreateResponse(HttpStatusCode.Created);

            string uri = Url.Link("GetById", new { id = prodId });
            response.Headers.Location = new Uri(uri);
            return response;
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
