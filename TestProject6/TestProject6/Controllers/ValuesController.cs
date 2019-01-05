using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TestProject6.AuthFilters;

namespace TestProject6.Controllers
{
    [RoutePrefix("values")]
    public class ValuesController : ApiController
    {
        [Route("")]
        //[Authorize]
       // [AllowAnonymous]
        public IEnumerable<string> Get()
        {
            return new string[] { User.Identity.Name, User.Identity.AuthenticationType };
        }
    }
}
