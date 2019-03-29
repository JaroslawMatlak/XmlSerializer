using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SerializerApi.Controllers
{
    public class DataController : ApiController
    {
        public void Post([FromBody]string value)
        {
        }
    }
}
